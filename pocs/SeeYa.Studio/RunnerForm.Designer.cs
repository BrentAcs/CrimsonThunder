namespace SeeYa.Studio
{
   partial class RunnerForm
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
         narrativeTextBox = new TextBox();
         mainSplitContainer = new SplitContainer();
         ((System.ComponentModel.ISupportInitialize)mainSplitContainer).BeginInit();
         mainSplitContainer.Panel1.SuspendLayout();
         mainSplitContainer.SuspendLayout();
         SuspendLayout();
         // 
         // narrativeTextBox
         // 
         narrativeTextBox.Dock = DockStyle.Fill;
         narrativeTextBox.Location = new Point(0, 0);
         narrativeTextBox.Multiline = true;
         narrativeTextBox.Name = "narrativeTextBox";
         narrativeTextBox.ReadOnly = true;
         narrativeTextBox.Size = new Size(575, 299);
         narrativeTextBox.TabIndex = 0;
         // 
         // mainSplitContainer
         // 
         mainSplitContainer.Dock = DockStyle.Fill;
         mainSplitContainer.IsSplitterFixed = true;
         mainSplitContainer.Location = new Point(0, 0);
         mainSplitContainer.Name = "mainSplitContainer";
         mainSplitContainer.Orientation = Orientation.Horizontal;
         // 
         // mainSplitContainer.Panel1
         // 
         mainSplitContainer.Panel1.Controls.Add(narrativeTextBox);
         mainSplitContainer.Size = new Size(575, 549);
         mainSplitContainer.SplitterDistance = 299;
         mainSplitContainer.TabIndex = 1;
         // 
         // RunnerForm
         // 
         AutoScaleDimensions = new SizeF(7F, 15F);
         AutoScaleMode = AutoScaleMode.Font;
         ClientSize = new Size(575, 549);
         Controls.Add(mainSplitContainer);
         Name = "RunnerForm";
         Text = "RunnerForm";
         mainSplitContainer.Panel1.ResumeLayout(false);
         mainSplitContainer.Panel1.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)mainSplitContainer).EndInit();
         mainSplitContainer.ResumeLayout(false);
         ResumeLayout(false);
      }

      #endregion

      private TextBox narrativeTextBox;
      private SplitContainer mainSplitContainer;
   }
}
