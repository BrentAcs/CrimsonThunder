namespace Balance.App.Forms
{
   partial class MainForm
   {
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      /// <summary>
      /// Clean up any resources being used.
      /// </summary>
      /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      protected override void Dispose(bool disposing)
      {
         if (disposing && (components != null))
         {
            components.Dispose();
         }
         base.Dispose(disposing);
      }

      #region Windows Form Designer generated code

      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         theMapControl = new Controls.RealmTileMapControl();
         SuspendLayout();
         // 
         // theMapControl
         // 
         theMapControl.Dock = DockStyle.Fill;
         theMapControl.Location = new Point(0, 0);
         theMapControl.Name = "theMapControl";
         theMapControl.Size = new Size(800, 450);
         theMapControl.TabIndex = 0;
         // 
         // MainForm
         // 
         AutoScaleDimensions = new SizeF(7F, 15F);
         AutoScaleMode = AutoScaleMode.Font;
         ClientSize = new Size(800, 450);
         Controls.Add(theMapControl);
         Name = "MainForm";
         Text = "MainForm";
         FormClosed += MainForm_FormClosed;
         Load += MainForm_Load;
         ResumeLayout(false);
      }

      #endregion

      private Controls.RealmTileMapControl theMapControl;
   }
}