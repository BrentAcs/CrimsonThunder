using MongoDB.Bson;

namespace SeeYa.Core;

public static class SeedData
{
   private static readonly ObjectId LinearSampleId = ObjectId.Parse("100000000000000000000000");
   private static readonly ObjectId NonLinearSampleId = ObjectId.Parse("200000000000000000000000");
  
   public static IEnumerable<Story> Stories => new List<Story>
   {
      new()
      {
         Id = LinearSampleId,
         Title = "Linear sample",
         Description = "A short sample with a linear story",
         InitialNodeId = ObjectId.Parse("000000000000000000000001")
      },
      new()
      {
         Id = NonLinearSampleId,
         Title = "Non-linear sample",
         Description = "A short sample with a branching story"
         //InitialNodeId = ObjectId.Parse("sn-1")
      }
   };

   public static IEnumerable<StoryNode> StoryNodes => new List<StoryNode>
   {
      new()
      {
         Id = ObjectId.Parse("000000000000000000000001"),
         StoryId = LinearSampleId,
         NarrativeText = "This is the start of our story.",
         Choices = new List<StoreNodeChoice>
         {
            new()
            {
               ChoiceText = "Continue on",
               DestinationId = ObjectId.Parse("000000000000000000000002"),
            }
         }
      },
      new()
      {
         Id = ObjectId.Parse("000000000000000000000002"),
         StoryId = LinearSampleId,
         NarrativeText = "This is the middle of our story.",
         Choices = new List<StoreNodeChoice>
         {
            new()
            {
               ChoiceText = "Continue on",
               DestinationId = ObjectId.Parse("000000000000000000000003"),
            }
         }
      },
      new()
      {
         Id = ObjectId.Parse("000000000000000000000003"),
         StoryId = LinearSampleId,
         NarrativeText = "This is the end of our story.",
         Choices = new List<StoreNodeChoice>
         {
            new()
            {
               ChoiceText = "Done",
               DestinationId = null,
            }
         }
      },

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
