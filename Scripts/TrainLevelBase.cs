using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Jundroo.SimplePlanes.ModTools;

public abstract class TrainLevelBase : Level
{
    private string LevelGameObjectName;
    private Transform StopTargetTransform;
    private Text ClockDisplay;

    private GameObject FrontPart;

    // Current conditions
    protected float CurrentTimeSeconds = 0f;
    protected float StopTimer = 0f;
    protected int CurrentStop = 0;
    protected int NextStop = 0;
    protected bool IsStopped = true;

    // Signals
    private int SignalChangeProgress = 0;
    private SignalManagerScript SignalManager;

    public TrainLevelBase(string levelName, string levelMap, string levelDescription, string levelGameObjectName)
        : base(levelName, levelMap, levelDescription)
    {
        LevelGameObjectName = levelGameObjectName;
    }

    // Settings
    protected float AllowedStopDeviation = 3f;
    protected float CountStopDuration = 1f;
    protected float CountStopSpeed = 0.1f;
    protected float CancelStopSpeed = 0.4f;
    protected float CountPassDistance = 10f;

    protected float NextRepeatedMessageTimer = 1f;
    protected float RepeatedMessageInterval = 1f;
    protected string RepeatedMessage = "";

    // Level state
    protected bool Initialized = false;
    protected bool LevelCompleted = false;

    private bool DebugDistance = false;

    protected class SignalSettings
    {
        public float TimeSeconds;
        public SignalScript.Aspects Aspect;
        public string SignalName;
        public bool IsGroup;

        public SignalSettings(float t, SignalScript.Aspects aspect, string signalName, bool isGroup = false)
        {
            TimeSeconds = t;
            Aspect = aspect;
            SignalName = signalName;
            IsGroup = isGroup;
        }
    }

    protected static int Seconds(int h, int m, int s)
    {
        return h * 3600 + m * 60 + s;
    }

    protected static float Seconds(int h, int m, float s)
    {
        return h * 3600 + m * 60 + s;
    }

    protected virtual string TrainDamagedMessage
    {
        get
        {
            return "Your train was damaged.";
        }
    }

    protected virtual string StartedWhileDoorsOpenMessage
    {
        get
        {
            return "The train moved off while passengers were boarding or alighting.";
        }
    }

    protected virtual string SuccessMessage
    {
        get
        {
            return "Job completed!";
        }
    }

    protected virtual float StartTimeSeconds
    {
        get
        {
            return 43200f;
        }
    }

    /// <summary>
    /// Departure time of day in seconds for each station (index 0 for starting station).
    /// </summary>
    protected virtual int[] DepartureTimes
    {
        get
        {
            return null;
        }
    }

    /// <summary>
    /// Arrival or pass-through time shown on the display (index 0 for starting station).
    /// </summary>
    protected virtual int[] ArrivalTimes
    {
        get
        {
            return null;
        }
    }

    /// <summary>
    /// Minimum time that the train must remain stopped (index 0 for starting station). Negative value for passing stations.
    /// </summary>
    protected virtual int[] MinStopDurations
    {
        get
        {
            return null;
        }
    }

    /// <summary>
    /// Position where the front of the train must align with (index 0 unused).
    /// </summary>
    protected virtual Vector3[] StopPositions
    {
        get
        {
            return null;
        }
    }

    /// <summary>
    /// Overrides to signal permissions, must be from earliest to latest.
    /// </summary>
    protected virtual SignalSettings[] SignalChanges
    {
        get
        {
            return System.Array.Empty<SignalSettings>();
        }
    }

    protected virtual WeatherPreset Weather
    {
        get
        {
            return WeatherPreset.Clear;
        }
    }

    protected virtual string StartRepeatedMessage
    {
        get
        {
            return "Wait for the signal to depart.";
        }
    }

    protected virtual string OnArrivedRepeatedMessage
    {
        get
        {
            return "The train arrived at the station. Wait for the signal to depart.";
        }
    }

    protected virtual string DepartSignalMessage
    {
        get
        {
            return "Ready to depart.";
        }
    }

    protected virtual string IncorrectStopPositionRepeatedMessage
    {
        get
        {
            return "Move the train to the stop position.";
        }
    }

    protected virtual string StoppedAtPassingStationMessage
    {
        get
        {
            return "Do not stop at this station.";
        }
    }

    private string FormatTime(float TimeOfDaySeconds)
    {
        int t = Mathf.RoundToInt(TimeOfDaySeconds);
        if (t >= 0)
        {
            return $"{t / 3600 % 24:00}:{t / 60 % 60:00}:{t % 60:00}";
        }
        else
        {
            return "--:--:--";
        }
    }

    protected WeatherPreset RandomWeatherPresetNormal
    {
        get
        {
            WeatherPreset[] AvailableWeatherPresets = new[]
            {
                WeatherPreset.Clear,
                WeatherPreset.FewClouds,
                WeatherPreset.ScatteredClouds,
                WeatherPreset.BrokenClouds,
                WeatherPreset.Overcast,
                WeatherPreset.Stormy,
                WeatherPreset.LightFog,
                WeatherPreset.HeavyFog
            };

            return AvailableWeatherPresets[Random.Range(0, AvailableWeatherPresets.Length)];
        }
    }

    protected WeatherPreset RandomWeatherPresetEasy
    {
        get
        {
            WeatherPreset[] AvailableWeatherPresets = new[]
            {
                WeatherPreset.Clear,
                WeatherPreset.FewClouds,
                WeatherPreset.ScatteredClouds,
                WeatherPreset.BrokenClouds,
                WeatherPreset.Overcast,
                WeatherPreset.LightFog,
            };

            return AvailableWeatherPresets[Random.Range(0, AvailableWeatherPresets.Length)];
        }
    }

    protected override void Start()
    {
        base.Start();

        GameObject obj = ServiceProvider.Instance.ResourceLoader.LoadGameObject(LevelGameObjectName);
        StopTargetTransform = obj.transform.GetChild(0);
        StopTargetTransform.localPosition = StopPositions[0];

        ClockDisplay = obj.GetComponentInChildren<Text>();

        ServiceProvider.Instance.EnvironmentManager.LengthOfDay = 1440;
        ServiceProvider.Instance.EnvironmentManager.TimeOfDay = StartTimeSeconds / 3600f;
        ServiceProvider.Instance.EnvironmentManager.UpdateWeather(Weather, 0f, true);

        Vector3 StartDirection = Quaternion.Euler(StartLocation.Rotation) * Vector3.forward;
        float LargestPositionOnStartDirection = float.MinValue;
        List<GameObject> AllParts = ServiceProvider.Instance.PlayerAircraft.Parts;
        foreach (GameObject g in AllParts)
        {
            float partPositionOnStartDirection = Vector3.Project(g.transform.position, StartDirection).z;
            if (partPositionOnStartDirection > LargestPositionOnStartDirection)
            {
                LargestPositionOnStartDirection = partPositionOnStartDirection;
                FrontPart = g;
            }
        }

        SignalManager = Object.FindObjectOfType<SignalManagerScript>();

        RepeatedMessage = StartRepeatedMessage;
        IsStopped = true;
        StopTimer = MinStopDurations[0];
    }

    protected override void OnLevelComplete()
    {
        base.OnLevelComplete();
        LevelCompleted = true;
    }

    protected override void Update()
    {
        base.Update();

        if (!LevelCompleted)
        {
            CurrentTimeSeconds = StartTimeSeconds + Time.timeSinceLevelLoad;
        }

        NextRepeatedMessageTimer -= Time.deltaTime;
        if (NextRepeatedMessageTimer <= 0)
        {
            NextRepeatedMessageTimer = RepeatedMessageInterval;

            if (!string.IsNullOrEmpty(RepeatedMessage))
            {
                ServiceProvider.Instance.GameWorld.ShowStatusMessage(RepeatedMessage, 0f);
            }
        }

        if (IsStopped)
        {
            StopTimer -= Time.deltaTime;

            // On departure allowed
            if (StopTimer <= 0 && CurrentTimeSeconds >= DepartureTimes[CurrentStop])
            {
                IsStopped = false;
                StopTimer = CountStopDuration;

                NextStop++;
                if (NextStop <= StopPositions.Length)
                {
                    StopTargetTransform.localPosition = StopPositions[NextStop];
                }

                RepeatedMessage = "";
                ServiceProvider.Instance.GameWorld.ShowStatusMessage(DepartSignalMessage, 5f);
            }

            if (ServiceProvider.Instance.PlayerAircraft.CriticallyDamaged)
            {
                EndLevel(false, TrainDamagedMessage, 0f);
            }

            if (Time.timeSinceLevelLoad > 5f && ServiceProvider.Instance.PlayerAircraft.Velocity.magnitude > CancelStopSpeed)
            {
                EndLevel(false, StartedWhileDoorsOpenMessage, 0f);
            }

            if (CurrentStop <= DepartureTimes.Length)
            {
                ClockDisplay.text = $"Now {FormatTime(CurrentTimeSeconds)}\nDep. {FormatTime(DepartureTimes[CurrentStop])}";
            }
            else
            {
                ClockDisplay.text = $"Now {FormatTime(CurrentTimeSeconds)}\nDep. --:--:--";
            }
        }
        else
        {
            Vector3 TrainFrontPosition = FrontPart.transform.position;
            Vector3 StopPosition = StopTargetTransform.position;
            TrainFrontPosition.y = StopPosition.y;
            Vector3 TrainToStopVector = StopPosition - TrainFrontPosition;

            float TrainHeading = ServiceProvider.Instance.PlayerAircraft.MainCockpitRotation.y;
            float StopPositionDistance = TrainToStopVector.magnitude;
            float StopPositionLongitudinal = TrainToStopVector.z * Mathf.Cos(TrainHeading * Mathf.Deg2Rad)
                + TrainToStopVector.x * Mathf.Sin(TrainHeading * Mathf.Deg2Rad);

            // debug message
            if (DebugDistance)
            {
                ServiceProvider.Instance.GameWorld.ShowStatusMessage(StopPositionLongitudinal.ToString("0.00") + " m");
            }

            if (ServiceProvider.Instance.PlayerAircraft.Velocity.magnitude < CountStopSpeed & StopPositionDistance < 100f)
            {
                if (Mathf.Abs(StopPositionLongitudinal) < AllowedStopDeviation)
                {
                    StopTimer -= Time.deltaTime;
                }
                else
                {
                    if (MinStopDurations[CurrentStop + 1] >= 0)
                    {
                        RepeatedMessage = IncorrectStopPositionRepeatedMessage;
                    }
                    else
                    {
                        ServiceProvider.Instance.GameWorld.ShowStatusMessage(StoppedAtPassingStationMessage, 5f);
                    }
                }
            }

            // On passing the station, when the service does not stop
            if (MinStopDurations[CurrentStop + 1] < 0 && StopPositionDistance < CountPassDistance)
            {
                StopTimer = CountStopDuration;

                CurrentStop++;
                NextStop++;
                if (NextStop <= StopPositions.Length)
                {
                    StopTargetTransform.localPosition = StopPositions[NextStop];
                }

                RepeatedMessage = "";
            }

            // On stop counted
            if (StopTimer <= 0 && MinStopDurations[CurrentStop + 1] >= 0)
            {
                IsStopped = true;

                CurrentStop++;
                StopTimer = MinStopDurations[CurrentStop];

                if (CurrentStop == StopPositions.Length - 1)
                {
                    EndLevel(true, SuccessMessage, 0f);
                }

                RepeatedMessage = OnArrivedRepeatedMessage;
            }

            if (NextStop < ArrivalTimes.Length)
            {
                ClockDisplay.text = $"Now {FormatTime(CurrentTimeSeconds)}\n{(MinStopDurations[CurrentStop + 1] >= 0 ? "Arr." : "Pass")} {FormatTime(ArrivalTimes[NextStop])}";
            }
            else
            {
                ClockDisplay.text = $"Now {FormatTime(CurrentTimeSeconds)}\nArr. --:--:--";
            }
        }

        // Signals
        if (SignalChangeProgress < SignalChanges.Length)
        {
            SignalSettings nextSetting = SignalChanges[SignalChangeProgress];

            if (CurrentTimeSeconds > nextSetting.TimeSeconds)
            {
                if (nextSetting.IsGroup)
                {
                    SignalManager.SetSignalGroupAspects(nextSetting.SignalName, nextSetting.Aspect);
                }
                else
                {
                    SignalManager.SetSignalAspect(nextSetting.SignalName, nextSetting.Aspect);
                }

                SignalChangeProgress++;
            }
        }
    }
}
