using MongoDB.Bson;

namespace SeeYa.Core;

public static class SeedData
{
   public static IEnumerable<Story> Stories = new List<Story>
   {
      new()
      {
         Id = ObjectId.Parse("story-1"),
         Title = "Sample Story",
      }
   };

   public static IEnumerable<StoryNode> StoryNodes = new List<StoryNode>
   {
      new()
      {
         Id = ObjectId.Parse("s1-sn-1"),
         NarrativeText = "This is the start of our story.",
         Choices = new List<StoreNodeChoice>
         {
            new()
            {
               ChoiceText = "Go Left",
               DestinationId = null,
            },
            new()
            {
               ChoiceText = "Go Right",
               DestinationId = null,
            }
         }
      }
   };
}
