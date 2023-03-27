namespace SeeYa.Core;

public interface IStoryRepo
{
   IEnumerable<StoryNode> All { get; }
}
