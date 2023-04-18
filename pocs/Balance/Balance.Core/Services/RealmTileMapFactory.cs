using Balance.Core.Models;

namespace Balance.Core.Services;

public interface IRealmTileMapFactory
{
   public class Options
   {
      // TODO: Add size
   }

   RealmTileMap Create(Options options);
}

public class RealmTileMapFactory : IRealmTileMapFactory
{
   public RealmTileMap Create(IRealmTileMapFactory.Options options)
   {
      var mapSize = 11;

      var map = new RealmTileMap
      {
         Tiles = new RealmTile[mapSize, mapSize]
      };

      for (int col = 0; col < mapSize; col++)
      {
         for (int row = 0; row < mapSize; row++)
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
         RealmType = map.GetRealmType(coordinate),
         Owner = map.GetOwner(coordinate),
      };

      return tile;
   }
}
