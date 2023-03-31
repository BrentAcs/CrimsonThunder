using FluentAssertions;
using MongoDB.Bson;
using SeeYa.Core.Services;
using SeeYa.Core.Services.Repos;

namespace SeeYa.Core.Tests;

public class StoryRunnerTests
{
   private StoryRunner GetRunner() => new(new TestStoryRepo(), new TestStoryNodeRepo());

   // [Fact]
   // public void Start_WillReturn_ProperStoryNode()
   // {
   //    var sut = GetRunner();
   //    var result = sut.Start("100000000000000000000000");
   //
   //    result!.Id.Should().Be(ObjectId.Parse("000000000000000000000001"));
   // }
}