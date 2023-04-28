namespace Balance.App.Controls
{
   partial class RealmTileInfoView
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
         theInfluenceView = new InfluenceView();
         label1 = new Label();
         locationTextBox = new TextBox();
         label2 = new Label();
         realmTypeTextBox = new TextBox();
         SuspendLayout();
         // 
         // theInfluenceView
         // 
         theInfluenceView.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
         theInfluenceView.Influence = null;
         theInfluenceView.Location = new Point(3, 65);
         theInfluenceView.Name = "theInfluenceView";
         theInfluenceView.Size = new Size(189, 72);
         theInfluenceView.TabIndex = 0;
         // 
         // label1
         // 
         label1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
         label1.AutoSize = true;
         label1.Location = new Point(3, 39);
         label1.Name = "label1";
         label1.Size = new Size(53, 15);
         label1.TabIndex = 1;
         label1.Text = "Location";
         // 
         // locationTextBox
         // 
         locationTextBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
         locationTextBox.Location = new Point(66, 36);
         locationTextBox.Name = "locationTextBox";
         locationTextBox.ReadOnly = true;
         locationTextBox.Size = new Size(126, 23);
         locationTextBox.TabIndex = 2;
         // 
         // label2
         // 
         label2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
         label2.AutoSize = true;
         label2.Location = new Point(3, 10);
         label2.Name = "label2";
         label2.Size = new Size(67, 15);
         label2.TabIndex = 3;
         label2.Text = "Realm Type";
         // 
         // realmTypeTextBox
         // 
         realmTypeTextBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
         realmTypeTextBox.Location = new Point(66, 7);
         realmTypeTextBox.Name = "realmTypeTextBox";
         realmTypeTextBox.ReadOnly = true;
         realmTypeTextBox.Size = new Size(126, 23);
         realmTypeTextBox.TabIndex = 4;
         // 
         // RealmTileInfoView
         // 
         AutoScaleDimensions = new SizeF(7F, 15F);
         AutoScaleMode = AutoScaleMode.Font;
         Controls.Add(realmTypeTextBox);
         Controls.Add(label2);
         Controls.Add(locationTextBox);
         Controls.Add(label1);
         Controls.Add(theInfluenceView);
         Name = "RealmTileInfoView";
         Size = new Size(195, 140);
         ResumeLayout(false);
         PerformLayout();
      }

      #endregion

      private InfluenceView theInfluenceView;
      private Label label1;
      private TextBox locationTextBox;
      private Label label2;
      private TextBox realmTypeTextBox;
   }
}
