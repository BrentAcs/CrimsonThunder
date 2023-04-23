using Balance.Core.Models;

namespace Balance.Core.Extensions;

public static class RealmTileExtensions
{
   public static Influence GetTotalInfluence(this IEnumerable<RealmTile> tiles)
   {
      var influence = new Influence();
      foreach (var player in Enum.GetValues<Player>().ExcludeNone())
      {
         var total = tiles.Sum(_ => _.Influence.GetAmount(player));
         influence.SetAmount(player, total);
      }

      return influence;
   }
}
