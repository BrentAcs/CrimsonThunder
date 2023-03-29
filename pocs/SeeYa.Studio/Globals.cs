using SeeYa.Core;

namespace SeeYa.Studio;

public static class Globals
{
   public static class Repos
   {
      public static IStoryRepo StoryRepo => new TestStoryRepo();
      public static IStoryNodeRepo StoryNodeRepo => new TestStoryNodeRepo();
   }
}
