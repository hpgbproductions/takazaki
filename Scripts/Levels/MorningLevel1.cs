using Jundroo.SimplePlanes.ModTools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalMorning1 : TrainLevelBase
{
    public static readonly string Name = "HTL - Local Morning 1";
    public static readonly string LevelMap = "HAMEKA Takazaki Line";
    public static readonly string LevelDescription =
@"The first northbound train of the day. Get through the early morning fog as it slowly makes way for the rising sun.

Local 2 cars
05:05:00 [01] Umihara
05:08:00 [02] Higashi-Okamura
05:10:00 [03] Okamura
05:13:30 [04] Nakatsu
05:20:00 [05] Akimidai
05:24:00 [06] No.1 Dam
05:26:30 [07] Ukimiya
05:33:00 [08] Yoshimori-Kouen
05:35:00 [09] Yoshimori
05:40:00 [10] Hanezawa
05:42:30 [11] Takigawa
05:44:30 [12] Haruchi
05:47:00 [13] Takazaki

Duration: 42 minutes";
    public static readonly string LevelGameObjectName = "TrainLevelRoot";

    public LocalMorning1()
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

    private int WeatherStage = 0;

    protected override WeatherPreset Weather
    {
        get
        {
            return WeatherPreset.LightFog;
        }
    }

    protected override void Update()
    {
        base.Update();

        if (WeatherStage == 0 && CurrentTimeSeconds > Seconds(05, 11, 00))
        {
            ServiceProvider.Instance.EnvironmentManager.UpdateWeather(WeatherPreset.FewClouds, Seconds(00, 22, 00), false);
            WeatherStage = 1;
        }
    }

    protected override float StartTimeSeconds
    {
        get
        {
            return Seconds(05, 04, 30);
        }
    }

    protected override int[] ArrivalTimes
    {
        get
        {
            return new[]
            {
                -1,
                Seconds(05, 07, 30),
                Seconds(05, 09, 30),
                Seconds(05, 13, 00),
                Seconds(05, 19, 15),
                Seconds(05, 22, 30),
                Seconds(05, 26, 00),
                Seconds(05, 32, 30),
                Seconds(05, 34, 30),
                Seconds(05, 39, 30),
                Seconds(05, 42, 00),
                Seconds(05, 44, 00),
                Seconds(05, 46, 30)
            };
        }
    }

    protected override int[] DepartureTimes
    {
        get
        {
            return new[]
            {
                Seconds(05, 05, 00),
                Seconds(05, 08, 00),
                Seconds(05, 10, 00),
                Seconds(05, 13, 30),
                Seconds(05, 20, 00),
                Seconds(05, 24, 00),
                Seconds(05, 26, 30),
                Seconds(05, 33, 00),
                Seconds(05, 35, 00),
                Seconds(05, 40, 00),
                Seconds(05, 42, 30),
                Seconds(05, 44, 30),
                Seconds(06, 00, 00)
            };
        }
    }

    protected override int[] MinStopDurations
    {
        get
        {
            return new[] { 20, 20, 20, 20, 30, 60, 20, 15, 20, 25, 15, 15, 60 };
        }
    }

    protected override Vector3[] StopPositions
    {
        get
        {
            return new[] {
                new Vector3(0, 0, 0),
                new Vector3(-324.48999f, 41.5200005f, -13685.8096f),
                new Vector3(-867.55481f, 40.1500015f, -12966.5049f),
                new Vector3(-2661.64624f, 69.5196991f, -10850.1836f),
                new Vector3(-1354.21704f, 160.03717f, -7231.51318f),    // aki
                new Vector3(-1583.28003f, 198.520004f, -5095.83008f),
                new Vector3(-422.910004f, 199.619995f, -4205.1001f),
                new Vector3(-157.520004f, 201.110001f, 274.429993f),
                new Vector3(-175.560989f, 192.199997f, 852.496094f),
                new Vector3(-1266.83997f, 190.990005f, 4433.93994f),    // hane
                new Vector3(-905.610229f, 187.699997f, 5378.13379f),
                new Vector3(-309.51236f, 194.770004f, 5974.63232f),
                new Vector3(930.746887f, 212.479996f, 6152.61328f)
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
                new SignalSettings(Seconds(00, 00, 00), SignalScript.Aspects.R, "northbound_lake/Dam depart 1"),
                new SignalSettings(Seconds(00, 00, 00), SignalScript.Aspects.R, "northbound_lake/Kanemori-Kouen depart 1"),
                new SignalSettings(Seconds(00, 00, 00), SignalScript.Aspects.R, "northbound_lake/Hanezawa depart 2"),
                new SignalSettings(Seconds(00, 00, 00), SignalScript.Aspects.R, "northbound_lake/Haruchi depart"),

                new SignalSettings(Seconds(05, 04, 48), SignalScript.Aspects.G, "northbound_plains/Umihara depart 1"),
                new SignalSettings(Seconds(05, 19, 40), SignalScript.Aspects.G, "northbound_plains/Akimidai depart 2"),
                new SignalSettings(Seconds(05, 23, 47), SignalScript.Aspects.G, "northbound_lake/Dam depart 1"),
                new SignalSettings(Seconds(05, 32, 21), SignalScript.Aspects.G, "northbound_lake/Kanemori-Kouen depart 1"),
                new SignalSettings(Seconds(05, 39, 19), SignalScript.Aspects.G, "northbound_lake/Hanezawa depart 2"),
                new SignalSettings(Seconds(05, 43, 45), SignalScript.Aspects.G, "northbound_lake/Haruchi depart")
            };
        }
    }
}
