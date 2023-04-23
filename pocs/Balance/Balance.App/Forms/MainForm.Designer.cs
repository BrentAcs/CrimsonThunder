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
         mainSplitContainer = new SplitContainer();
         totalInfluenceView = new Controls.InfluenceView();
         ((System.ComponentModel.ISupportInitialize)mainSplitContainer).BeginInit();
         mainSplitContainer.Panel1.SuspendLayout();
         mainSplitContainer.Panel2.SuspendLayout();
         mainSplitContainer.SuspendLayout();
         SuspendLayout();
         // 
         // theMapControl
         // 
         theMapControl.Dock = DockStyle.Fill;
         theMapControl.Location = new Point(0, 0);
         theMapControl.Name = "theMapControl";
         theMapControl.Size = new Size(604, 570);
         theMapControl.TabIndex = 0;
         // 
         // mainSplitContainer
         // 
         mainSplitContainer.Dock = DockStyle.Fill;
         mainSplitContainer.Location = new Point(0, 0);
         mainSplitContainer.Name = "mainSplitContainer";
         // 
         // mainSplitContainer.Panel1
         // 
         mainSplitContainer.Panel1.Controls.Add(totalInfluenceView);
         // 
         // mainSplitContainer.Panel2
         // 
         mainSplitContainer.Panel2.AutoScroll = true;
         mainSplitContainer.Panel2.Controls.Add(theMapControl);
         mainSplitContainer.Size = new Size(912, 570);
         mainSplitContainer.SplitterDistance = 304;
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
         // MainForm
         // 
         AutoScaleDimensions = new SizeF(7F, 15F);
         AutoScaleMode = AutoScaleMode.Font;
         ClientSize = new Size(912, 570);
         Controls.Add(mainSplitContainer);
         Name = "MainForm";
         Text = "MainForm";
         FormClosed += MainForm_FormClosed;
         Load += MainForm_Load;
         mainSplitContainer.Panel1.ResumeLayout(false);
         mainSplitContainer.Panel2.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)mainSplitContainer).EndInit();
         mainSplitContainer.ResumeLayout(false);
         ResumeLayout(false);
      }

      #endregion

      private Controls.RealmTileMapControl theMapControl;
      private SplitContainer mainSplitContainer;
      private Controls.InfluenceView totalInfluenceView;
   }
}