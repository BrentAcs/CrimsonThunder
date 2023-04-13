using System.Diagnostics;
using SeeYa.Core.Models;

namespace SeeYa.Core.Services.Repos;

public interface IStoryRepo
{
   Task<IEnumerable<Story>> GetAll();
}

public class TestStoryRepo : IStoryRepo
{
   private readonly List<Story> _stories;

   public TestStoryRepo()
   {
      try
      {
         _stories = new List<Story>(SeedData.Stories);
      }
      catch (Exception ex)
      {
         Debug.WriteLine(ex);
         throw;
      }
   }

   public async Task<IEnumerable<Story>> GetAll() => await Task.FromResult(_stories).ConfigureAwait(false);
}
