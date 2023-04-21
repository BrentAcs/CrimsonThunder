using System.Dynamic;
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
   private readonly List<StockStrategy> _stockStrategies = new()
   {
      new StandardRealmStockStrategy(),
      new BorderRealmStockStrategy(),
      new PlayerRealmStockStrategy(),
      new NexusRealmStockStrategy()
   };

   private readonly List<RandomStrategy> _randomStrategies = new() { new PlayerBorderRandomStrategy() };

   public void Populate(RealmTileMap map, IRealmTileMapPopulator.Options options)
   {
      foreach (var tile in map.Tiles)
      {
         CallStrategies(map, tile);
      }
   }

   private void CallStrategies(RealmTileMap map, RealmTile tile)
   {
      foreach (var strategy in _stockStrategies.Where(strategy => strategy.CanHandle(map, tile)))
      {
         strategy.Handle(map, tile);
      }

      foreach (var strategy in _randomStrategies)
      {
         strategy.Handle(map, 5 /* MAGIC NUMBER */ );
      }
   }

   // -- Stock strategies

   public abstract class StockStrategy
   {
      public abstract bool CanHandle(RealmTileMap map, RealmTile tile);
      public abstract void Handle(RealmTileMap map, RealmTile tile);
   }

   public class NexusRealmStockStrategy : StockStrategy
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

   public class PlayerRealmStockStrategy : StockStrategy
   {
      public override bool CanHandle(RealmTileMap map, RealmTile tile) => map.IsPlayerRealm(tile.Coordinate);

      public override void Handle(RealmTileMap map, RealmTile tile)
      {
         tile.Influence.SetAmount(tile.Owner, 50);
      }
   }

   public class StandardRealmStockStrategy : StockStrategy
   {
      public override bool CanHandle(RealmTileMap map, RealmTile tile) => map.IsStandardRealm(tile.Coordinate);

      public override void Handle(RealmTileMap map, RealmTile tile)
      {
         var quadrant = map.GetQuadrant(tile.Coordinate);
         var player = map.GetQuadrantPlayer(quadrant);
         tile.Influence.SetAmount(player, 5);
      }
   }

   public class BorderRealmStockStrategy : StockStrategy
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

   // -- Random strategies

   public abstract class RandomStrategy
   {
      protected abstract int Count { get; }
      protected abstract IEnumerable<Coordinate> GetCoordinates();

      public void Handle(RealmTileMap map, int maxAddedPerRealm)
      {
         var placed = new Dictionary<Coordinate, int>();
         for (int i = 0; i < Count; i++)
         {

         }
      }
   }

   public class PlayerBorderRandomStrategy : RandomStrategy
   {
      protected override int Count => 30;
      protected override IEnumerable<Coordinate> GetCoordinates() => throw new NotImplementedException();
   }

   

}
