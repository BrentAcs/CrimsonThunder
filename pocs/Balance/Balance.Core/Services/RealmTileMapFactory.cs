using System.Drawing;
using Balance.Core.Models;

namespace Balance.Core.Services;

public interface IRealmTileMapFactory
{
   RealmTileMap Create(RealmTileMapFactory.Options? options = null);
}

public class RealmTileMapFactory : IRealmTileMapFactory
{
   public class Options
   {
      public Size MapSize { get; set; } = new(11, 11);

      public static Options Small => new() { MapSize = new Size(7, 7) };
      public static Options Medium => new() { MapSize = new Size(11, 11) };
      public static Options Large => new() { MapSize = new Size(15, 15) };
      public static Options ExtraLarge => new() { MapSize = new Size(19, 19) };
   }

   public RealmTileMap Create(Options? options)
   {
      options = options ?? new Options();

      var map = new RealmTileMap
      {
         Tiles = new RealmTile[options.MapSize.Width, options.MapSize.Height]
      };

      for (int col = 0; col < options.MapSize.Width; col++)
      {
         for (int row = 0; row < options.MapSize.Height; row++)
         {
            var coordinate = new Coordinate(col, row);
            map.Tiles[col, row] = CreateTile(map, coordinate);
         }
      }

      return map;
   }

   private RealmTile CreateTile(RealmTileMap map, Coordinate coordinate)
   {
      var tile = new RealmTile
      {
         Coordinate = coordinate,
         RealmType = map.GetRealmType(coordinate),
         Owner = map.GetOwner(coordinate),
      };

      return tile;
   }
}
