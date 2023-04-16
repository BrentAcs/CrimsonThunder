namespace Balance.Core.Models;

public class RealmTile
{

}

public enum RealmTileMapQuadrant
{
   NorthWest = 1, 
   NorthEast, 
   SouthEast, 
   SouthWest,
}

public class RealmTileMap
{
   public RealmTile[,] Tiles { get; set; } = new RealmTile[1, 1];

   public int Width => Tiles.GetLength(0);
   public int Height => Tiles.GetLength(1);
   public int BorderRealmCol => Width / 2;
   public int BorderRealmRow => Height / 2;
   public Coordinate NexusRealmCoordinate => new(BorderRealmCol, BorderRealmRow);

   public bool IsNexusRealm(Coordinate coordinate) => coordinate == NexusRealmCoordinate;

   public bool IsBorderRealm(Coordinate coordinate)
   {
      if (IsNexusRealm(coordinate))
         return false;

      if(coordinate.Col == BorderRealmCol )
         return true;
      if (coordinate.Row == BorderRealmRow)
         return true;

      return false;
   }

   public Coordinate GetQuadrantHome(RealmTileMapQuadrant quadrant) =>
      quadrant switch
      {
         RealmTileMapQuadrant.NorthWest => Coordinate.Empty,
         RealmTileMapQuadrant.NorthEast => new Coordinate(BorderRealmCol + 1, 0),
         RealmTileMapQuadrant.SouthEast => new Coordinate(BorderRealmCol + 1, BorderRealmRow + 1),
         RealmTileMapQuadrant.SouthWest => new Coordinate(0, BorderRealmRow + 1),
         _ => throw new ArgumentOutOfRangeException(nameof(quadrant), quadrant, null)
      };
}

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
            map.Tiles[col, row] = CreateTile(coordinate);
         }
      }

      return map;
   }

   private RealmTile CreateTile(Coordinate coordinate)
   {
      return new RealmTile();
   }
}
