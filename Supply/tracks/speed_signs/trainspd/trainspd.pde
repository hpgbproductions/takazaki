// Supported speed limits
// First entry is ignored since frameCount starts from 1
// 0 produces speed limit release sign
int[] speeds = { 0, 0, 25, 30, 35, 40, 45, 50, 55 };

int dirSize = 25;
Boolean dirLeft = false;
Boolean dirRight = true;
String suffix = "";

PFont font;

void setup()
{
  size(150, 100);
  
  // First create font using Tools/Create Font
  // then link vlw file
  font = loadFont("KaiTi-96.vlw");
  
  textAlign(CENTER, CENTER);
  textFont(font);
  
  if (dirLeft)
  {
    suffix += "l";
  }
  
  if (dirRight)
  {
    suffix += "r";
  }
}

void draw()
{
  if (frameCount >= speeds.length)
  {
    return;
  }
  
  background(255);
  fill(0);
  noStroke();
  
  if (speeds[frameCount] == 0)
  {
    triangle(0, 0, 0, height, width/2, height/2);
    triangle(width/2, height/2, width, height, width, 0);
  }
  else
  {
    text(speeds[frameCount], width/2, height/2);
    
    if (dirLeft)
    {
      triangle(0, 0, 0, dirSize, dirSize, 0);
      triangle(0, height, dirSize, height, 0, height-dirSize);
    }
    
    if (dirRight)
    {
      triangle(width, 0, width-dirSize, 0, width, dirSize);
      triangle(width, height, width, height-dirSize, width-dirSize, height);
    }
  }
  
  save("limit" + speeds[frameCount] + suffix + ".png");
}
