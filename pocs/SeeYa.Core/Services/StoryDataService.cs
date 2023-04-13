using SeeYa.Core.Models;
using SeeYa.Core.Services.Repos;

namespace SeeYa.Core.Services;

public interface IStoryDataService
{
   Task<IEnumerable<Story>> GetAll();
}

public class StoryDataService : IStoryDataService
{
   private readonly IStoryRepo _storyRepo;

   public StoryDataService(IStoryRepo storyRepo)
   {
      _storyRepo = storyRepo;
   }
   
   public async Task<IEnumerable<Story>> GetAll() =>
      await _storyRepo.GetAll().ConfigureAwait(false);
}
