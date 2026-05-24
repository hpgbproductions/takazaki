using Jundroo.SimplePlanes.ModTools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalSouthbound1 : TrainLevelBase
{
    public static readonly string Name = "HTL - Local Southbound 1";
    public static readonly string LevelMap = "HAMEKA Takazaki Line";
    public static readonly string LevelDescription =
@"Off-peak midday train service. Navigate the twisty reservoir section with views of the two dams. The line speed limit is 85 km/h.

Local 1 car
12:30:00 [13] Takazaki
12:32:30 [12] Haruchi
12:34:30 [11] Takigawa
12:37:00 [10] Hanezawa
12:42:00 [09] Kanemori
12:44:00 [08] Kanemori Park
12:50:30 [07] Ukimiya
12:54:00 [06] No.1 Dam
12:57:00 [05] Akimidai

Duration: 27 minutes";
    public static readonly string LevelGameObjectName = "TrainLevelRoot";

    public LocalSouthbound1()
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
                Position = new Vector3(907.718445f, 211.199997f, 6177.31348f),
                Rotation = new Vector3(0f, 315.67f, 0f),
                StartOnGround = true
            };
        }
    }

    protected override float StartTimeSeconds
    {
        get
        {
            return Seconds(12, 29, 30);
        }
    }

    protected override int[] ArrivalTimes
    {
        get
        {
            return new[]
            {
                -1,
                Seconds(12, 32, 00),
                Seconds(12, 34, 00),
                Seconds(12, 36, 30),
                Seconds(12, 41, 30),
                Seconds(12, 43, 30),
                Seconds(12, 50, 00),
                Seconds(12, 52, 45),
                Seconds(12, 56, 30),
            };
        }
    }

    protected override int[] DepartureTimes
    {
        get
        {
            return new[]
            {
                Seconds(12, 30, 00),
                Seconds(12, 32, 30),
                Seconds(12, 34, 30),
                Seconds(12, 37, 00),
                Seconds(12, 42, 00),
                Seconds(12, 44, 00),
                Seconds(12, 50, 30),
                Seconds(12, 54, 00),
                Seconds(12, 57, 00),
            };
        }
    }

    protected override int[] MinStopDurations
    {
        get
        {
            return new[] { 0, 15, 15, 20, 15, 15, 15, 60, 20 };
        }
    }

    protected override Vector3[] StopPositions
    {
        get
        {
            return new[] {
                new Vector3(0, 0, 0),
                new Vector3(-338.14978f, 194.770004f, 5954.50977f),
                new Vector3(-932.809998f, 187.869995f, 5348.7998f),
                new Vector3(-1303.62f, 190.990005f, 4418.20996f),
                new Vector3(-161.124237f, 192.199997f, 826.198181f),
                new Vector3(-175.813766f, 201.110001f, 266.346771f),
                new Vector3(-426.193909f, 199.619995f, -4224.82861f),
                new Vector3(-1598.03857f, 198.520004f, -5109.45117f),
                new Vector3(-1354.23999f, 160.03717f, -7271.31006f)
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

                new SignalSettings(Seconds(12, 29, 47), SignalScript.Aspects.G, "southbound_lake/Takazaki depart 2"),
                new SignalSettings(Seconds(12, 29, 47.7f), SignalScript.Aspects.G, "southbound_lake/Takazaki exit"),
                new SignalSettings(Seconds(12, 36, 33), SignalScript.Aspects.G, "southbound_lake/Hanezawa depart 2"),
                new SignalSettings(Seconds(12, 43, 23), SignalScript.Aspects.G, "southbound_lake/Kanemori-Kouen depart 1"),
                new SignalSettings(Seconds(12, 53, 45), SignalScript.Aspects.G, "southbound_lake/Dam depart 1"),
                new SignalSettings(Seconds(12, 53, 45.4f), SignalScript.Aspects.G, "southbound_lake/Akimidai approach 3")
            };
        }
    }
}
