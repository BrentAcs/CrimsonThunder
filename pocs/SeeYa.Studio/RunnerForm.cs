using System.Diagnostics;
using SeeYa.Core;
using Control = System.Windows.Forms.Control;

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

   public void OnNext(StoryNode storyNode) => SetupUI(storyNode);

   private void ChoiceClicked(object? sender, EventArgs e)
   {
      var choice = (sender as Control)?.Tag as StoreNodeChoice;
      if (choice == null)
         return;

      _runner.Next(choice.DestinationId.ToString());
   }

   private void SetupUI(StoryNode storyNode)
   {
      mainSplitContainer.Panel2.Controls.Clear();
      narrativeTextBox.Text = storyNode.NarrativeText;

      foreach (var choice in storyNode.Choices)
      {
         var choiceButton = new Button
         {
            Text = choice.ChoiceText,
            Tag = choice,
            Dock = DockStyle.Bottom,
            Height = 32,
         };
         choiceButton.Click += ChoiceClicked;
         mainSplitContainer.Panel2.Controls.Add(choiceButton);
      }
   }
}
