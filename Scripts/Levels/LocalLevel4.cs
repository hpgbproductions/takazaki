using Jundroo.SimplePlanes.ModTools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalNorthbound2 : TrainLevelBase
{
    public static readonly string Name = "HTL - Local Northbound 2";
    public static readonly string LevelMap = "HAMEKA Takazaki Line";
    public static readonly string LevelDescription =
@"Off-peak midday train service. Continue up the mountain, stopping in small villages, to reach the northern terminus which provides connections to a research facility and a hot spring town. The line speed limit is 85 km/h.

Local 1 car
12:50:00 [05] Akimidai
12:54:00 [06] No.1 Dam
12:56:30 [07] Ukimiya
13:03:00 [08] Yoshimori-Kouen
13:05:00 [09] Yoshimori
13:10:00 [10] Hanezawa
13:12:30 [11] Takigawa
13:14:30 [12] Haruchi
13:17:00 [13] Takazaki

Duration: 27 minutes";
    public static readonly string LevelGameObjectName = "TrainLevelRoot";

    public LocalNorthbound2()
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
                Position = new Vector3(-1362f, 158.899994f, -7181.60986f),
                Rotation = new Vector3(0f, 351.15f, 0f),
                StartOnGround = true
            };
        }
    }

    protected override float StartTimeSeconds
    {
        get
        {
            return Seconds(12, 49, 30);
        }
    }

    protected override int[] ArrivalTimes
    {
        get
        {
            return new[]
            {
                Seconds(12, 49, 15),
                Seconds(12, 53, 00),
                Seconds(12, 56, 00),
                Seconds(13, 02, 30),
                Seconds(13, 04, 30),
                Seconds(13, 09, 30),
                Seconds(13, 12, 00),
                Seconds(13, 14, 00),
                Seconds(13, 16, 30)
            };
        }
    }

    protected override int[] DepartureTimes
    {
        get
        {
            return new[]
            {
                Seconds(12, 50, 00),
                Seconds(12, 54, 00),
                Seconds(12, 56, 30),
                Seconds(13, 03, 00),
                Seconds(13, 05, 00),
                Seconds(13, 10, 00),
                Seconds(13, 12, 30),
                Seconds(13, 14, 30),
                -1
            };
        }
    }

    protected override int[] MinStopDurations
    {
        get
        {
            return new[] { 20, 40, 15, 15, 15, 15, 15, 15, 15 };
        }
    }

    protected override Vector3[] StopPositions
    {
        get
        {
            return new[] {
                new Vector3(-1353.25781f, 160.03717f, -7251.33398f),
                new Vector3(-1583.28003f, 198.520004f, -5095.83008f),
                new Vector3(-422.910004f, 199.619995f, -4205.1001f),
                new Vector3(-157.520004f, 201.110001f, 274.429993f),
                new Vector3(-170.748749f, 192.199997f, 843.730103f),
                new Vector3(-1285.17004f, 190.990005f, 4425.93994f),
                new Vector3(-919.258362f, 187.809998f, 5363.51025f),
                new Vector3(-317.692017f, 194.770004f, 5968.87939f),
                new Vector3(916.798462f, 212.479996f, 6166.94678f)
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

                new SignalSettings(Seconds(00, 00, 00), SignalScript.Aspects.R, "northbound_plains/Akimidai depart 2"),
                new SignalSettings(Seconds(00, 00, 00), SignalScript.Aspects.R, "northbound_lake/Dam depart 1"),
                new SignalSettings(Seconds(00, 00, 00), SignalScript.Aspects.R, "northbound_lake/Kanemori-Kouen depart 1"),
                new SignalSettings(Seconds(00, 00, 00), SignalScript.Aspects.R, "northbound_lake/Hanezawa depart 2"),
                new SignalSettings(Seconds(00, 00, 00), SignalScript.Aspects.R, "northbound_lake/Haruchi depart"),

                new SignalSettings(Seconds(12, 49, 22), SignalScript.Aspects.G, "northbound_plains/Akimidai depart 2"),
                new SignalSettings(Seconds(12, 53, 50), SignalScript.Aspects.G, "northbound_lake/Dam depart 1"),
                new SignalSettings(Seconds(13, 02, 21), SignalScript.Aspects.G, "northbound_lake/Kanemori-Kouen depart 1"),
                new SignalSettings(Seconds(13, 09, 22), SignalScript.Aspects.G, "northbound_lake/Hanezawa depart 2"),
                new SignalSettings(Seconds(13, 13, 40), SignalScript.Aspects.G, "northbound_lake/Haruchi depart")
            };
        }
    }
}
