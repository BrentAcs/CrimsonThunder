namespace Balance.App.Controls
{
   partial class RealmTileMapView
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

      #region Component Designer generated code

      /// <summary> 
      /// Required method for Designer support - do not modify 
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         thePanel = new Panel();
         SuspendLayout();
         // 
         // thePanel
         // 
         thePanel.Location = new Point(0, 0);
         thePanel.Name = "thePanel";
         thePanel.Size = new Size(279, 360);
         thePanel.TabIndex = 0;
         thePanel.Paint += thePanel_Paint;
         thePanel.MouseDown += thePanel_MouseDown;
         thePanel.MouseEnter += thePanel_MouseEnter;
         thePanel.MouseLeave += thePanel_MouseLeave;
         thePanel.MouseHover += thePanel_MouseHover;
         thePanel.MouseMove += thePanel_MouseMove;
         thePanel.MouseUp += thePanel_MouseUp;
         // 
         // RealmTileMapView
         // 
         AutoScaleDimensions = new SizeF(7F, 15F);
         AutoScaleMode = AutoScaleMode.Font;
         AutoScroll = true;
         Controls.Add(thePanel);
         Name = "RealmTileMapView";
         Size = new Size(508, 514);
         ResumeLayout(false);
      }

      #endregion

      private Panel thePanel;
   }
}
