using Balance.Core.Models;
using Balance.Core.Services;

namespace Balance.App;

public static class Globals
{
   public static MapViewState MapViewState { get; } = new();
   public static TileRenderer TileRenderer { get; } = new();
   public static PlayerContext PlayerContext { get; } = new();

   public static IRealmTileMapFactory MapFactory { get; } = new RealmTileMapFactory();
   public static IRealmTileMapPopulator MapPopulator { get; } = new RealmTileMapPopulator();
}

public class MapViewState
{
   public double ScaleFactor { get; set; } = 100;
}

public class TileRenderer
{
   public Size MapTileSize { get; } = new(96, 96);
   public int BorderSize { get; } = 4;
}

public class PlayerContext
{
   public Color GetPlayerColor(Player player) =>
      player switch
      {
         Player.One => Color.Red,
         Player.Two => Color.Green,
         Player.Three => Color.Blue,
         Player.Four => Color.Yellow,
         _ => throw new ArgumentOutOfRangeException(nameof(player), player, null)
      };
}
