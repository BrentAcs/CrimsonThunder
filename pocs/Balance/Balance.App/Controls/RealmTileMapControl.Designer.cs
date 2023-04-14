namespace Balance.App.Controls
{
   partial class RealmTileMapControl
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
         buttonPanel = new Panel();
         tilesPanel = new Panel();
         zoomInButton = new Button();
         zoomOutButton = new Button();
         buttonPanel.SuspendLayout();
         SuspendLayout();
         // 
         // buttonPanel
         // 
         buttonPanel.Controls.Add(zoomOutButton);
         buttonPanel.Controls.Add(zoomInButton);
         buttonPanel.Dock = DockStyle.Top;
         buttonPanel.Location = new Point(0, 0);
         buttonPanel.Name = "buttonPanel";
         buttonPanel.Size = new Size(535, 32);
         buttonPanel.TabIndex = 0;
         // 
         // tilesPanel
         // 
         tilesPanel.AutoScroll = true;
         tilesPanel.Dock = DockStyle.Fill;
         tilesPanel.Location = new Point(0, 32);
         tilesPanel.Name = "tilesPanel";
         tilesPanel.Size = new Size(535, 464);
         tilesPanel.TabIndex = 1;
         // 
         // zoomInButton
         // 
         zoomInButton.Location = new Point(3, 3);
         zoomInButton.Name = "zoomInButton";
         zoomInButton.Size = new Size(39, 23);
         zoomInButton.TabIndex = 0;
         zoomInButton.Text = "+";
         zoomInButton.UseVisualStyleBackColor = true;
         // 
         // zoomOutButton
         // 
         zoomOutButton.Location = new Point(48, 3);
         zoomOutButton.Name = "zoomOutButton";
         zoomOutButton.Size = new Size(32, 23);
         zoomOutButton.TabIndex = 1;
         zoomOutButton.Text = "-";
         zoomOutButton.UseVisualStyleBackColor = true;
         // 
         // RealmTileMapControl
         // 
         AutoScaleDimensions = new SizeF(7F, 15F);
         AutoScaleMode = AutoScaleMode.Font;
         Controls.Add(tilesPanel);
         Controls.Add(buttonPanel);
         Name = "RealmTileMapControl";
         Size = new Size(535, 496);
         buttonPanel.ResumeLayout(false);
         ResumeLayout(false);
      }

      #endregion

      private Panel buttonPanel;
      private Button zoomOutButton;
      private Button zoomInButton;
      private Panel tilesPanel;
   }
}
