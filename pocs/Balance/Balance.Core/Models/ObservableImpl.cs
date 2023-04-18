namespace Balance.Core.Models;

public class ObservableImpl<T> : IObservable<T>
{
   private readonly List<IObserver<T>> _observers = new();

   public IDisposable Subscribe(IObserver<T> observer)
   {
      if (!_observers.Contains(observer))
         _observers.Add(observer);

      return new UnSubscriber(_observers, observer);
   }

   public void Call(T observed)
   {
      foreach (var observer in _observers)
      {
         observer.OnNext(observed);
      }
   }

   private class UnSubscriber : IDisposable
   {
      private readonly List<IObserver<T?>> _observers;
      private readonly IObserver<T?> _observer;

      public UnSubscriber(List<IObserver<T?>> observers, IObserver<T?> observer)
      {
         _observers = observers;
         _observer = observer;
      }

      public void Dispose() => _observers?.Remove(_observer);
   }
}
