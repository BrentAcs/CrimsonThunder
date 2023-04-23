using System.Dynamic;
using System.Numerics;
using Balance.Core.Models;
using Balance.Core.Extensions;
using Bass.Shared.Utilities;

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
   private readonly IRng _rng = new SimpleRng();

   private readonly List<StockStrategy> _stockStrategies = new()
   {
      new StandardRealmStockStrategy(),
      new BorderRealmStockStrategy(),
      new PlayerRealmStockStrategy(),
      new NexusRealmStockStrategy()
   };

   private readonly List<RandomStrategy> _randomStrategies;

   public RealmTileMapPopulator()
   {
      _randomStrategies = new()
      {
         new PlayerBorderRandomStrategy(_rng),
         new NonPlayerBorderRandomStrategy(_rng),
         new PlayerQuadrantRandomStrategy(_rng),
         new NonPlayerQuadrantRandomStrategy(_rng)
      };
   }

   public void Populate(RealmTileMap map, IRealmTileMapPopulator.Options options)
   {
      foreach (var tile in map.Tiles)
      {
         CallStrategiesForTile(map, tile);
      }

      foreach (var strategy in _randomStrategies)
      {
         strategy.Handle(map, 5 /* MAGIC NUMBER */ );
      }
   }

   private void CallStrategiesForTile(RealmTileMap map, RealmTile tile)
   {
      foreach (var strategy in _stockStrategies.Where(strategy => strategy.CanHandle(map, tile)))
      {
         strategy.Handle(map, tile);
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
      protected IRng Rng { get; }
      protected abstract int Count { get; }
      protected abstract IEnumerable<RealmTile> GetTiles(RealmTileMap map, Player player);

      private List<RealmTile> _tiles;
      private Dictionary<Coordinate, int> _placed = new();

      protected RandomStrategy(IRng rng)
      {
         Rng = rng;
      }

      private void Reset(RealmTileMap map, Player player)
      {
         _tiles = GetTiles(map, player).ToList();
         _placed.Clear();
      }

      private Coordinate GetRandomTile(int maxAddedPerRealm)
      {
         var rnd = Rng.Next(_tiles.Count);
         var coord = _tiles[rnd].Coordinate;
         _placed.TryAdd(coord, 0);
         var canAdd = _placed[coord] < maxAddedPerRealm;
         while (!canAdd)
         {
            rnd = Rng.Next(_tiles.Count);
            coord = _tiles[rnd].Coordinate;
            canAdd = _placed.ContainsKey(coord) && _placed[coord] < maxAddedPerRealm;
         }

         _placed[coord]++;
         return coord;
      }

      public void Handle(RealmTileMap map, int maxAddedPerRealm)
      {
         foreach (var player in Enum.GetValues<Player>().ExcludeNone())
         {
            Reset(map, player);
            for (int i = 0; i < Count; i++)
            {
               var coord = GetRandomTile(maxAddedPerRealm);
               map.Tiles[coord.Col, coord.Row].Influence.AddAmount(player, 1);
            }
         }
      }
   }

   public class PlayerBorderRandomStrategy : RandomStrategy
   {
      public PlayerBorderRandomStrategy(IRng rng) : base(rng)
      {
      }

      protected override int Count => 30;
      protected override IEnumerable<RealmTile> GetTiles(RealmTileMap map, Player player)
         => map.GetBorderTilesForPlayer(player);
   }

   public class NonPlayerBorderRandomStrategy : RandomStrategy
   {
      public NonPlayerBorderRandomStrategy(IRng rng) : base(rng)
      {
      }

      protected override int Count => 30;
      protected override IEnumerable<RealmTile> GetTiles(RealmTileMap map, Player player)
         => map.GetBorderTilesNotForPlayer(player);
   }

   public class PlayerQuadrantRandomStrategy : RandomStrategy
   {
      public PlayerQuadrantRandomStrategy(IRng rng) : base(rng)
      {
      }

      protected override int Count => 30;
      protected override IEnumerable<RealmTile> GetTiles(RealmTileMap map, Player player)
         => map.GetQuadrantTilesForPlayer(player);
   }

   public class NonPlayerQuadrantRandomStrategy : RandomStrategy
   {
      public NonPlayerQuadrantRandomStrategy(IRng rng) : base(rng)
      {
      }

      protected override int Count => 30;
      protected override IEnumerable<RealmTile> GetTiles(RealmTileMap map, Player player)
         => map.GetQuadrantTilesNotForPlayer(player);
   }

}
