using System;
using System.Diagnostics;

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

public class RealmTile : IObservable<RealmTile>, IObserver<Influence>
{
   private readonly List<IObserver<RealmTile>> _observers = new();

   public RealmType RealmType { get; set; }
   public Player Owner { get; set; } = Player.None;
   public Influence Influence { get; set; } = new();

   public RealmTile()
   {
      Influence.Subscribe(this);
   }

   public IDisposable Subscribe(IObserver<RealmTile> observer)
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
      private readonly List<IObserver<RealmTile?>> _observers;
      private readonly IObserver<RealmTile?> _observer;

      public UnSubscriber(List<IObserver<RealmTile?>> observers, IObserver<RealmTile?> observer)
      {
         _observers = observers;
         _observer = observer;
      }

      public void Dispose() => _observers?.Remove(_observer);
   }

   public void OnCompleted() => Debug.WriteLine($"{nameof(OnCompleted)}");

   public void OnError(Exception error) => Debug.WriteLine($"{nameof(OnError)}");

   public void OnNext(Influence value) => CallObservers();
}
