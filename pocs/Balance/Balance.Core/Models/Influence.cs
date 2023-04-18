namespace Balance.Core.Models;

public class Influence : IObservable<Influence>
{
   private readonly List<IObserver<Influence>> _observers = new();

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

   public IDisposable Subscribe(IObserver<Influence> observer)
   {
      if (!_observers.Contains(observer))
         _observers.Add(observer);

      return new UnSubscriber(_observers, observer);
   }

   private void CallObservers()
   {
      foreach (var observer in _observers)
      {
         observer.OnNext(this);
      }
   }

   private class UnSubscriber : IDisposable
   {
      private readonly List<IObserver<Influence?>> _observers;
      private readonly IObserver<Influence?> _observer;

      public UnSubscriber(List<IObserver<Influence?>> observers, IObserver<Influence?> observer)
      {
         _observers = observers;
         _observer = observer;
      }

      public void Dispose() => _observers?.Remove(_observer);
   }

}
