using Balance.Core.Models;
using FluentAssertions;

namespace Balance.Core.Tests.Models;

public class RealmTileMapTests
{
   [Fact]
   public void Width_Test()
   {
      var sut = new RealmTileMap
      {
         Tiles = new RealmTile[11, 1]
      };

      sut.Width.Should().Be(11);
   }

   [Fact]
   public void Height_Test()
   {
      var sut = new RealmTileMap
      {
         Tiles = new RealmTile[1, 11]
      };

      sut.Height.Should().Be(11);
   }

   [Fact]
   public void BorderRealmCol_Test()
   {
      var sut = new RealmTileMap
      {
         Tiles = new RealmTile[11, 1]
      };

      sut.BorderRealmCol.Should().Be(5);
   }

   [Fact]
   public void BorderRealmRow_Test()
   {
      var sut = new RealmTileMap
      {
         Tiles = new RealmTile[1, 11]
      };

      sut.BorderRealmRow.Should().Be(5);
   }

   [Fact]
   public void NexusRealmCoordinate_Test()
   {
      var sut = new RealmTileMap
      {
         Tiles = new RealmTile[11, 11]
      };

      sut.NexusRealmCoordinate.Should().Be(new Coordinate(5, 5));
   }

   [Theory]
   [InlineData(0, 0, false)]
   [InlineData(5, 5, false)] // nexus
   [InlineData(5, 0, true)]
   [InlineData(6, 0, false)]
   [InlineData(0, 5, true)]
   [InlineData(0, 6, false)]
   [InlineData(4, 4, false)]
   [InlineData(4, 6, false)]
   [InlineData(6, 4, false)]
   [InlineData(6, 6, false)]
   public void IsBorderRealm_Theories(int col, int row, bool expected)
   {
      var coordinate = new Coordinate(col, row);
      var sut = new RealmTileMap
      {
         Tiles = new RealmTile[11, 11]
      };

      sut.IsBorderRealm(coordinate).Should().Be(expected);
   }

   [Theory]
   [InlineData(RealmTileMapQuadrant.NorthWest, 0, 0)]
   [InlineData(RealmTileMapQuadrant.NorthEast, 6, 0)]
   [InlineData(RealmTileMapQuadrant.SouthWest, 0, 6)]
   [InlineData(RealmTileMapQuadrant.SouthEast, 6, 6)]
   public void GetQuadrantHome_Theories(RealmTileMapQuadrant quadrant, int expectedCol, int expectedRow)
   {
      var expected = new Coordinate(expectedCol, expectedRow);
      var sut = new RealmTileMap
      {
         Tiles = new RealmTile[11, 11]
      };

      var result = sut.GetQuadrantHome(quadrant);

      result.Should().Be(expected);
   }
}

