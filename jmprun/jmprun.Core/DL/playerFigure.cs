using System;
using System.Collections.Generic;
using System.Drawing;
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
    public bool canMoveDown { get; private set; }
    public Image img { get; set; }
    private bool img1 { get; set; }

    public playerFigure(int x)
    {
      Xpos = x;
      Ypos = 0;
      Speed = 1;
      Ymov = 0;
      Xmov = 0;
      Height = 20;
      Width = 20;
      img = Image.FromFile("2.png");
      img1 = false;
    }
    public void Jmp()
    {
      if (Ypos <= 0 || !canMoveDown)
      {
        Ymov = 8;
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
          if (Ypos - (Height / Globals.Scale) < o.Ypos + o.Height && Ypos + (Height / Globals.Scale) >= o.Ypos)
          {
            canMoveX = false;
          }
        }
        if (o.Xpos + o.Width == Xpos + 4 && Xmov < 0)
        {
          if (Ypos - (Height / Globals.Scale) < o.Ypos + o.Height && Ypos + (Height / Globals.Scale) >= o.Ypos)
          {
            canMoveX = false;
          }
        }
        if (Xpos + (Width / Globals.Scale) >= o.Xpos - 3 && Xpos + 5 <= o.Xpos + o.Width)
        {
          if (Ypos == o.Ypos + o.Height)
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
      if ((Xmov != 0 && canMoveX) || (Ypos > 0 && canMoveDown))
      {
        if (Ypos > 0 && canMoveDown)
        {
          img = Image.FromFile("../../../jmprun.SRC/jmp.png");
        }
        else if (img1)
        {
          img = Image.FromFile("../../../jmprun.SRC/1.png"); ;
          img1 = false;
        }
        else
        {
          img = Image.FromFile("../../../jmprun.SRC/2.png"); ;
          img1 = true;
        }
      }

    }
  }
}
