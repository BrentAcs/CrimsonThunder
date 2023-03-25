// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


/*

   Raw Resource -> Refined Resource -> Product 
                                    -> Component -> Product 
                                                 -> Complex Component -> Product
 */



public interface ICraftingEntity
{
   int Id { get; }
}

public class RawResource : ICraftingEntity
{
   public int Id { get; set; }
   public string Name { get; set; } = string.Empty;
}


public abstract class BasePocRepo
{
   private int _nextId = 0;

   protected int NextId => _nextId++;
}

public class RawResourceRepo : BasePocRepo
{
   private IList<RawResource> _resources = new List<RawResource>();

   public RawResourceRepo()
   {
      Add("Copper Ore");      
      Add("Iron Ore");
      Add("Coal");    
   }
   
   public IEnumerable<RawResource> RawResources => _resources;

   public void Add(string name) =>
      _resources.Add(new RawResource{Id = NextId, Name = name});
}


