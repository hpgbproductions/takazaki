using Jundroo.SimplePlanes.ModTools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalNorthbound1 : TrainLevelBase
{
    public static readonly string Name = "HTL - Local Northbound 1";
    public static readonly string LevelMap = "HAMEKA Takazaki Line";
    public static readonly string LevelDescription =
@"Off-peak midday train service. Depart from the southern terminus and stop before the Yamagawako tunnel. The line speed limit is 95 km/h.

Local 1 car
12:35:00 [01] Umihara
12:38:00 [02] Higashi-Okamachi
12:40:00 [03] Okamachi
12:43:30 [04] Nakatsu
12:49:30 [05] Akimidai

Duration: 14 minutes";
    public static readonly string LevelGameObjectName = "TrainLevelRoot";

    public LocalNorthbound1()
        : base(Name, LevelMap, LevelDescription, LevelGameObjectName)
    {
    }

    protected override WeatherPreset Weather
    {
        get
        {
            return RandomWeatherPresetEasy;
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
                //Position = new Vector3(832f, 32f, -13942.3496f),
                Position = new Vector3(820.208618f, 32, -13940.1221f),
                Rotation = new Vector3(0f, -79.3f, 0f),
                StartOnGround = true
            };
        }
    }

    protected override float StartTimeSeconds
    {
        get
        {
            return Seconds(12, 34, 30);
        }
    }

    protected override int[] ArrivalTimes
    {
        get
        {
            return new[]
            {
                -1,
                Seconds(12, 37, 30),
                Seconds(12, 39, 30),
                Seconds(12, 43, 00),
                Seconds(12, 49, 00)
            };
        }
    }

    protected override int[] DepartureTimes
    {
        get
        {
            return new[]
            {
                Seconds(12, 35, 00),
                Seconds(12, 38, 00),
                Seconds(12, 40, 00),
                Seconds(12, 43, 30),
                Seconds(12, 49, 30)
            };
        }
    }

    protected override int[] MinStopDurations
    {
        get
        {
            return new[] { 20, 20, 20, 20, 20 };
        }
    }

    protected override Vector3[] StopPositions
    {
        get
        {
            return new[] {
                new Vector3(0, 0, 0),
                new Vector3(-324.48999f, 41.5200005f, -13685.8096f),
                new Vector3(-855.042175f, 39.7900009f, -12982.1074f),
                new Vector3(-2652.93604f, 69.5196991f, -10868.2051f),
                new Vector3(-1353.25781f, 160.03717f, -7251.33398f)
            };
        }
    }

    protected override SignalSettings[] SignalChanges
    {
        get
        {
            return new[]
            {
                new SignalSettings(Seconds(00, 00, 00), SignalScript.Aspects.R, "southbound_plains", true),
                new SignalSettings(Seconds(00, 00, 00), SignalScript.Aspects.R, "southbound_lake", true),

                new SignalSettings(Seconds(00, 00, 00), SignalScript.Aspects.R, "northbound_plains/Umihara depart 1"),
                new SignalSettings(Seconds(00, 00, 00), SignalScript.Aspects.R, "northbound_plains/Akimidai depart 2"),

                new SignalSettings(Seconds(12, 34, 50), SignalScript.Aspects.G, "northbound_plains/Umihara depart 1")
            };
        }
    }
}
