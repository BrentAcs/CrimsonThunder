using Balance.Core.Models;

namespace Balance.App.Controls;

public class RealmTileToolTip : ToolTip
{
   private InfluenceRenderer _renderer = new( 2/*BorderSize*/);

   public RealmTileToolTip()
   {
      OwnerDraw = true;
      Popup += OnPopup;
      Draw += OnDraw;
   }

   private void OnPopup(object sender, PopupEventArgs e) // use this event to set the size of the tool tip
   {
      e.ToolTipSize = new Size(200, 100);
   }

   private void OnDraw(object sender, DrawToolTipEventArgs e) // use this event to customise the tool tip
   {
      var g = e.Graphics;
      _renderer.Render(g, e.Bounds, new Influence(10,20,30,40));
   }
}
