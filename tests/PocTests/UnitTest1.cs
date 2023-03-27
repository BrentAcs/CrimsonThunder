using FluentAssertions;

namespace PocTests;

public class UnitTest1
{
   public class TestCraftingTable : CraftingTable<RawResource>
   {
   }
   
   [Fact]
   public void Test1()
   {
      var sut = new TestCraftingTable();

      sut.Items.Should().BeEmpty();
   }
}
