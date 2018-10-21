using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace jmprun.Core.DL
{
  public class Rock : Obstecle
  {
    public Rock(int x)
    {
      Ypos = 0;
      Xpos = x;
      Width = Globals.random.Next(2,5);
      Height = Globals.random.Next(1,3);
      Color = Color.DarkSlateGray;
    }
  }
}
