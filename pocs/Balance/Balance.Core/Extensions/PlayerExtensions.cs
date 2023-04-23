using Balance.Core.Models;

namespace Balance.Core.Extensions;

public static class PlayerExtensions
{
   public static IEnumerable<Player> ExcludeNone(this IEnumerable<Player> players) => players.Where(_ => _ != Player.None);
}
