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
   private readonly ObservableImpl<RealmTile> _tileObservables = new();

   public Coordinate Coordinate { get; set; } = Coordinate.Empty;
   public RealmType RealmType { get; set; }
   public Player Owner { get; set; } = Player.None;
   public Influence Influence { get; set; } = new();

   public RealmTile()
   {
      Influence.Subscribe(this);
   }

   public IDisposable Subscribe(IObserver<RealmTile> observer) => _tileObservables.Subscribe(observer);

   private void CallObservers() => _tileObservables.Call(this);

   public void OnCompleted() => Debug.WriteLine($"{nameof(OnCompleted)}");

   public void OnError(Exception error) => Debug.WriteLine($"{nameof(OnError)}");

   public void OnNext(Influence value) => CallObservers();
}
