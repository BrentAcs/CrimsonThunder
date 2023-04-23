using Balance.Core.Extensions;
using Balance.Core.Models;
using FluentAssertions;

namespace Balance.Core.Tests.Extensions;

public class RealmTileExtensionsTests
{
   [Theory]
   [InlineData(10,20,30,40,Player.One,30)]
   [InlineData(10, 20, 30, 40, Player.Two, 60)]
   [InlineData(10, 20, 30, 40, Player.Three, 90)]
   [InlineData(10, 20, 30, 40, Player.Four, 120)]
   public void GetTotalInfluence_Theories(int p1, int p2, int p3, int p4, Player player, int expected)
   {
      var tiles = new List<RealmTile>
      {
         new()
         {
            Influence = new(p1, p2, p3, p4)
         },
         new()
         {
            Influence = new(p1, p2, p3, p4)
         },
         new()
         {
            Influence = new(p1, p2, p3, p4)
         },
      };

      tiles.GetTotalInfluence().GetAmount(player).Should().Be(expected);
   }
}
