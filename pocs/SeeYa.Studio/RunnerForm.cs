using System.Diagnostics;
using SeeYa.Core;

namespace SeeYa.Studio;

public partial class RunnerForm : Form, IObserver<StoryNode>
{
   private readonly IStoryRunner _runner = new StoryRunner(Globals.Repos.StoryRepo, Globals.Repos.StoryNodeRepo);
   
   public RunnerForm()
   {
      InitializeComponent();
      _runner.Subscribe(this);
   }

   public DialogResult ShowDialog(IWin32Window? owner, string storyId)
   {
      Run(storyId);
      return ShowDialog(owner);
   }

   public void Run(string storyId)
   {
      _runner.Start(storyId);
   }

   public void OnCompleted()
   {
      Debug.WriteLine($"{nameof(OnCompleted)}");
   }

   public void OnError(Exception error)
   {
      Debug.WriteLine($"{nameof(OnError)}");
   }


   public void OnNext(StoryNode value)
   {
      Debug.WriteLine($"{nameof(OnNext)}");
   }

}
