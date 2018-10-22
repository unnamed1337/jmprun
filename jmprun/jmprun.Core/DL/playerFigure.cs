using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jmprun.Core.DL
{
  public class playerFigure
  {
    public int Xpos { get; set; }
    public int Ypos { get; set; }
    public int Speed { get; set; }
    private int Ymov { get; set; }
    public int Xmov { get; set; }
    public int Height { get; set; }
    public int Width { get; set; }
    private bool canMoveDown { get; set; }

    public playerFigure(int x)
    {
      Xpos = x;
      Ypos = 0;
      Speed = 1;
      Ymov = 0;
      Xmov = 0;
      Height = 20;
      Width = 20;
    }
    public void Jmp()
    {
      if (Ypos <= 0 || !canMoveDown)
      {
        Ymov += 10;
      }
    }
    public void Update(List<Obstecle> obstecles)
    {
      bool canMoveX = true;
      canMoveDown = true;
      foreach (Obstecle o in obstecles)
      {
        if (o.Xpos == Xpos + 6 && Xmov > 0)
        {
          if (o.Ypos >= Ypos && Ypos <= o.Ypos + o.Height)
          {
            canMoveX = false;
          }
        }
        if (o.Xpos + o.Width == Xpos + 4 && Xmov < 0)
        {
          if (o.Ypos >= Ypos && Ypos <= o.Ypos + o.Height)
          {
            canMoveX = false;
          }
        }
        if (Xpos + 2 >= o.Xpos -3 && Xpos +5 <= o.Xpos + o.Width)
        {
          if(Ypos == o.Ypos + o.Height)
          {
            canMoveDown = false;
          }
        }
      }

      if (Ymov > 0)
      {
        Ymov--;
        Ypos++;
      }
      else if (Ypos > 0)
      {
        if (canMoveDown)
        {
          Ypos--;
        }
      }

      if (canMoveX)
      {
        Xpos += (Xmov * Speed);
      }
    }
  }
}
