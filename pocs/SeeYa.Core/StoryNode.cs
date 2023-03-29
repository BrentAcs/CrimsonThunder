using CrimsonThunder.Common.Infrastructure.Storage;
using MongoDB.Bson;

namespace SeeYa.Core;

[BsonCollection("Stories")]
public class Story
{
   public ObjectId Id { get; set; }
   public string Title { get; set; } = string.Empty;
   public ObjectId InitialNodeId { get; set; }

   public override string ToString() => Title;
}

[BsonCollection("StoryNodes")]
public class StoryNode
{
   public ObjectId Id { get; set; }
   public ObjectId StoryId { get; set; }
   public string NarrativeText { get; set; } = string.Empty;
   public List<StoreNodeChoice> Choices { get; set; } = new();

   //public int? Chapter { get; set; }
}

public class StoreNodeChoice
{
   public string ChoiceText { get; set; } = string.Empty;
   public ObjectId? DestinationId { get; set; }
}
