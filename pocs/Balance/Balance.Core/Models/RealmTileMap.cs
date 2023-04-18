using Balance.Core.Extensions;

namespace Balance.Core.Models;

public class RealmTileMap
{
   public RealmTile[,] Tiles { get; set; } = new RealmTile[1, 1];

   public int Width => Tiles.GetLength(0);
   public int Height => Tiles.GetLength(1);
   public int BorderRealmCol => Width / 2;
   public int BorderRealmRow => Height / 2;
   public Coordinate NexusRealmCoordinate => new(BorderRealmCol, BorderRealmRow);
   public int QuadrantWidth => (Width / 2);
   public int QuadrantHeight => (Height/ 2);

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

   public bool IsPlayerRealm(Coordinate coordinate)
   {
      foreach (var quadrant in Enum.GetValues<RealmTileMapQuadrant>())
      {
         var quadrantHome = GetQuadrantHome(quadrant);
         var delta = new Delta(QuadrantWidth / 2, QuadrantHeight / 2);
         var testCoordinate = quadrantHome.Offset(delta);
         if(testCoordinate == coordinate)
            return true;
      }

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

   public RealmType GetRealmType(Coordinate coordinate)
   {
      if (IsNexusRealm(coordinate))
         return RealmType.Nexus;
      if( IsPlayerRealm(coordinate))
         return RealmType.Player;

      return IsBorderRealm(coordinate) ? RealmType.Border : RealmType.Standard;
   }

   public Player GetOwner(Coordinate coordinate)
   {
      if (!IsPlayerRealm(coordinate))
         return Player.None;

      foreach (var quadrant in Enum.GetValues<RealmTileMapQuadrant>())
      {
         if (IsInQuadrant(coordinate, quadrant))
            return quadrant.GetPlayer();
      }

      throw new InvalidOperationException();
   }

   public bool IsInQuadrant(Coordinate coordinate, RealmTileMapQuadrant quadrant)
   {
      var home = GetQuadrantHome(quadrant);
      return (coordinate.Col >= home.Col) &&
             (coordinate.Row >= home.Row) &&
             (coordinate.Col < home.Col + QuadrantWidth) &&
             (coordinate.Row < home.Row + QuadrantHeight);
   }
}
