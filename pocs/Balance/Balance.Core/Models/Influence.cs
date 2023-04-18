using System;

namespace Balance.Core.Models;

public class Influence : IObservable<Influence>
{
   private readonly ObservableImpl<Influence> _influenceObservables = new();

   private readonly Dictionary<Player, int> _map = new();

   public Influence()
   {
      _map[Player.One] = 0;
      _map[Player.Two] = 0;
      _map[Player.Three] = 0;
      _map[Player.Four] = 0;
   }

   public int this[Player player] => GetAmount(player);

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

   public IDisposable Subscribe(IObserver<Influence> observer) => _influenceObservables.Subscribe(observer);

   private void CallObservers() => _influenceObservables.Call(this);
}
