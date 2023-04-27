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
         var mapDisplayOptions1 = new Controls.MapDisplayOptions();
         var realmTileMap1 = new Core.Models.RealmTileMap();
         mainSplitContainer = new SplitContainer();
         totalInfluenceView = new Controls.InfluenceView();
         theMapView = new Controls.RealmTileMapView();
         tileInfluenceView = new Controls.InfluenceView();
         ((System.ComponentModel.ISupportInitialize)mainSplitContainer).BeginInit();
         mainSplitContainer.Panel1.SuspendLayout();
         mainSplitContainer.Panel2.SuspendLayout();
         mainSplitContainer.SuspendLayout();
         SuspendLayout();
         // 
         // mainSplitContainer
         // 
         mainSplitContainer.Dock = DockStyle.Fill;
         mainSplitContainer.Location = new Point(0, 0);
         mainSplitContainer.Name = "mainSplitContainer";
         // 
         // mainSplitContainer.Panel1
         // 
         mainSplitContainer.Panel1.Controls.Add(tileInfluenceView);
         mainSplitContainer.Panel1.Controls.Add(totalInfluenceView);
         // 
         // mainSplitContainer.Panel2
         // 
         mainSplitContainer.Panel2.AutoScroll = true;
         mainSplitContainer.Panel2.Controls.Add(theMapView);
         mainSplitContainer.Size = new Size(1153, 719);
         mainSplitContainer.SplitterDistance = 384;
         mainSplitContainer.TabIndex = 1;
         // 
         // totalInfluenceView
         // 
         totalInfluenceView.Influence = null;
         totalInfluenceView.Location = new Point(3, 3);
         totalInfluenceView.Name = "totalInfluenceView";
         totalInfluenceView.Size = new Size(150, 150);
         totalInfluenceView.TabIndex = 0;
         // 
         // theMapView
         // 
         theMapView.AutoScroll = true;
         theMapView.AutoSize = true;
         mapDisplayOptions1.TileSize = new Size(64, 64);
         theMapView.DisplayOptions = mapDisplayOptions1;
         theMapView.Dock = DockStyle.Fill;
         theMapView.Location = new Point(0, 0);
         theMapView.Map = realmTileMap1;
         theMapView.Name = "theMapView";
         theMapView.Size = new Size(765, 719);
         theMapView.TabIndex = 0;
         theMapView.MouseSetOverCoordinate += TheMapViewMouseSetOverCoordinate;
         theMapView.MouseClearOverCoordinate += theMapView_MouseClearOverCoordinate;
         // 
         // tileInfluenceView
         // 
         tileInfluenceView.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
         tileInfluenceView.Influence = null;
         tileInfluenceView.Location = new Point(3, 576);
         tileInfluenceView.Name = "tileInfluenceView";
         tileInfluenceView.Size = new Size(150, 140);
         tileInfluenceView.TabIndex = 1;
         // 
         // MainForm
         // 
         AutoScaleDimensions = new SizeF(7F, 15F);
         AutoScaleMode = AutoScaleMode.Font;
         ClientSize = new Size(1153, 719);
         Controls.Add(mainSplitContainer);
         Name = "MainForm";
         Text = "MainForm";
         FormClosed += MainForm_FormClosed;
         Load += MainForm_Load;
         mainSplitContainer.Panel1.ResumeLayout(false);
         mainSplitContainer.Panel2.ResumeLayout(false);
         mainSplitContainer.Panel2.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)mainSplitContainer).EndInit();
         mainSplitContainer.ResumeLayout(false);
         ResumeLayout(false);
      }

      #endregion
      private SplitContainer mainSplitContainer;
      private Controls.InfluenceView totalInfluenceView;
      private Controls.RealmTileMapView theMapView;
      private Controls.InfluenceView tileInfluenceView;
   }
}
