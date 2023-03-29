using System.Reflection;

namespace CraftStudioPoc.Shared;

/*
   Raw Resource -> Refined Resource -> Product 
                                    -> Component -> Product 
                                                 -> Complex Component -> Product
 */

public interface ICraftingEntity
{
   int Id { get; }
   string Name { get; }
}

public interface ICraftingTable<T> where T : ICraftingEntity
{
   IEnumerable<T> Items { get; }
   void Add(T item);
}

public abstract class CraftingTable<T> : ICraftingTable<T> where T : ICraftingEntity
{
   private int _nextId = 0;

   protected readonly IList<T> _items = new List<T>();

   protected int NextId => _nextId++;

   public IEnumerable<T> Items => _items;

   public void Add(T item)
   {
      if (item.Id != 0)
         throw new InvalidOperationException();

      //item.Id = NextId;

      var t = item.GetType();
      t.InvokeMember(nameof(item.Id), BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.SetProperty | BindingFlags.Instance, null, item, new object[] { NextId });

      _items.Add(item);
   }
}
