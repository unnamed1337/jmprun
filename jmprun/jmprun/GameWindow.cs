using jmprun.Core;
using jmprun.Core.DL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace jmprun
{
  public partial class GameWindow : Form
  {
    public playerFigure player;
    List<Obstecle> Obstecles;
    public double Xview = 2;
    public GameWindow()
    {
      InitializeComponent();
      Init();
    }
    public void Init()
    {
      Globals.random = new Random();
      Random rnd = new Random();
      this.Width = 100 * Globals.Scale;
      this.Height = Globals.GameHeight * Globals.Scale + 70;
      this.BackColor = Color.DeepSkyBlue;
      Obstecles = new List<Obstecle>();
      player = new playerFigure(10);
      Obstecles.Add(new Tree(rnd.Next(15, 70)));
      for (int i = 0; i <= 3; i++)
      {
        int x = Obstecles[Obstecles.Count - 1].Xpos + rnd.Next(1, 100);
        if (rnd.Next(0, 101) >= 50)
        {
          Obstecles.Add(new Rock(x));
        }
        else
        {
          Obstecles.Add(new Tree(x));
        }
      }
    }
    public void DrawGamemap(PaintEventArgs e)
    {
      SolidBrush grass = new SolidBrush(Color.ForestGreen);
      SolidBrush playerBrush = new SolidBrush(Color.Goldenrod);
      e.Graphics.FillRectangle(grass, 0, Globals.GameHeight * Globals.Scale, 100 * Globals.Scale, 70);
      grass.Dispose();
      e.Graphics.FillEllipse(playerBrush, (player.Xpos * Globals.Scale) - (Convert.ToInt32(Xview) * Globals.Scale) + (player.Height * 2), (Globals.GameHeight * Globals.Scale) - (player.Ypos * Globals.Scale) - player.Height, player.Height, player.Height);
      playerBrush.Dispose();

      foreach (Obstecle o in Obstecles)
      {
        SolidBrush b = new SolidBrush(o.Color);
        e.Graphics.FillRectangle(b, o.Xpos * Globals.Scale - (Convert.ToInt32(Xview) * Globals.Scale), Globals.GameHeight * Globals.Scale - (o.Ypos + o.Height * Globals.Scale), o.Width * Globals.Scale, o.Height * Globals.Scale);
        b.Dispose();
      }
    }

    private void GameWindow_Paint(object sender, PaintEventArgs e)
    {
      DrawGamemap(e);
    }

    private void GameWindow_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Right)
      {
        player.Xmov = 1;
      }
      else if (e.KeyCode == Keys.Left)
      {
        player.Xmov = -1;
      }
      else if (e.KeyCode == Keys.Space)
      {
        player.Jmp();
      }
      if (!timer1.Enabled)
      {
        timer1.Start();
      }
      //this.Invalidate();
      //this.Update();
      //this.Refresh();
    }

    private void GameWindow_KeyUp(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Right)
      {
        player.Xmov = 0;
      }
      else if (e.KeyCode == Keys.Left)
      {
        player.Xmov = 0;
      }
    }

    private void Timer(object sender, EventArgs e)
    {
      player.Update();
      //Xview += 0.1;
      //if (player.Xpos >= Xview + ((this.Width / Globals.Scale) * 0.75))
      //{
      //  Xview += 3;
      //}

      Xview += player.Xmov;

      if (Obstecles[0].Xpos < Xview)
      {
        if (Obstecles[0].Xpos + (this.Width / Globals.Scale) * 2 < Xview)
        {
          Obstecles.RemoveAt(0);
        }
        Random rnd = new Random();
        int x = Obstecles[Obstecles.Count - 1].Xpos + rnd.Next(1, 100);
        if (rnd.Next(0, 101) >= 50)
        {
          Obstecles.Add(new Rock(x));
        }
        else
        {
          Obstecles.Add(new Tree(x));
        }
      }

      this.Invalidate();
      this.Update();
      this.Refresh();
    }
  }
}
