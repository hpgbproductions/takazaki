using Jundroo.SimplePlanes.ModTools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpressFreight2 : TrainLevelBase
{
    public static readonly string Name = "HTL - Express Freight 2";
    public static readonly string LevelMap = "HAMEKA Takazaki Line";
    public static readonly string LevelDescription =
@"Carry as much cargo as you can with a train of up to four cars. The speed limit is 65 km/h, increasing to 75 km/h past Akimidai.

In this scenario, the freight train trails behind a local passenger train. There is a technical stop at No. 1 Dam to check the brakes on your train. For the long downhill run after that station, use your engine brake or dynamic brake, if available on your train.

Back when the facility was in development, the company and expanding villages had construction materials delivered by train.

Freight 4 cars
11:40:00 [13] Takazaki
...
11:42:30 [10] Hanezawa
...
11:51:00 [08] Yoshimori-Kouen
11:54:30 [07] Ukimiya
12:02:00 [06] No.1 Dam
...
12:07:00 [04] Nakatsu
...
12:11:30 [02] Higashi-Okamura
12:18:00 [01] Umihara
(Latest arrival 12:25:00)

Duration: 38 minutes";
    public static readonly string LevelGameObjectName = "TrainLevelRoot";

    public ExpressFreight2()
        : base(Name, LevelMap, LevelDescription, LevelGameObjectName)
    {
    }

    protected override void Start()
    {
        base.Start();

        AllowedStopDeviation = 6f;
    }

    protected override void Update()
    {
        base.Update();

        if (NextStop == StopPositions.Length - 1)
        {
            AllowedStopDeviation = 3f;
        }
    }

    protected override LevelStartLocation StartLocation
    {
        get
        {
            return new LevelStartLocation
            {
                InitialSpeed = 0f,
                InitialThrottle = 0f,
                Position = new Vector3(907.718445f, 211.199997f, 6177.31348f),
                Rotation = new Vector3(0f, 315.67f, 0f),
                StartOnGround = true
            };
        }
    }

    protected override WeatherPreset Weather
    {
        get
        {
            return RandomWeatherPresetNormal;
        }
    }

    protected override float StartTimeSeconds
    {
        get
        {
            return Seconds(11, 39, 50);
        }
    }

    protected override int[] ArrivalTimes
    {
        get
        {
            return new[]
            {
                -1,

                Seconds(11, 42, 30),

                Seconds(11, 51, 00),
                Seconds(11, 54, 30),
                Seconds(12, 00, 00),

                Seconds(12, 07, 00),

                Seconds(12, 11, 30),
                Seconds(12, 15, 00)
            };
        }
    }

    protected override int[] DepartureTimes
    {
        get
        {
            return new[]
            {
                Seconds(11, 40, 00),

                -1,

                -1,
                -1,
                Seconds(12, 02, 00),

                -1,

                -1,
                -1
            };
        }
    }

    protected override int[] MinStopDurations
    {
        get
        {
            return new[] { 0, -1, -1, -1, 80, -1, -1, 0 };
        }
    }

    protected override Vector3[] StopPositions
    {
        get
        {
            return new[] {
                new Vector3(0, 0, 0),

                new Vector3(-1327.89917f, 192.500229f, 4406.11328f),    // Hanezawa depart 2

                new Vector3(-241.820007f, 201.330002f, 231.619995f),    // Kanemori-Kouen depart 1
                new Vector3(-430.37912f, 199.968994f, -4270.00635f),    // Ukimiya depart
                new Vector3(-1624.56592f, 198.600006f, -5162.40039f),

                new Vector3(-2632.72534f, 69.1399994f, -10903.0615f),   // Nakatsu depart

                new Vector3(-242.300003f, 41.7900009f, -13790.4004f),   // Higashi-Okamachi depart
                new Vector3(868.60791f, 33.2000046f, -13948.8887f)
            };
        }
    }

    protected override SignalSettings[] SignalChanges
    {
        get
        {
            return new[]
            {
                new SignalSettings(Seconds(00, 00, 00), SignalScript.Aspects.R, "northbound_plains", true),
                new SignalSettings(Seconds(00, 00, 00), SignalScript.Aspects.R, "northbound_lake", true),

                new SignalSettings(Seconds(00, 00, 00), SignalScript.Aspects.R, "southbound_lake/Takazaki depart 2"),
                new SignalSettings(Seconds(00, 00, 00), SignalScript.Aspects.R, "southbound_lake/Takazaki exit"),
                new SignalSettings(Seconds(00, 00, 00), SignalScript.Aspects.R, "southbound_lake/Hanezawa depart 2"),
                new SignalSettings(Seconds(00, 00, 00), SignalScript.Aspects.R, "southbound_lake/Kanemori-Kouen depart 1"),
                new SignalSettings(Seconds(00, 00, 00), SignalScript.Aspects.R, "southbound_lake/Ukimiya depart"),
                new SignalSettings(Seconds(00, 00, 00), SignalScript.Aspects.R, "southbound_lake/Dam depart 1"),
                new SignalSettings(Seconds(00, 00, 00), SignalScript.Aspects.R, "southbound_lake/Akimidai approach 3"),

                new SignalSettings(Seconds(00, 00, 00), SignalScript.Aspects.R, "southbound_plains/Nakatsu depart"),
                new SignalSettings(Seconds(00, 00, 00), SignalScript.Aspects.R, "southbound_plains/Higashi-Okamachi depart"),
                new SignalSettings(Seconds(00, 00, 00), SignalScript.Aspects.R, "southbound_plains/Umihara approach 3"),

                new SignalSettings(Seconds(11, 39, 59.6f), SignalScript.Aspects.G, "southbound_lake/Takazaki depart 2"),
                new SignalSettings(Seconds(11, 40, 00), SignalScript.Aspects.G, "southbound_lake/Takazaki exit"),
                new SignalSettings(Seconds(11, 42, 10) + Random.Range(0f, 10f), SignalScript.Aspects.G, "southbound_lake/Hanezawa depart 2"),
                new SignalSettings(Seconds(11, 50, 40) + Random.Range(0f, 10f), SignalScript.Aspects.G, "southbound_lake/Kanemori-Kouen depart 1"),
                new SignalSettings(Seconds(11, 54, 10) + Random.Range(0f, 10f), SignalScript.Aspects.G, "southbound_lake/Ukimiya depart"),
                new SignalSettings(Seconds(12, 01, 59), SignalScript.Aspects.G, "southbound_lake/Dam depart 1"),
                new SignalSettings(Seconds(12, 01, 59.5f), SignalScript.Aspects.G, "southbound_lake/Akimidai approach 3"),

                new SignalSettings(Seconds(12, 06, 42) + Random.Range(0f, 10f), SignalScript.Aspects.G, "southbound_plains/Nakatsu depart"),
                new SignalSettings(Seconds(12, 11, 15), SignalScript.Aspects.G, "southbound_plains/Higashi-Okamachi depart"),
                new SignalSettings(Seconds(12, 11, 15.5f), SignalScript.Aspects.G, "southbound_plains/Umihara approach 3"),
            };
        }
    }

    protected override string StoppedAtPassingStationMessage
    {
        get
        {
            return "Check the signal ahead and proceed when clear.";
        }
    }
}
