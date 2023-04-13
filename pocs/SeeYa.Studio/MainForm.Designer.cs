namespace SeeYa.Studio
{
   partial class MainForm
   {
      /// <summary>
      ///  Required designer variable.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      /// <summary>
      ///  Clean up any resources being used.
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
      ///  Required method for Designer support - do not modify
      ///  the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         var resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
         mainToolStrip = new ToolStrip();
         toolStripLabel1 = new ToolStripLabel();
         storiesToolStripComboBox = new ToolStripComboBox();
         runStoryToolStripButton = new ToolStripButton();
         mainToolStrip.SuspendLayout();
         SuspendLayout();
         // 
         // mainToolStrip
         // 
         mainToolStrip.Items.AddRange(new ToolStripItem[] { toolStripLabel1, storiesToolStripComboBox, runStoryToolStripButton });
         mainToolStrip.Location = new Point(0, 0);
         mainToolStrip.Name = "mainToolStrip";
         mainToolStrip.Size = new Size(800, 25);
         mainToolStrip.TabIndex = 0;
         mainToolStrip.Text = "toolStrip1";
         // 
         // toolStripLabel1
         // 
         toolStripLabel1.Name = "toolStripLabel1";
         toolStripLabel1.Size = new Size(45, 22);
         toolStripLabel1.Text = "Stories:";
         // 
         // storiesToolStripComboBox
         // 
         storiesToolStripComboBox.Name = "storiesToolStripComboBox";
         storiesToolStripComboBox.Size = new Size(196, 25);
         storiesToolStripComboBox.SelectedIndexChanged += storiesToolStripComboBox_SelectedIndexChanged;
         // 
         // runStoryToolStripButton
         // 
         runStoryToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Text;
         runStoryToolStripButton.Image = (Image)resources.GetObject("runStoryToolStripButton.Image");
         runStoryToolStripButton.ImageTransparentColor = Color.Magenta;
         runStoryToolStripButton.Name = "runStoryToolStripButton";
         runStoryToolStripButton.Size = new Size(32, 22);
         runStoryToolStripButton.Text = "Run";
         runStoryToolStripButton.Click += runStoryToolStripButton_Click;
         // 
         // MainForm
         // 
         AutoScaleDimensions = new SizeF(7F, 15F);
         AutoScaleMode = AutoScaleMode.Font;
         ClientSize = new Size(800, 450);
         Controls.Add(mainToolStrip);
         Name = "MainForm";
         Text = "See Ya Studio";
         FormClosed += MainForm_FormClosed;
         Load += MainForm_Load;
         mainToolStrip.ResumeLayout(false);
         mainToolStrip.PerformLayout();
         ResumeLayout(false);
         PerformLayout();
      }

      #endregion

      private ToolStrip mainToolStrip;
      private ToolStripLabel toolStripLabel1;
      private ToolStripComboBox storiesToolStripComboBox;
      private ToolStripButton runStoryToolStripButton;
   }
}