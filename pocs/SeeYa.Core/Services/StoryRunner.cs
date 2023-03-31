using SeeYa.Core.Models;
using SeeYa.Core.Services.Repos;

namespace SeeYa.Core.Services;

public interface IStoryRunner : IObservable<StoryNode?>
{
   Story? CurrentStory { get; }
   StoryNode? CurrentStoryNode { get; }

   void Start(string storyId);
   void Next(string nextStoryNodeId);
}

public class StoryRunner : IStoryRunner
{
   private readonly List<IObserver<StoryNode>> _observers = new();
   private readonly IStoryRepo _storyRepo;
   private readonly IStoryNodeRepo _storyNodeRepo;

   public StoryRunner(IStoryRepo storyRepo, IStoryNodeRepo storyNodeRepo)
   {
      _storyRepo = storyRepo;
      _storyNodeRepo = storyNodeRepo;
   }

   public Story? CurrentStory { get; private set; }
   public StoryNode? CurrentStoryNode { get; private set; }

   public IDisposable Subscribe(IObserver<StoryNode> observer)
   {
      if (! _observers.Contains(observer))
         _observers.Add(observer);

      return new Unsubscriber(_observers, observer);
   }

   // NOTE: To Task<>
   public void Start(string storyId)
   {
      CurrentStory = _storyRepo.GetAll().Result.FirstOrDefault(_ => _.Id.Equals(new ObjectId(storyId)));
      CurrentStoryNode = _storyNodeRepo.Get(storyId, CurrentStory.InitialNodeId.ToString());
      CallObservers();
   }

   public void Next(string nextStoryNodeId)
   {
      CurrentStoryNode = _storyNodeRepo.Get(CurrentStory.Id.ToString(), nextStoryNodeId);
      CallObservers();
   }

   private void CallObservers()
   {
      foreach (var observer in _observers)
      {
         observer.OnNext(CurrentStoryNode);
      }
   }

   private class Unsubscriber : IDisposable
   {
      private List<IObserver<StoryNode?>> _observers;
      private IObserver<StoryNode?> _observer;

      public Unsubscriber(List<IObserver<StoryNode?>> observers, IObserver<StoryNode?> observer)
      {
         this._observers = observers;
         this._observer = observer;
      }

      public void Dispose() =>
         _observers?.Remove(_observer);
   }
}