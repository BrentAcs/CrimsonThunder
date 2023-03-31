using SeeYa.Core.Models;

namespace SeeYa.Core.Services.Repos;

public interface IStoryNodeRepo
{
   IEnumerable<StoryNode> All { get; }

   IEnumerable<StoryNode> GetAllForStory(string storyId);
   StoryNode? Get(string storyId, string storyNodeId);
}

public class TestStoryNodeRepo : IStoryNodeRepo
{
   private readonly List<StoryNode> _storyNodes;

   public TestStoryNodeRepo()
   {
      _storyNodes = new List<StoryNode>(SeedData.StoryNodes);
   }

   public IEnumerable<StoryNode> All => _storyNodes;

   public IEnumerable<StoryNode> GetAllForStory(string storyId)
   {
      var nodes = _storyNodes.Where(_ => _.StoryId.Equals(ObjectId.Parse(storyId)));
      return nodes;
   }

   public StoryNode? Get(string storyId, string storyNodeId)
   {
      var node = _storyNodes.FirstOrDefault(_ => _.StoryId.Equals(ObjectId.Parse(storyId)) && _.Id.Equals(ObjectId.Parse(storyNodeId)));
      return node;
   }
}