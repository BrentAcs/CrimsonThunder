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
   public int QuadrantHeight => (Height / 2);
   public Delta PlayerRealmDelta => new(QuadrantWidth / 2, QuadrantHeight / 2);

   public bool IsNexusRealm(Coordinate coordinate) => coordinate == NexusRealmCoordinate;

   public bool IsBorderRealm(Coordinate coordinate)
   {
      if (IsNexusRealm(coordinate))
         return false;

      if (coordinate.Col == BorderRealmCol)
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
         var testCoordinate = quadrantHome.Offset(PlayerRealmDelta);
         if (testCoordinate == coordinate)
            return true;
      }

      return false;
   }

   public bool IsStandardRealm(Coordinate coordinate) => !IsNexusRealm(coordinate) && !IsBorderRealm(coordinate) && !IsPlayerRealm(coordinate);

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
      if (IsPlayerRealm(coordinate))
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

   public RealmTileMapQuadrant GetQuadrant(Coordinate coordinate)
   {
      foreach (var quadrant in Enum.GetValues<RealmTileMapQuadrant>())
      {
         if (IsInQuadrant(coordinate, quadrant))
            return quadrant;
      }

      throw new InvalidOperationException();
   }

   public bool IsPlayerQuadrant(RealmTileMapQuadrant quadrant, Player player)
   {
      var quadrantHome = GetQuadrantHome(quadrant);
      var testCoordinate = quadrantHome.Offset(PlayerRealmDelta);

      return Tiles[testCoordinate.Col, testCoordinate.Row].Owner == player;
   }

   public Player GetQuadrantPlayer(RealmTileMapQuadrant quadrant)
   {
      var quadrantHome = GetQuadrantHome(quadrant);
      var testCoordinate = quadrantHome.Offset(PlayerRealmDelta);

      return Tiles[testCoordinate.Col, testCoordinate.Row].Owner;
   }

   public Border GetBorder(Coordinate coordinate)
   {
      if (coordinate.Col == BorderRealmCol && coordinate.Row < BorderRealmRow)
         return Border.North;

      if (coordinate.Col == BorderRealmCol && coordinate.Row > BorderRealmRow)
         return Border.South;

      if (coordinate.Row == BorderRealmRow && coordinate.Col < BorderRealmCol)
         return Border.West;

      if (coordinate.Row == BorderRealmRow && coordinate.Col > BorderRealmCol)
         return Border.East;

      return Border.None;
   }

   public IEnumerable<Player> GetBorderPlayers(Coordinate coordinate) =>
      GetBorder(coordinate) switch
      {
         Border.None => new List<Player>(),
         Border.North => new List<Player> { Player.One, Player.Two },
         Border.South => new List<Player> { Player.Three, Player.Four },
         Border.East => new List<Player> { Player.Two, Player.Three },
         Border.West => new List<Player> { Player.Four, Player.One },
         _ => throw new ArgumentOutOfRangeException()
      };
}
