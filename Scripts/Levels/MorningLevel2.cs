using Jundroo.SimplePlanes.ModTools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalMorning2 : TrainLevelBase
{
    public static readonly string Name = "HTL - Local Morning 2";
    public static readonly string LevelMap = "HAMEKA Takazaki Line";
    public static readonly string LevelDescription =
@"Southbound commuter train. The Okamachi area provides transfers to the Nippon Railway main line, so punctuality is critical.

Local 2 cars
06:00:00 [13] Takazaki
06:02:30 [12] Haruchi
06:04:30 [11] Takigawa
06:07:00 [10] Hanezawa
06:12:00 [09] Kanemori
06:14:00 [08] Kanemori Park
06:20:30 [07] Ukimiya
06:24:00 [06] No.1 Dam
06:27:00 [05] Akimidai
06:33:00 [04] Nakatsu
06:36:30 [03] Okamachi
06:38:30 [02] Higashi-Okamachi
06:41:00 [01] Umihara

Duration: 41 minutes";
    public static readonly string LevelGameObjectName = "TrainLevelRoot";

    public LocalMorning2()
        : base(Name, LevelMap, LevelDescription, LevelGameObjectName)
    {
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

    private int WeatherStage = 0;

    protected override WeatherPreset Weather
    {
        get
        {
            return WeatherPreset.FewClouds;
        }
    }

    protected override void Update()
    {
        base.Update();

        if (WeatherStage == 0 && CurrentTimeSeconds > Seconds(06, 01, 00))
        {
            ServiceProvider.Instance.EnvironmentManager.UpdateWeather(WeatherPreset.ScatteredClouds, Seconds(00, 30, 00), false);
            WeatherStage = 1;
        }
    }

    protected override float StartTimeSeconds
    {
        get
        {
            return Seconds(05, 59, 30);
        }
    }

    protected override int[] ArrivalTimes
    {
        get
        {
            return new[]
            {
                Seconds(05, 44, 00),
                Seconds(06, 02, 00),
                Seconds(06, 04, 00),
                Seconds(06, 06, 30),    // hane
                Seconds(06, 11, 30),
                Seconds(06, 13, 30),
                Seconds(06, 20, 00),
                Seconds(06, 22, 45),
                Seconds(06, 26, 30),    // aki
                Seconds(06, 32, 30),
                Seconds(06, 36, 00),
                Seconds(06, 38, 00),
                Seconds(06, 41, 00)
            };
        }
    }

    protected override int[] DepartureTimes
    {
        get
        {
            return new[]
            {
                Seconds(06, 00, 00),
                Seconds(06, 02, 30),
                Seconds(06, 04, 30),
                Seconds(06, 07, 00),    // hane
                Seconds(06, 12, 00),
                Seconds(06, 14, 00),
                Seconds(06, 20, 30),
                Seconds(06, 24, 00),
                Seconds(06, 27, 00),    // aki
                Seconds(06, 33, 00),
                Seconds(06, 36, 30),
                Seconds(06, 38, 30),
                Seconds(06, 55, 00)
            };
        }
    }

    protected override int[] MinStopDurations
    {
        get
        {
            return new[] { 20, 20, 20, 25, 25, 25, 25, 60, 25, 20, 25, 25, 20 };
        }
    }

    protected override Vector3[] StopPositions
    {
        get
        {
            return new[] {
                new Vector3(0, 0, 0),
                new Vector3(-346.30658f, 194.770004f, 5948.72412f),
                new Vector3(-932.809998f, 187.869995f, 5348.7998f),
                new Vector3(-1303.62f, 190.990005f, 4418.20996f),       // hane
                new Vector3(-156.311981f, 192.199997f, 817.43219f),
                new Vector3(-193.947769f, 201.110001f, 257.951508f),
                new Vector3(-429.477814f, 199.619995f, -4244.55713f),
                new Vector3(-1608.5238f, 198.600006f, -5125.24365f),
                new Vector3(-1354.23999f, 160.03717f, -7271.31006f),    // aki
                new Vector3(-2643.52002f, 69.5196991f, -10885.8496f),
                new Vector3(-842.529602f, 39.2400017f, -12997.709f),
                new Vector3(-300.574005f, 41.5200005f, -13717.8721f),
                new Vector3(829.299988f, 33.2000046f, -13941.4805f)
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
                new SignalSettings(Seconds(00, 00, 00), SignalScript.Aspects.R, "southbound_lake/Dam depart 1"),
                new SignalSettings(Seconds(00, 00, 00), SignalScript.Aspects.R, "southbound_lake/Akimidai approach 3"),
                new SignalSettings(Seconds(00, 00, 00), SignalScript.Aspects.R, "southbound_plains/Akimidai depart 2"),
                new SignalSettings(Seconds(00, 00, 00), SignalScript.Aspects.R, "southbound_plains/Higashi-Okamachi depart"),
                new SignalSettings(Seconds(00, 00, 00), SignalScript.Aspects.R, "southbound_plains/Umihara approach 3"),

                new SignalSettings(Seconds(05, 59, 50), SignalScript.Aspects.G, "southbound_lake/Takazaki depart 2"),
                new SignalSettings(Seconds(05, 59, 50.7f), SignalScript.Aspects.G, "southbound_lake/Takazaki exit"),
                new SignalSettings(Seconds(06, 06, 33), SignalScript.Aspects.G, "southbound_lake/Hanezawa depart 2"),
                new SignalSettings(Seconds(06, 13, 23), SignalScript.Aspects.G, "southbound_lake/Kanemori-Kouen depart 1"),
                new SignalSettings(Seconds(06, 23, 45), SignalScript.Aspects.G, "southbound_lake/Dam depart 1"),
                new SignalSettings(Seconds(06, 23, 45.4f), SignalScript.Aspects.G, "southbound_lake/Akimidai approach 3"),
                new SignalSettings(Seconds(06, 26, 50), SignalScript.Aspects.G, "southbound_plains/Akimidai depart 2"),
                new SignalSettings(Seconds(06, 38, 19), SignalScript.Aspects.G, "southbound_plains/Higashi-Okamachi depart"),
                new SignalSettings(Seconds(06, 38, 19.5f), SignalScript.Aspects.G, "southbound_plains/Umihara approach 3"),
            };
        }
    }
}
