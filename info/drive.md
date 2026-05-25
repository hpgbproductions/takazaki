# Driving Walkthrough

*...or drive-through?*

This guide will cover general information and driving tips for the HAMEKA Takazaki Line. Then, there will be a written section-by-section guide for driving in the northerly direction. Relevant design considerations will be discussed. Some details about southbound driving will be mentioned, but route discovery is mostly left as an exercise for the reader.

## General Information

### Line Information

The HAMEKA Takazaki Line is a roughly 40 kilometer-long mountainous conventional rail line. It serves as a branch line that connects a biotechnology research facility and multiple villages to the national railway line. Along the way, it climbs more than 160 meters from the coastal plains to a lake formed by two dams. The population around the lake is about 500, and is mainly located at Takazaki, Kanemori, and Ukimiya.

With a maximum gradient of 35‰ and a minimum corner radius of 80 m, the line will thoroughly test your train's engines, brakes, and frame. What it doesn't test, however, is memorization, since the line was deliberately designed to be easy to learn by using natural speed limit progressions and visual landmarks.

The station list is shown below:

| | No. | JA | EN | Remarks |
|:---:|:---:|:--- |:--- |:--- |
| ∨ | 13 | 高崎 | Takazaki | Spawn point (100 m trains). Has depot.
| \| | 12 | 春池 | Haruchi |
| \| | 11 | 滝川 | Takigawa |
| ◇ | 10 | 羽沢 | Hanesawa | Spawn point (80 m trains).
| \| | 09 | 金森 | Kanemori | Spawn point (80 m trains).
| ◇ | 08 | 金森公園 | Kanemori-Kouen |
| \| | 07 | 浮宮 | Ukimiya | Spawn point (100 m trains).
| ◇ | 06 | 第一ダム | Yamagawako Dam No. 1 | Main location where trains in opposite directions pass.
| ◇ | 05 | 秋見台 | Akimidai | Spawn point (60 m trains). Backup passing location.
| \| | 04 | 中津 | Nakatsu |
| \| | 03 | 岡町 | Okamachi |
| \| | 02 | 東岡町 | Higashi-Okamachi |
| ∧ | 01 | 海原 | Umihara | Spawn point (80 m trains). Has depot.

The line speed limit is 95 km/h from Umihara to Akimidai, and 85 km/h everywhere else. The speed limit for freight trains is 65 km/h. The signal speed limits are shown in the following table.

| Aspect | Limit |
|:---:|:---:|
| G | Line speed |
| YG | 75 km/h |
| Y | 55 km/h |
| YY | 25 km/h |
| R | 0 km/h |

Stations on this line have single-track sections between them. Most of the stations are quite far apart, and in such cases, they are separated by one long main block, and multiple (usually 3) approach blocks on each end. Passenger trains are usually cleared in time with their scheduled passing of certain checkpoints. If a train is following another train, it may only receive clearance when it is separated from the leading train by at least one station.

### Rail and Train Construction

The rails are constructed in sections, splitting at the beginnings and ends of track features like station platforms, bridges, and tunnels. The gaps are covered by invisible stretched cylinders, replacing the previously random bounces (as in old versions of North Railway Hinoyama Line) with gentler bumps. However, the bumps still present an obstacle that can derail a train. To combat this, the resizable wheels and flanges on bogies should be adjusted to improve the reliability of the train on joints. My recommendations are:

- Wheels on the lead car should be just wide enough to prevent noticeable side-to-side deflection on straights and when entering corners.
- Wheels on trailing cars should be narrower (e.g., 0.05 units towards centerline) to navigate corners.

Work has also been done to help support more trains:

- Testing with a multi-car train as they are more sensitive to defects than single cars.
- Reduction of sharp vertical crests.
- Movement curved station platforms further from the tracks.
- Widening of track colliders at the tightest corners.

The following areas should be tested with your desired train before performing scenarios:

- Sharpest corners at Kanemori-Kouen.
- Sharp, fast corners with platforms at Nakatsu and No. 1 Dam.
- Climbing on steep gradients like the Akimidai tunnel.

Due to the construction method, only one combination of routes along the line is available.

## Service Types

### Local

For each direction, one morning scenario and one afternoon scenario are available. Each afternoon scenario is split into two sections following the separated line speeds. This gives a total of 6 levels.

The morning scenarios use two-car trains, while the afternoon scenarios use one-car trains.

### Express Freight

One scenario is provided for each direction. There is a speed limit of 65 km/h regardless of the type or amount of freight being carried. The scenarios use three- or four-car trains.

In each freight scenario, the train follows a local passenger train. Due to the operating procedures of train dispatching on this line, the clearance for the freight train is received in an irregular manner, which may require stopping at some stations. Despite this, the driving time of the freight train is shorter than that of local trains.

### Spring Sprinter

This is an express service that only runs during sakura season. It only stops at Umihara, Okamachi, Kanemori, Haruchi, and Takazaki. The timing is a bit more lenient than on local trains. Two-car trains are used.

## Driving Guide

### Umihara

Depart from Track 1 (the left track when driving in the northbound direction). The speed limit is 55 km/h for the first left-right sequence. If you are driving a heavy train, you will immediately feel the weight as there is no room to accelerate before the gradient increases to 20‰. Afterwards, the track begins to open up into the plains, with a speed limit of 65 to Higashi-Okamachi, the next station. The track suddenly drops from beneath you during the approach to Higashi-Okamachi, which makes stopping tricky.

### Higashi-Okamachi

This station has its stop targets on the north side.

The speed limit is cleared once you pass this station, but there is no chance to accelerate to line speed. Use the descent after the station to gain speed, and the subsequent ascent to brake. The gradients are roughly 20‰.

### Okamachi

This is a station that provides a bus transfer to the Nippon Railway main line.

Stop on the south side. The station is built on a crest, and the gradient changes rapidly throughout the length of the station.

Afterwards, there is a long run with gentle corners. Slow down to 85 km/h for the left-hander and climb along the side of the mountain. The gradient is 30‰. When you spot the approach signal lights, prepare to slow down as there is a speed limit reduction to 65 km/h, and the stop position will suddenly appear.

### Nakatsu

A station with a viewing tower, from which the dam is visible.

Stop on the south side. The station speed limit is 60 km/h. Most of the station is on flat tracks, but the one-car stopping position remains on the uphill section (about 10‰).

Unless your train is very powerful, you can apply full power from the station while complying with the 70 km/h exit speed limit. This begins the long climb to Akimidai Station.

The straight climb is 20‰ with a 75 km/h speed limit at the top for a right turn. You can travel at line speed before a gradual reduction to 85, 75, and 60 km/h.

Climb 35‰ after the sharp left turn. The speed limit is 85 km/h, but most trains will not be able to reach this speed. When driving southwards, this part is downhill and the speed limit is only 75 km/h. This is the only asymmetric speed limit on the line except on the final approach to terminal stations.

At the approach signals, the speed limit goes back down to 60 km/h, and the stop position quickly appears.

### Akimidai

The station is named after a century-old viewing spot that overlooks the coastal plains and river delta near Nakatsu.

Stop on the south side. The station is mostly flat and has a speed limit of 70 km/h. The north side has a 55 km/h Y-switch.

Accelerate as quickly as you can for the 30‰ tunnel climb, and hold that speed as long as you can. However, the speed limit decreases as soon as you leave the tunnel. Slow down according to the speed limit signs and signals.

### Yamagawako Dam No. 1

This station acts as the main passing point for parts of the timetable where two trains pass each other.

Stop on the north side. The station is mostly flat and has a speed limit of 55 km/h.

The following section can be taken at line speed, but the next station is easy to miss. Watch for a left turn with approach signals.

### Ukimiya

Stop in the middle.

When departing, there is a long flat section along the side of the mountain. Be ready to brake when the left-turn bridge appears, as its speed limit is only 50 km/h.

Get through the high-speed tunnel that bypasses the steep mountain faces. After this long tunnel ends, the speed limit decreases to 55 km/h near the next tunnel, which has a tower at its entrance. Continue at 55 in this tunnel, and apply the brakes when you see the sign for the next station, as the speed limit quickly drops to 30 km/h.

### Kanemori-Kouen

Stop at the north side. There is a moderate upwards slope of 8‰.

There is another 30 km/h corner when you depart from this station, then a steep descent of 25‰ to the next station under the sakura trees.

### Kanemori

This station used to be a side entrance to the research facility area.

Stop in the middle.

A long, moderately steep ascent of 10‰ awaits. At the top, a 60 km/h curved bridge makes a wide turn around a pointy hill. After the bridge, simply continue at 75 km/h. When you spot the approach signals, be careful as there is a moderate downward slope (17‰) into the station.

### Hanezawa

Stop at the south side.

The exit speed limit is 55 km/h. There is a 70 right-hander into a 17‰ downhill straight. This is also the braking zone for the next station.

### Takigawa

Stop at the north side. The station area is a 10‰ downhill slope.

A short run with gentle curves takes you to the next station.

### Haruchi

A station that provides access to a small pond and shrine. This is a lesser-known flower-viewing spot.

Stop in the middle. There are many stop marker signs here, so be careful.

A 20‰ climb takes the train to the final stop of this service.

### Takazaki

The northern terminus. There used to be tunnels into the research area, but they were damaged in an earthquake during the 90s and never repaired due to HAMEKA's gradual closure of the facility.

Stop at the beginning of the platform. Use the speed limit signs to gauge how fast you should be entering.
