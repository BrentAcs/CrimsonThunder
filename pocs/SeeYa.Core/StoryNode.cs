using CrimsonThunder.Common.Infrastructure.Storage;
using MongoDB.Bson;

namespace SeeYa.Core;

[BsonCollection("StoryNodes")]
public class StoryNode
{
   public ObjectId Id { get; set; }
   public string NarrativeText { get; set; } = string.Empty;
   public List<StoreNodeChoice> Choices { get; set; } = new();

   //public int? Chapter { get; set; }
}

public class StoreNodeChoice
{
   public string ChoiceText { get; set; } = string.Empty;
   public ObjectId? DestinationId { get; set; }
}
