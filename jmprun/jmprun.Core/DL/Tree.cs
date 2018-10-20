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
      Width = 1;
      Height = 2;
      Color = Color.Brown;
    }
  }
}
