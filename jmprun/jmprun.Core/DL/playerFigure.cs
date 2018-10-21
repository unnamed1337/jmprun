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

    public playerFigure(int x)
    {
      Xpos = x;
      Ypos = 0;
      Speed = 1;
      Ymov = 0;
      Xmov = 0;
      Height = 20;
    }
    public void Jmp()
    {
      if(Ypos <= 0)
      {
        Ymov += 10;
      }
    }
    public void Update()
    {
      if(Ymov > 0)
      {
        Ymov--;
        Ypos++;
      }
      else if(Ypos > 0)
      {
        Ypos--;
      }
      Xpos += (Xmov * Speed);
    }
  }
}
