using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jmprun.Core.DL
{
  public class medal
  {
    public int Xpos { get; set; }
    public int Ypos { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
    public medal(int x)
    {
      Xpos = x;
      Ypos = Globals.random.Next(2, 9);
      Width = 2;
      Height = 2;
    }
    public bool crossedByPlayer(int x,int y, int w, int h)
    {
      if(x+(w/Globals.Scale) >= Xpos-Width && x+(w / Globals.Scale) <= Xpos-Width)
      {
        return true;
      }

      return false;
    }
  }
}
