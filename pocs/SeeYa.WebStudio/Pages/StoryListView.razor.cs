using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web.Virtualization;
using SeeYa.Core.Models;
using SeeYa.Core.Services;

namespace SeeYa.WebStudio.Pages;

public partial class StoryListView
{
   [Inject]
   public IStoryDataService StoryDataService { get; set; }
   
   public List<Story> Stories { get; set; } = new();

   protected override async Task OnInitializedAsync()
   {
      Stories = (await StoryDataService.GetAll().ConfigureAwait(false)).ToList();
   }

   private readonly float itemHeight = 10;
   private int _totalNumberOfStories = 10;
   
   public async ValueTask<ItemsProviderResult<Story>> LoadStories(ItemsProviderRequest request)
   {
      //assume that we have asked the API the total number in a separate call
      //var numberOfEmployees = Math.Min(request.Count, _totalNumberOfStories - request.StartIndex);
      //var EmployeeListItems = await StoryDataService.GetAll(request.StartIndex, numberOfEmployees);
      
      var stories = await StoryDataService.GetAll();
      return new ItemsProviderResult<Story>(stories, _totalNumberOfStories);
   }
}
