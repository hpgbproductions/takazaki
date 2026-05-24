using Jundroo.SimplePlanes.ModTools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalSouthbound2 : TrainLevelBase
{
    public static readonly string Name = "HTL - Local Southbound 2";
    public static readonly string LevelMap = "HAMEKA Takazaki Line";
    public static readonly string LevelDescription =
@"Off-peak midday train service. Complete the steep descent and enter the fields at the foot of the mountain. The line speed limit is 95 km/h.

Local 1 car
12:57:00 [05] Akimidai
13:03:00 [04] Nakatsu
13:06:30 [03] Okamachi
13:08:30 [02] Higashi-Okamachi
13:11:00 [01] Umihara

Duration: 14 minutes";
    public static readonly string LevelGameObjectName = "TrainLevelRoot";

    public LocalSouthbound2()
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
                Position = new Vector3(-1362f, 158.899994f, -7181.60986f),
                Rotation = new Vector3(0f, 171.15f, 0f),
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
            return Seconds(12, 56, 30);
        }
    }

    protected override int[] ArrivalTimes
    {
        get
        {
            return new[]
            {
                Seconds(12, 56, 30),
                Seconds(13, 02, 30),
                Seconds(13, 06, 00),
                Seconds(13, 08, 00),
                Seconds(13, 11, 00)
            };
        }
    }

    protected override int[] DepartureTimes
    {
        get
        {
            return new[]
            {
                Seconds(12, 57, 00),
                Seconds(13, 03, 00),
                Seconds(13, 06, 30),
                Seconds(13, 08, 30),
                -1
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
                new Vector3(-1354.23999f, 160.03717f, -7271.31006f),
                new Vector3(-2643.52002f, 69.5196991f, -10885.8496f),
                new Vector3(-842.529602f, 39.2400017f, -12997.709f),
                new Vector3(-312.532013f, 41.5200005f, -13701.8408f),
                new Vector3(819.473022f, 33.2000046f, -13939.6279f)
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

                new SignalSettings(Seconds(00, 00, 00), SignalScript.Aspects.R, "southbound_plains/Akimidai depart 2"),
                new SignalSettings(Seconds(00, 00, 00), SignalScript.Aspects.R, "southbound_plains/Higashi-Okamachi depart"),
                new SignalSettings(Seconds(00, 00, 00), SignalScript.Aspects.R, "southbound_plains/Umihara approach 3"),

                new SignalSettings(Seconds(12, 56, 50), SignalScript.Aspects.G, "southbound_plains/Akimidai depart 2"),
                new SignalSettings(Seconds(13, 08, 19), SignalScript.Aspects.G, "southbound_plains/Higashi-Okamachi depart"),
                new SignalSettings(Seconds(13, 08, 19.2f), SignalScript.Aspects.G, "southbound_plains/Umihara approach 3"),
            };
        }
    }
}
