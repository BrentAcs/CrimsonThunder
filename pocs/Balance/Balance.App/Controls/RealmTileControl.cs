using Balance.App.Extensions;

namespace Balance.App.Controls;

public partial class RealmTileControl : UserControl
{
   public RealmTileControl()
   {
      InitializeComponent();
   }

   private void RealmTileControl_Paint(object sender, PaintEventArgs e)
   {
      var g = e.Graphics;
      var rect = new Rectangle(Point.Empty, ClientSize);
      using var pen = new Pen(Color.Black, 2);
      g.DrawRoundedRectangle(pen, rect, 2);
   }
}
