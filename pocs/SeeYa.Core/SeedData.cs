using MongoDB.Bson;

namespace SeeYa.Core;

public static class SeedData
{
   public static IEnumerable<Story> Stories => new List<Story>
   {
      new()
      {
         Id = ObjectId.Parse("100000000000000000000000"),
         Title = "Sample Story (linear)",
         //InitialNodeId = ObjectId.Parse("sn-1")
      },
      new()
      {
         Id = ObjectId.Parse("100000000000000000000000"),
         Title = "Sample Story (non-linear)",
         //InitialNodeId = ObjectId.Parse("sn-1")
      }
   };

   public static IEnumerable<StoryNode> StoryNodes => new List<StoryNode>
   {
      //new()
      //{
      //   Id = new ObjectId("sn-1"),
      //   StoryId = ObjectId.Parse("story-1"),
      //   NarrativeText = "This is the start of our story.",
      //   Choices = new List<StoreNodeChoice>
      //   {
      //      new()
      //      {
      //         ChoiceText = "Continue on",
      //         DestinationId = ObjectId.Parse("sn-2"),
      //      }
      //   }
      //},
      //new()
      //{
      //   Id = new ObjectId("sn-2"),
      //   StoryId = ObjectId.Parse("story-1"),
      //   NarrativeText = "This is the middle of our story.",
      //   Choices = new List<StoreNodeChoice>
      //   {
      //      new()
      //      {
      //         ChoiceText = "Continue on",
      //         DestinationId = ObjectId.Parse("sn-3"),
      //      }
      //   }
      //},
      //new()
      //{
      //   Id = new ObjectId("sn-3"),
      //   StoryId = ObjectId.Parse("story-1"),
      //   NarrativeText = "This is the end of our story.",
      //   Choices = new List<StoreNodeChoice>
      //   {
      //      new()
      //      {
      //         ChoiceText = "Done",
      //         DestinationId = null,
      //      }
      //   }
      //},

      /////////

      //new()
      //{
      //   Id = ObjectId.Parse("sn-1"),
      //   StoryId = ObjectId.Parse("story-1"),
      //   NarrativeText = "This is the start of our story.",
      //   Choices = new List<StoreNodeChoice>
      //   {
      //      new()
      //      {
      //         ChoiceText = "Continue on",
      //         DestinationId = ObjectId.Parse("sn-2"),
      //      }
      //   }
      //},
      //new()
      //{
      //   Id = ObjectId.Parse("sn-2"),
      //   StoryId = ObjectId.Parse("story-1"),
      //   NarrativeText = "This is the start of our story.",
      //   Choices = new List<StoreNodeChoice>
      //   {
      //      new()
      //      {
      //         ChoiceText = "Go Left",
      //         DestinationId = null,
      //      },
      //      new()
      //      {
      //         ChoiceText = "Go Right",
      //         DestinationId = null,
      //      }
      //   }
      //}

   };
}
