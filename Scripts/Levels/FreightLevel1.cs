using Jundroo.SimplePlanes.ModTools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpressFreight1 : TrainLevelBase
{
    public static readonly string Name = "HTL - Express Freight 1";
    public static readonly string LevelMap = "HAMEKA Takazaki Line";
    public static readonly string LevelDescription =
@"Carry as much cargo as you can with a train of up to four cars. The speed limit is 65 km/h.

In this scenario, the freight train trails behind a local passenger train. You may pass all intermediate stations if signals permit.

On this line, signals are typically cleared when the train in front departs from the next station. The timetable denotes the earliest time which allows you to pass a station with slowing down. Time your arrivals to avoid having to stop before a climb.

Despite the small size of the research facility, freight trains are occasionally used as the roads in the area are too narrow for big trucks.

Freight 4 cars
10:45:00 [01] Umihara
...
10:50:30 [04] Nakatsu
10:54:30 [05] Akimidai
10:57:00 [06] No.1 Dam
11:03:30 [07] Ukimiya
...
11:10:30 [09] Kanemori
11:15:30 [10] Hanezawa
...
11:17:45 [12] Haruchi
11:21:00 [13] Takazaki
(Latest arrival 11:25:00)

Duration: 36 minutes";
    public static readonly string LevelGameObjectName = "TrainLevelRoot";

    public ExpressFreight1()
        : base(Name, LevelMap, LevelDescription, LevelGameObjectName)
    {
    }

    protected override void Start()
    {
        base.Start();

        AllowedStopDeviation = 6f;
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
            return RandomWeatherPresetNormal;
        }
    }

    protected override float StartTimeSeconds
    {
        get
        {
            return Seconds(10, 44, 50);
        }
    }

    protected override int[] ArrivalTimes
    {
        get
        {
            return new[]
            {
                -1,

                Seconds(10, 50, 30),
                Seconds(10, 54, 30),
                Seconds(10, 57, 00),
                Seconds(11, 03, 30),

                Seconds(11, 10, 30),
                Seconds(11, 15, 30),

                Seconds(11, 17, 45),
                Seconds(11, 25, 00)
            };
        }
    }

    protected override int[] DepartureTimes
    {
        get
        {
            return new[]
            {
                Seconds(10, 45, 00),
                -1,
                -1,
                -1,
                -1,
                -1,
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
            return new[] { 0, -1, -1, -1, -1, -1, -1, -1, 0 };
        }
    }

    protected override Vector3[] StopPositions
    {
        get
        {
            return new[] {
                new Vector3(0, 0, 0),

                new Vector3(-2673.58398f, 69.5196991f, -10813.9014f),   // Nakatsu depart
                new Vector3(-1365.30298f, 160.279999f, -7144.59717f),   // Akimidai depart 2
                new Vector3(-1576.48999f, 199.117004f, -5085.6001f),    // Dam depart 1
                new Vector3(-415.720001f, 200.610001f, -4154.77002f),   // Ukimiya depart

                new Vector3(-201.444f, 191.869995f, 890.695984f),       // Kanemori depart
                new Vector3(-1209.04492f, 192.990005f, 4455.04932f),    // Hanezawa depart 2

                new Vector3(-284.091675f, 195.027496f, 5996.68359f),    // Haruchi depart
                new Vector3(958.643799f, 212.479996f, 6123.94678f),
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
                new SignalSettings(Seconds(00, 00, 00), SignalScript.Aspects.R, "northbound_plains/Nakatsu depart"),
                new SignalSettings(Seconds(00, 00, 00), SignalScript.Aspects.R, "northbound_plains/Akimidai depart 2"),
                new SignalSettings(Seconds(00, 00, 00), SignalScript.Aspects.R, "northbound_lake/Dam depart 1"),
                new SignalSettings(Seconds(00, 00, 00), SignalScript.Aspects.R, "northbound_lake/Ukimiya depart"),

                new SignalSettings(Seconds(00, 00, 00), SignalScript.Aspects.R, "northbound_lake/Kanemori depart"),
                new SignalSettings(Seconds(00, 00, 00), SignalScript.Aspects.R, "northbound_lake/Hanezawa depart 2"),
                new SignalSettings(Seconds(00, 00, 00), SignalScript.Aspects.R, "northbound_lake/Haruchi depart"),

                new SignalSettings(Seconds(10, 45, 00), SignalScript.Aspects.G, "northbound_plains/Umihara depart 1"),
                new SignalSettings(Seconds(10, 50, 15), SignalScript.Aspects.G, "northbound_plains/Nakatsu depart"),
                new SignalSettings(Seconds(10, 54, 15), SignalScript.Aspects.G, "northbound_plains/Akimidai depart 2"),
                new SignalSettings(Seconds(10, 56, 45), SignalScript.Aspects.G, "northbound_lake/Dam depart 1"),
                new SignalSettings(Seconds(11, 03, 15), SignalScript.Aspects.G, "northbound_lake/Ukimiya depart"),

                new SignalSettings(Seconds(11, 10, 15), SignalScript.Aspects.G, "northbound_lake/Kanemori depart"),
                new SignalSettings(Seconds(11, 15, 15), SignalScript.Aspects.G, "northbound_lake/Hanezawa depart 2"),
                new SignalSettings(Seconds(11, 17, 30), SignalScript.Aspects.G, "northbound_lake/Haruchi depart"),
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
