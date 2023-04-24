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
         influenceView = new InfluenceView();
         SuspendLayout();
         // 
         // influenceView
         // 
         influenceView.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
         influenceView.Influence = null;
         influenceView.Location = new Point(3, 129);
         influenceView.Name = "influenceView";
         influenceView.Size = new Size(144, 18);
         influenceView.TabIndex = 1;
         influenceView.Visible = false;
         // 
         // RealmTileControl
         // 
         AutoScaleDimensions = new SizeF(7F, 15F);
         AutoScaleMode = AutoScaleMode.Font;
         Controls.Add(influenceView);
         Name = "RealmTileControl";
         Paint += RealmTileControl_Paint;
         ResumeLayout(false);
      }

      #endregion
      private InfluenceView influenceView;
   }
}
