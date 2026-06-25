using Jundroo.SimplePlanes.ModTools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringLevel1 : TrainLevelBase
{
    public static readonly string Name = "HTL - Spring Sprinter 1";
    public static readonly string LevelMap = "HAMEKA Takazaki Line";
    public static readonly string LevelDescription =
@"Pick up passengers from Okamachi and transport them to the area's sakura-viewing spots.

The Spring Sprinter is a seasonal express service. It operates the same multiple-unit cars as regular services.

Express 2 cars
09:38:00 [01] Umihara
...
09:43:00 [03] Okamura
...
09:53:00 [06] No.1 Dam (pass)
...
10:03:00 [09] Yoshimori
...
10:11:00 [12] Haruchi
10:14:00 [13] Takazaki

Duration: 36 minutes";
    public static readonly string LevelGameObjectName = "TrainLevelRoot";

    public SpringLevel1()
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
                Position = new Vector3(802.521606f, 32f, -13936.7793f),
                Rotation = new Vector3(0f, -79.3f, 0f),
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
            return Seconds(09, 37, 30);
        }
    }

    protected override int[] ArrivalTimes
    {
        get
        {
            return new[]
            {
                -1,
                Seconds(09, 41, 30),
                Seconds(09, 53, 00),
                Seconds(10, 02, 00),

                Seconds(10, 10, 00),
                Seconds(10, 14, 00),
            };
        }
    }

    protected override int[] DepartureTimes
    {
        get
        {
            return new[]
            {
                Seconds(09, 38, 00),
                Seconds(09, 43, 00),
                -1,
                Seconds(10, 03, 00),

                Seconds(10, 11, 00),
                -1
            };
        }
    }

    protected override int[] MinStopDurations
    {
        get
        {
            return new[] { 0, 75, -1, 45, 55, 45 };
        }
    }

    protected override Vector3[] StopPositions
    {
        get
        {
            return new[] {
                new Vector3(0, 0, 0),
                new Vector3(-867.55481f, 40.1500015f, -12966.5049f),    // oka
                new Vector3(-1583.28003f, 198.520004f, -5095.83008f),   // dam
                new Vector3(-175.560989f, 192.199997f, 852.496094f),    // kane

                new Vector3(-309.51236f, 194.770004f, 5974.63232f),     // haru
                new Vector3(930.746887f, 212.479996f, 6152.61328f)      // taka
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
                new SignalSettings(Seconds(00, 00, 00), SignalScript.Aspects.R, "northbound_lake/Dam depart 1"),
                new SignalSettings(Seconds(00, 00, 00), SignalScript.Aspects.R, "northbound_lake/Haruchi depart"),

                new SignalSettings(Seconds(09, 36, 50), SignalScript.Aspects.G, "northbound_plains/Umihara depart 1"),
                new SignalSettings(Seconds(09, 52, 49), SignalScript.Aspects.G, "northbound_lake/Dam depart 1"),
                new SignalSettings(Seconds(10, 10, 50), SignalScript.Aspects.G, "northbound_lake/Haruchi depart")
            };
        }
    }
}
