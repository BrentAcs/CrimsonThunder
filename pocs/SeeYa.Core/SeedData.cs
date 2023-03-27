using MongoDB.Bson;

namespace SeeYa.Core;

public static class SeedData
{
   public static IEnumerable<Story> Stories = new List<Story>()
   {
      new()
      {
         Id = new ObjectId("story-1"), 
         Title = "Sample Story",
      }
   };
}
