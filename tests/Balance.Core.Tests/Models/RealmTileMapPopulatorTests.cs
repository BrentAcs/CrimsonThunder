using Balance.Core.Services;
using Xunit.Abstractions;

namespace Balance.Core.Tests.Models;

public class RealmTileMapPopulatorTests
{
   private readonly ITestOutputHelper _output;
   private IRealmTileMapFactory _factory = new RealmTileMapFactory();

   public RealmTileMapPopulatorTests(ITestOutputHelper output)
   {
      _output = output;
   }

   [Fact]
   public void Test()
   {
      var map = _factory.Create(new IRealmTileMapFactory.Options());

      var sut = new RealmTileMapPopulator();

      var stopWatch = new System.Diagnostics.Stopwatch();

      stopWatch.Start();
      sut.Populate(map, new IRealmTileMapPopulator.Options());
      stopWatch.Stop();

      _output.WriteLine($"Elapsed Time: {stopWatch.Elapsed:m\\:ss\\.fff}");
   }
}
