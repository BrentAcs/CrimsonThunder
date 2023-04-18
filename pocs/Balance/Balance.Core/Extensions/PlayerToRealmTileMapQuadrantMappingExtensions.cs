using System.Diagnostics;
using Balance.Core.Models;

namespace Balance.Core.Extensions;

public static class PlayerToRealmTileMapQuadrantMappingExtensions
{
   private class Mapping
   {
      public Mapping(Player player, RealmTileMapQuadrant quadrant)
      {
         Player = player;
         Quadrant = quadrant;
      }

      public Player Player { get; set; }
      public RealmTileMapQuadrant Quadrant { get; set; }
   }

   private static readonly List<Mapping> _mapping = new()
   {
      new Mapping( Player.One, RealmTileMapQuadrant.NorthWest ),
      new Mapping( Player.Two, RealmTileMapQuadrant.NorthEast ),
      new Mapping( Player.Three, RealmTileMapQuadrant.SouthEast ),
      new Mapping( Player.Four, RealmTileMapQuadrant.SouthWest ),
   };

   public static Player GetPlayer(this RealmTileMapQuadrant quadrant) => _mapping.First(_ => _.Quadrant == quadrant).Player;
   public static RealmTileMapQuadrant GetQuadrant(this Player player) => _mapping.First(_ => _.Player == player).Quadrant;
}
