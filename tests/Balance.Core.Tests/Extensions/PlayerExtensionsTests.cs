using Balance.Core.Extensions;
using Balance.Core.Models;
using FluentAssertions;

namespace Balance.Core.Tests.Extensions;

public class PlayerExtensionsTests
{
   [Fact]
   public void OnboardOnly_Test()
   {
      Enum.GetValues<Player>().OnboardOnly().Should().Contain( new[] { Player.One, Player.Two, Player.Three, Player.Four});
   }
}
