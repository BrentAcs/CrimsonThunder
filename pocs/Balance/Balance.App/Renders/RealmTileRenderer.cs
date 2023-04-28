using Balance.App.Extensions;
using Balance.Core.Models;

namespace Balance.App.Renders;

public class RealmTileRenderer
{
   private readonly Dictionary<RealmType, Strategy> _strategies = new()
   {
      { RealmType.Nexus, new NexusStrategy()},
      { RealmType.Border, new BorderStrategy()},
      { RealmType.Player, new PlayerStrategy()},
      { RealmType.Standard, new StandardStrategy()}
   };

   private InfluenceRenderer _influenceRenderer = new(0);

   public void Render(Graphics g, Rectangle rect, RealmTile tile)
   {
      if (!_strategies.TryGetValue(tile.RealmType, out var strategy))
         return;

      strategy.Render(g, rect, tile);

      // IDEA HERE
      //var influenceRect = rect;
      //influenceRect.Inflate(-rect.Width / 2, -rect.Height / 2);
      //_influenceRenderer.Render(g, influenceRect, tile.Influence);
   }

   public abstract class Strategy
   {
      protected virtual Color GetBackColor(RealmTile tile ) => Color.LightBlue;

      public void Render(Graphics g, Rectangle rect, RealmTile tile)
      {
         using var pen = new Pen(Color.Black, Globals.TileRendererOptions.BorderSize);
         using var brush = new SolidBrush(GetBackColor(tile));
         g.FillRectangle(brush, rect);
         g.DrawRoundedRectangle(pen, rect, Globals.TileRendererOptions.BorderSize);
      }
   }

   public class NexusStrategy : Strategy
   {
      protected override Color GetBackColor(RealmTile tile) => Color.Gray;
   }

   public class BorderStrategy : Strategy
   {
      protected override Color GetBackColor(RealmTile tile) => Color.Gray;
   }

   public class PlayerStrategy : Strategy
   {
      protected override Color GetBackColor(RealmTile tile) => Globals.PlayerContext.GetPlayerColor(tile.Owner); 
   }

   public class StandardStrategy : Strategy
   {
      protected override Color GetBackColor(RealmTile tile) => Color.DimGray;
   }
}
