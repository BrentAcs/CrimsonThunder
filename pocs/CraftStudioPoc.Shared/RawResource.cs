namespace CraftStudioPoc.Shared;

public class RawResource : ICraftingEntity
{
   public int Id { get; set; }
   public string Name { get; set; } = string.Empty;
}

public interface IRawResourceCraftingTable : ICraftingTable<RawResource>
{
}

public class RawResourceCraftingTable : CraftingTable<RawResource>, IRawResourceCraftingTable
{
   public RawResourceCraftingTable()
   {
      Add("Copper Ore");
      Add("Iron Ore");
      Add("Coal");
   }

   private void Add(string name) =>
      Add(new RawResource { Name = name });
}


public class RefinedResource : ICraftingEntity
{
   public int Id { get; set; }
   public string Name { get; set; } = string.Empty;

}
