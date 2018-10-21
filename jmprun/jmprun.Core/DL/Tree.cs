using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace jmprun.Core.DL
{
  public class Tree : Obstecle
  {
    public Tree(int x)
    {
      Ypos = 0;
      Xpos = x;
      Width = Globals.random.Next(1,3);
      Height = Globals.random.Next(3,6);
      Color = Color.Brown;
    }
  }
}
