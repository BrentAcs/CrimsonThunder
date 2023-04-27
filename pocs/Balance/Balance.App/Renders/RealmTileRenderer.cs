using Balance.App.Controls;
using Balance.App.Extensions;
using Balance.Core.Models;

namespace Balance.App.Renders;

public class RealmTileRenderer
{
   public MapDisplayOptions Options { get; set; } = new();

   public void Render(Graphics g, Rectangle rect, RealmTile tile)
   {
      using var pen = new Pen(Color.Black, Globals.TileRenderer.BorderSize);
      g.DrawRoundedRectangle(pen, rect, Globals.TileRenderer.BorderSize);
   }
}
