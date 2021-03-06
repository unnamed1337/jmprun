﻿using jmprun.Core;
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
    List<medal> Medals;
    public double Xview = 2;
    public int CoinsTotal = 0;
    Image coin;

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
      Medals = new List<medal>();
      player = new playerFigure(10);
      Obstecles.Add(new Tree(rnd.Next(20, 70)));
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
      coin = Image.FromFile("../../../jmprun.SRC/coin.png");

      Medals.Add(new medal(30));

    }
    public void DrawGamemap(PaintEventArgs e)
    {
      SolidBrush grass = new SolidBrush(Color.ForestGreen);
      SolidBrush playerBrush = new SolidBrush(Color.Black);
      e.Graphics.FillRectangle(grass, 0, Globals.GameHeight * Globals.Scale, 100 * Globals.Scale, 70);
      grass.Dispose();

      //e.Graphics.FillEllipse(playerBrush, (player.Xpos * Globals.Scale) - (Convert.ToInt32(Xview) * Globals.Scale) + (player.Height * 2), (Globals.GameHeight * Globals.Scale) - (player.Ypos * Globals.Scale) - player.Height, player.Height, player.Height);

      e.Graphics.DrawImage(player.img, (player.Xpos * Globals.Scale) - (Convert.ToInt32(Xview) * Globals.Scale) + (player.Height * 2), (Globals.GameHeight * Globals.Scale) - (player.Ypos * Globals.Scale) - player.Height, player.Height, player.Height);
      playerBrush.Dispose();

      List<Rectangle> trees = new List<Rectangle>();
      List<Rectangle> rocks = new List<Rectangle>();

      foreach (Obstecle o in Obstecles)
      {
        if (o.GetType() == typeof(Tree))
        {
          trees.Add(new Rectangle(o.Xpos * Globals.Scale - (Convert.ToInt32(Xview) * Globals.Scale), Globals.GameHeight * Globals.Scale - (o.Ypos + o.Height * Globals.Scale), o.Width * Globals.Scale, o.Height * Globals.Scale));
        }
        else if (o.GetType() == typeof(Rock))
        {
          rocks.Add(new Rectangle(o.Xpos * Globals.Scale - (Convert.ToInt32(Xview) * Globals.Scale), Globals.GameHeight * Globals.Scale - (o.Ypos + o.Height * Globals.Scale), o.Width * Globals.Scale, o.Height * Globals.Scale));
        }
        else
        {
          SolidBrush b = new SolidBrush(o.Color);
          e.Graphics.FillRectangle(b, o.Xpos * Globals.Scale - (Convert.ToInt32(Xview) * Globals.Scale), Globals.GameHeight * Globals.Scale - (o.Ypos + o.Height * Globals.Scale), o.Width * Globals.Scale, o.Height * Globals.Scale);
          b.Dispose();
        }
      }
      SolidBrush t = new SolidBrush(Color.Brown);
      SolidBrush r = new SolidBrush(Color.DarkSlateGray);

      foreach(medal m in Medals)
      {
        e.Graphics.DrawImage(coin,(m.Xpos*Globals.Scale)-(Convert.ToInt32(Xview)*Globals.Scale),Globals.GameHeight * Globals.Scale - (m.Ypos*Globals.Scale) ,m.Width*Globals.Scale,m.Height*Globals.Scale);
      }

      if (trees.Count > 0)
      {
        e.Graphics.FillRectangles(t, trees.ToArray());
      }
      if (rocks.Count > 0)
      {
        e.Graphics.FillRectangles(r, rocks.ToArray());
      }
      t.Dispose();
      r.Dispose();
    }

    private void GameWindow_Paint(object sender, PaintEventArgs e)
    {
      DrawGamemap(e);
      Font font = new Font("Arial", 12, FontStyle.Bold, GraphicsUnit.Point);
      SolidBrush b = new SolidBrush(Color.Gold);
      e.Graphics.DrawImage(coin, 10, 10, 20, 20);
      e.Graphics.DrawString(" x "+CoinsTotal, font, b, 30, 10);
      //e.Graphics.FillEllipse(b, 40, 10, 20, 20);
      
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
      player.Update(Obstecles);

      Xview = player.Xpos - 8;

      if (Obstecles[Obstecles.Count / 2 > 0 ? Obstecles.Count / 2 : 0].Xpos < Xview)
      {
        if (Obstecles[0].Xpos + (this.Width / Globals.Scale) < Xview)
        {
          Obstecles.RemoveAt(0);
        }
        Random rnd = new Random();
        int x = Obstecles[Obstecles.Count - 1].Xpos + Obstecles[Obstecles.Count - 1].Width + rnd.Next(0, 100 - Convert.ToInt32(Xview / this.Width) >= 5 ? 100 - Convert.ToInt32(Xview / this.Width) : 5);
        if (rnd.Next(0, 101) >= 50)
        {
          Obstecles.Add(new Rock(x));
        }
        else
        {
          Obstecles.Add(new Tree(x));
        }
      }
      foreach(medal m in Medals)
      {
        if (m.crossedByPlayer(player.Xpos, player.Ypos, player.Width, player.Height))
        {
          CoinsTotal++;
          Medals.Remove(m);
          break;
        }
      }
      if (Medals.Count < 1)
      {
        int x = Convert.ToInt32(Xview + (this.Width / Globals.Scale) * 2);
        Medals.Add(new medal(x));
      }
      else if (Medals[0].Xpos < Xview - (this.Width / Globals.Scale))
      {
        Medals.RemoveAt(0);
      }
      
      this.Invalidate();
    }
  }
}
