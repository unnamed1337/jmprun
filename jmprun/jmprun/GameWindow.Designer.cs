namespace jmprun
{
  partial class GameWindow
  {
    /// <summary>
    /// Erforderliche Designervariable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Verwendete Ressourcen bereinigen.
    /// </summary>
    /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Vom Windows Form-Designer generierter Code

    /// <summary>
    /// Erforderliche Methode für die Designerunterstützung.
    /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      this.timer1 = new System.Windows.Forms.Timer(this.components);
      this.SuspendLayout();
      // 
      // timer1
      // 
      this.timer1.Interval = 50;
      this.timer1.Tick += new System.EventHandler(this.Timer);
      // 
      // GameWindow
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(800, 450);
      this.Name = "GameWindow";
      this.Text = "JMP&RUN";
      this.Paint += new System.Windows.Forms.PaintEventHandler(this.GameWindow_Paint);
      this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GameWindow_KeyDown);
      this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.GameWindow_KeyUp);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Timer timer1;
  }
}

