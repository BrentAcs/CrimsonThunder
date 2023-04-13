using CrimsonThunder.Common.Infrastructure.Storage;

namespace SeeYa.Core.Models;

[BsonCollection("StoryNodes")]
public class StoryNode
{
   // public ObjectId Id { get; set; }
   // public ObjectId StoryId { get; set; }
   public string Id { get; set; }
   public string StoryId { get; set; }
   public string NarrativeText { get; set; } = string.Empty;
   public List<StoreNodeChoice> Choices { get; set; } = new();

   //public int? Chapter { get; set; }
}