using System.Numerics;
using Balance.Core.Models;

namespace Balance.Core.Services;

public interface IRealmTileMapPopulator
{
   public class Options
   {
   }

   void Populate(RealmTileMap map, Options options);
}

public class RealmTileMapPopulator : IRealmTileMapPopulator
{
   private readonly List<Strategy> _strategies = new()
   {
      new StandardRealmStrategy(),
      new BorderRealmStrategy(),
      new PlayerRealmStrategy(),
      new NexusRealmStrategy()
   };

   public void Populate(RealmTileMap map, IRealmTileMapPopulator.Options options)
   {
      foreach (var tile in map.Tiles)
      {
         CallStrategies(map, tile);
      }
   }

   private void CallStrategies(RealmTileMap map, RealmTile tile)
   {
      foreach (var strategy in _strategies.Where(strategy => strategy.CanHandle(map, tile)))
      {
         strategy.Handle(map, tile);
      }
   }

   public abstract class Strategy
   {
      public abstract bool CanHandle(RealmTileMap map, RealmTile tile);
      public abstract void Handle(RealmTileMap map, RealmTile tile);
   }

   public class NexusRealmStrategy : Strategy
   {
      public override bool CanHandle(RealmTileMap map, RealmTile tile) => map.IsNexusRealm(tile.Coordinate);

      public override void Handle(RealmTileMap map, RealmTile tile)
      {
         tile.Influence.SetAmount(Player.One, 0);
         tile.Influence.SetAmount(Player.Two, 0);
         tile.Influence.SetAmount(Player.Three, 0);
         tile.Influence.SetAmount(Player.Four, 0);
      }
   }

   public class PlayerRealmStrategy : Strategy
   {
      public override bool CanHandle(RealmTileMap map, RealmTile tile) => map.IsPlayerRealm(tile.Coordinate);

      public override void Handle(RealmTileMap map, RealmTile tile)
      {
         tile.Influence.SetAmount(tile.Owner, 50);
      }
   }

   public class StandardRealmStrategy : Strategy
   {
      public override bool CanHandle(RealmTileMap map, RealmTile tile) => map.IsStandardRealm(tile.Coordinate);

      public override void Handle(RealmTileMap map, RealmTile tile)
      {
         var quadrant = map.GetQuadrant(tile.Coordinate);
         var player = map.GetQuadrantPlayer(quadrant);
         tile.Influence.SetAmount(player, 5);
      }
   }

   public class BorderRealmStrategy : Strategy
   {
      public override bool CanHandle(RealmTileMap map, RealmTile tile) => map.IsBorderRealm(tile.Coordinate);

      public override void Handle(RealmTileMap map, RealmTile tile)
      {
         var players = map.GetBorderPlayers(tile.Coordinate);
         foreach (var player in players)
         {
            tile.Influence.SetAmount(player, 15);
         }
      }
   }
}
