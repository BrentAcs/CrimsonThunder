using Microsoft.AspNetCore.Components;
using SeeYa.Core.Services;

namespace SeeYa.WebStudio.Pages;

public partial class StoryRunnerView
{
   [Inject]
   public IStoryNodeDataService StoryNodeDataService { get; set; }

   public string NarrativeText { get; set; } = "Sample narrative text";
   
   protected override void OnInitialized()
   {
   }
      
}
