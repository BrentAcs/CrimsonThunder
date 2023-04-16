using Balance.Core.Models;

namespace Balance.App;

public static class Globals
{
   public static MapViewState MapViewState { get; } = new();
   public static TileRenderer TileRenderer { get; } = new();
   public static IRealmTileMapFactory MapFactory { get; } = new RealmTileMapFactory();
}

public class MapViewState
{
   public double ScaleFactor { get; set; } = 100;
}

public class TileRenderer
{
   public Size MapTileSize { get; } = new Size(128, 128);
   public int BorderSize { get; } = 4;
}
