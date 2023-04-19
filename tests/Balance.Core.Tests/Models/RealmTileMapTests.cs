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

   [Fact]
   public void QuadrantWidth_Test()
   {
      var sut = new RealmTileMap
      {
         Tiles = new RealmTile[11, 1]
      };

      sut.QuadrantWidth.Should().Be(5);
   }

   [Fact]
   public void QuadrantHeight_Test()
   {
      var sut = new RealmTileMap
      {
         Tiles = new RealmTile[1, 11]
      };

      sut.QuadrantHeight.Should().Be(5);
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


   [Theory]
   [InlineData(0, 0, false)]
   [InlineData(2, 2, true)]
   [InlineData(2, 8, true)]
   [InlineData(8, 2, true)]
   [InlineData(8, 8, true)]
   public void IsPlayerRealm_Theories(int col, int row, bool expected)
   {
      var coordinate = new Coordinate(col, row);
      var sut = new RealmTileMap
      {
         Tiles = new RealmTile[11, 11]
      };

      sut.IsPlayerRealm(coordinate).Should().Be(expected);
   }


   [Theory]
   [InlineData(5, 5, RealmType.Nexus)]
   [InlineData(2, 2, RealmType.Player)]
   [InlineData(2, 8, RealmType.Player)]
   [InlineData(8, 2, RealmType.Player)]
   [InlineData(8, 8, RealmType.Player)]
   [InlineData(5, 0, RealmType.Border)]
   [InlineData(0, 5, RealmType.Border)]
   [InlineData(0, 0, RealmType.Standard)]
   public void GetRealmType_Theories(int col, int row, RealmType expected)
   {
      var coordinate = new Coordinate(col, row);
      var sut = new RealmTileMap
      {
         Tiles = new RealmTile[11, 11]
      };

      sut.GetRealmType(coordinate).Should().Be(expected);
   }

   [Theory]
   [InlineData(0, 0, RealmTileMapQuadrant.NorthWest, true)]
   [InlineData(5, 5, RealmTileMapQuadrant.NorthWest, false)]

   [InlineData(6, 6, RealmTileMapQuadrant.SouthEast, true)]
   public void IsInQuadrant_Theories(int col, int row, RealmTileMapQuadrant quadrant, bool expected)
   {
      var coordinate = new Coordinate(col, row);
      var sut = new RealmTileMap
      {
         Tiles = new RealmTile[11, 11]
      };

      sut.IsInQuadrant(coordinate, quadrant).Should().Be(expected);
   }

   [Theory]
   [InlineData(0, 0, Border.None)]
   [InlineData(5, 0, Border.North)]
   [InlineData(5, 4, Border.North)]
   [InlineData(5, 5, Border.None)]
   [InlineData(5, 6, Border.South)]
   [InlineData(4, 5, Border.West)]
   [InlineData(6, 5, Border.East)]
   public void GetBorder_Theories(int col, int row, Border expected)
   {
      var coordinate = new Coordinate(col, row);
      var sut = new RealmTileMap
      {
         Tiles = new RealmTile[11, 11]
      };

      sut.GetBorder(coordinate).Should().Be(expected);
   }


   [Theory]
   [InlineData(5, 0, Player.One, Player.Two)]
   [InlineData(6, 5, Player.Two, Player.Three)]
   [InlineData(5, 6, Player.Three, Player.Four)]
   [InlineData(0, 5, Player.Four, Player.One)]
   public void GetBorderPlayers_Theories(int col, int row, params Player[] expected)
   {
      var coordinate = new Coordinate(col, row);
      var sut = new RealmTileMap
      {
         Tiles = new RealmTile[11, 11]
      };

      sut.GetBorderPlayers(coordinate).Should().Contain(expected);
   }
}

