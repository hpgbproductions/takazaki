# Northbound Driving Walkthrough

*...or drive-through?*

This guide will cover general information and driving tips for the HAMEKA Takazaki Line. Then, there will be a written section-by-section guide for driving in the northerly direction. Relevant design considerations will be discussed. Some details about southbound driving will be mentioned, but route discovery is mostly left as an exercise for the reader.

## General Information

### Line Information

The HAMEKA Takazaki Line is a roughly 40 kilometer-long mountainous conventional rail line. It serves as a branch line that connects a biotechnology research facility and multiple villages to the national railway line. Along the way, it climbs more than 160 meters from the coastal plains to a lake formed by two dams.

With a maximum gradient of 35‰ and a minimum corner radius of 80 m, the line will thoroughly test your train's engines, brakes, and frame. What it doesn't test, however, is memorization, since the line was deliberately designed to be easy to learn by using natural speed limit progressions and visual landmarks.

The station list is shown below:

| | No. | JA | EN |
|:---:|:---:|:--- |:--- |
| ∨ | 13 | 高崎 | Takazaki |
| \| | 12 | 春池 | Haruchi |
| \| | 11 | 滝川 | Takigawa |
| ◇ | 10 | 羽沢 | Hanesawa |
| \| | 09 | 金森 | Kanemori |
| ◇ | 08 | 金森公園 | Kanemori-Kouen |
| \| | 07 | 浮宮 | Ukimiya |
| ◇ | 06 | 第一ダム | Yamagawako Dam No. 1 |
| ◇ | 05 | 秋見台 | Akimidai |
| \| | 04 | 中津 | Nakatsu |
| \| | 03 | 岡町 | Okamachi |
| \| | 02 | 東岡町 | Higashi-Okamachi |
| ∧ | 01 | 海原 | Umihara |

The line speed limit is 95 km/h from Umihara to Akimidai, and 85 km/h everywhere else. The speed limit for freight trains is 65 km/h. The signal speed limits are shown in the following table.

| Aspect | Limit |
|:---:|:---:|
| G | Line speed |
| YG | 75 km/h |
| Y | 55 km/h |
| YY | 25 km/h |
| R | 0 km/h |

Stations on this line have single-track sections between them. Most of the stations are quite far apart, and in such cases, they are separated by one long main block, and multiple (usually 3) approach blocks on each end. Passenger trains are usually cleared in time with their scheduled passing of certain checkpoints.

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
- Ascending speed on steep gradients like the Akimidai tunnel.
