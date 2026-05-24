String[] StationNames = { "", "海原", "東岡町", "岡町", "中津", "秋見台", "第一ダム", "浮宮", "金森公園", "金森", "羽沢", "滝川", "春池", "高崎" };
PFont Font;

float[] TextLeadings = {0f, 0f, 120f, 90f, 60f};

void setup()
{
  size(64, 256);
  rectMode(CENTER);
  Font = createFont("MS Gothic", 48);
}

void draw()
{
  if (frameCount >= StationNames.length)
  {
    return;
  }
  
  textFont(Font, 48);
  textAlign(CENTER, CENTER);
  fill(0);
  
  background(255, 224, 0);
  textLeading(TextLeadings[StationNames[frameCount].length()]);
  text(StationNames[frameCount], width/2, height/2, width, height);
  saveFrame("stationSign##.png");
}
