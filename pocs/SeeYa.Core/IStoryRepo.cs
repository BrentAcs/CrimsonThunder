namespace SeeYa.Core;

public interface IStoryRepo
{
   IEnumerable<Story> All { get; }
}

public class TestStoryRepo : IStoryRepo
{
   private readonly List<Story> _stories;

   public TestStoryRepo()
   {
      _stories = new List<Story>(SeedData.Stories);
   }

   public IEnumerable<Story> All => _stories;
}
