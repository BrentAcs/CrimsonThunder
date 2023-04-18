namespace Balance.Core.Models;

public enum RealmTileMapQuadrant
{
   NorthWest = 1,
   NorthEast,
   SouthEast,
   SouthWest,
}

public enum Player
{
   None = 0,
   One = 1,
   Two,
   Three,
   Four,
}

public enum RealmType
{
   Nexus = 1,
   Border,
   Player,
   Standard,
}

public class RealmTile
{
   public RealmType RealmType { get; set; }
   public Player Owner { get; set; } = Player.None;
}
