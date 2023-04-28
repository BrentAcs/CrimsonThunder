using System;
using Balance.Core.Extensions;

namespace Balance.Core.Models;

public class Influence : IObservable<Influence>
{
   private readonly ObservableImpl<Influence> _influenceObservables = new();

   private readonly Dictionary<Player, int> _map = new();

   public Influence()
   {
      foreach (var player in Enum.GetValues<Player>().OnboardOnly())
      {
         _map[player] = 0;
      }
   }

   public Influence(int p1, int p2, int p3, int p4)
   {
      _map[Player.One] = p1;
      _map[Player.Two] = p2;
      _map[Player.Three] = p3;
      _map[Player.Four] = p4;
   }

   public int this[Player player] => GetAmount(player);

   //public int MaximumAmount => _map.Values.Max();

   //public int MinimumAmount => _map.Values.Min();

   public int TotalAmount => _map.Sum(_ => _.Value);

   public int GetAmount(Player player) => _map[player];

   public void SetAmount(Player player, int amount)
   {
      _map[player] = amount;
      CallObservers();
   }

   public int AddAmount(Player player, int amount)
   {
      _map[player] += amount;
      CallObservers();
      return _map[player];
   }

   public float GetPercentage(Player player)
   {
      if (TotalAmount == 0)
         return 0;
      
      return _map[player] / (float)TotalAmount;
   }

   public IDisposable Subscribe(IObserver<Influence> observer) => _influenceObservables.Subscribe(observer);

   private void CallObservers() => _influenceObservables.Call(this);
}
