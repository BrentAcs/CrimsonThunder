using CrimsonThunder.Common.Infrastructure.Storage;

namespace SeeYa.Core.Models;

[BsonCollection("Stories")]
public class Story
{
   // public ObjectId Id { get; set; }
   public string Id { get; set; } 
   public string Title { get; set; } = string.Empty;
   public string Description {get;set; } = string.Empty;
   // public ObjectId InitialNodeId { get; set; }
   public string InitialNodeId { get; set; }

   public override string ToString() => Title;
}
