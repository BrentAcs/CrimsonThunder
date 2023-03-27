using MongoDB.Bson;

namespace SeeYa.Core;

public interface IStoryNodeRepo
{
   IEnumerable<StoryNode> All { get; }

   IEnumerable<StoryNode> GetAllForStory(ObjectId storyId);
}

public class TestStoryNodeRepo : IStoryNodeRepo
{
   private readonly List<StoryNode> _storyNodes;

   public TestStoryNodeRepo()
   {
      _storyNodes = new List<StoryNode>(SeedData.StoryNodes);
   }

   public IEnumerable<StoryNode> All => _storyNodes;

   public IEnumerable<StoryNode> GetAllForStory(ObjectId storyId)
   { 
      throw new NotImplementedException();
      //var nodes = _storyNodes.Where( _ => _.)
   }
}
