using Balance.App.Extensions;

namespace Balance.App.Controls;

public partial class RealmTileControl : UserControl
{
   public RealmTileControl()
   {
      InitializeComponent();
   }

   protected virtual Color RealmBackColor => Color.White;

   protected override void OnCreateControl()
   {
      BackColor = RealmBackColor;
      base.OnCreateControl();
   }

   private void RealmTileControl_Paint(object sender, PaintEventArgs e)
   {
      var g = e.Graphics;
      var rect = new Rectangle(Point.Empty, ClientSize);
      using var pen = new Pen(Color.Black, Globals.TileRenderer.BorderSize);
      g.DrawRoundedRectangle(pen, rect, Globals.TileRenderer.BorderSize);
   }
}

public class NexusRealmTileControl : RealmTileControl
{
   protected override Color RealmBackColor => Color.DimGray;
}

public class BorderRealmTileControl : RealmTileControl
{
   protected override Color RealmBackColor => Color.DarkGray;
}
