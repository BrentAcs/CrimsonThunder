using Balance.Core.Models;
using FluentAssertions;

namespace Balance.Core.Tests.Models;

public class InfluenceTests
{
   [Theory]
   [InlineData(0, 0, 0, 0, Player.One, 0)]
   [InlineData(0, 25, 25, 50, Player.One, 0)]
   [InlineData(0, 25, 25, 50, Player.Two, .25)]
   [InlineData(0, 25, 25, 50, Player.Three, .25)]
   [InlineData(0, 25, 25, 50, Player.Four, .5)]
   public void GetPercentage_Theories(int p1, int p2, int p3, int p4, Player player, float expected)
   {
      var sut = new Influence(p1, p2, p3, p4);

      sut.GetPercentage(player).Should().BeApproximately(expected, 0.001f);
   }
}
