using Jundroo.SimplePlanes.ModTools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringLevel2 : TrainLevelBase
{
    public static readonly string Name = "HTL - Spring Sprinter 2";
    public static readonly string LevelMap = "HAMEKA Takazaki Line";
    public static readonly string LevelDescription =
@"Transport visitors back to Okamachi and Umihara.

The floating garden is maintained by locals and the mysterious creations of the old company.

Express 2 cars
10:33:00 [13] Takazaki
10:37:00 [12] Haruchi
...
10:45:00 [09] Kanemori
...
10:53:00 [06] No.1 Dam (pass)
...
11:04:00 [03] Okamachi
...
11:08:00 [01] Umihara

Duration: 35 minutes";
    public static readonly string LevelGameObjectName = "TrainLevelRoot";

    public SpringLevel2()
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

    protected override WeatherPreset Weather
    {
        get
        {
            return RandomWeatherPresetEasy;
        }
    }

    protected override float StartTimeSeconds
    {
        get
        {
            return Seconds(10, 32, 30);
        }
    }

    protected override int[] ArrivalTimes
    {
        get
        {
            return new[]
            {
                -1,
                Seconds(10, 35, 30),
                Seconds(10, 44, 00),
                Seconds(10, 53, 00),
                Seconds(11, 03, 00),
                Seconds(11, 08, 00),
            };
        }
    }

    protected override int[] DepartureTimes
    {
        get
        {
            return new[]
            {
                Seconds(10, 33, 00),    // taka
                Seconds(10, 37, 00),    // haru
                Seconds(10, 45, 00),    // kane
                -1,                     // dam
                Seconds(11, 04, 00),    // oka
                -1                      // umi
            };
        }
    }

    protected override int[] MinStopDurations
    {
        get
        {
            return new[] { 0, 65, 45, -1, 55, 45 };
        }
    }

    protected override Vector3[] StopPositions
    {
        get
        {
            return new[] {
                new Vector3(0, 0, 0),
                new Vector3(-346.30658f, 194.770004f, 5948.72412f),     // haru
                new Vector3(-156.311981f, 192.199997f, 817.43219f),     // kane
                new Vector3(-1608.5238f, 198.600006f, -5125.24365f),    // dam
                new Vector3(-842.529602f, 39.2400017f, -12997.709f),    // oka
                new Vector3(829.299988f, 33.2000046f, -13941.4805f)     // umi
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
                new SignalSettings(Seconds(00, 00, 00), SignalScript.Aspects.R, "southbound_lake/Dam depart 1"),
                new SignalSettings(Seconds(00, 00, 00), SignalScript.Aspects.R, "southbound_lake/Akimidai approach 3"),
                new SignalSettings(Seconds(00, 00, 00), SignalScript.Aspects.R, "southbound_plains/Higashi-Okamachi depart"),
                new SignalSettings(Seconds(00, 00, 00), SignalScript.Aspects.R, "southbound_plains/Umihara approach 3"),

                new SignalSettings(Seconds(10, 30, 45), SignalScript.Aspects.G, "southbound_lake/Takazaki depart 2"),
                new SignalSettings(Seconds(10, 30, 46), SignalScript.Aspects.G, "southbound_lake/Takazaki exit"),
                new SignalSettings(Seconds(10, 52, 46), SignalScript.Aspects.G, "southbound_lake/Dam depart 1"),
                new SignalSettings(Seconds(10, 52, 46.6f), SignalScript.Aspects.G, "southbound_lake/Akimidai approach 3"),
                new SignalSettings(Seconds(11, 02, 04.3f), SignalScript.Aspects.G, "southbound_plains/Higashi-Okamachi depart"),
                new SignalSettings(Seconds(11, 02, 05.1f), SignalScript.Aspects.G, "southbound_plains/Umihara approach 3"),
            };
        }
    }
}
