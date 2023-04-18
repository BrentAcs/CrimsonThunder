namespace Balance.App.Controls
{
   partial class RealmTileControl
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
         influenceLabel = new Label();
         SuspendLayout();
         // 
         // influenceLabel
         // 
         influenceLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
         influenceLabel.Location = new Point(3, 113);
         influenceLabel.Name = "influenceLabel";
         influenceLabel.Size = new Size(144, 23);
         influenceLabel.TabIndex = 0;
         influenceLabel.Text = "label1";
         influenceLabel.TextAlign = ContentAlignment.MiddleCenter;
         // 
         // RealmTileControl
         // 
         AutoScaleDimensions = new SizeF(7F, 15F);
         AutoScaleMode = AutoScaleMode.Font;
         Controls.Add(influenceLabel);
         Name = "RealmTileControl";
         Paint += RealmTileControl_Paint;
         ResumeLayout(false);
      }

      #endregion

      private Label influenceLabel;
   }
}
