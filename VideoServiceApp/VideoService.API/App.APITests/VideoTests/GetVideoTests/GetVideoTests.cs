using App.API.Implementation.Videos.Queries;
using App.APITests.VideoTests.Helpers;

namespace App.APITests.VideoTests.GetVideoTests;

internal class GetVideoTests : BaseVideoTests
{
	[SetUp]
	public void Setup()
	{
		base.Setup();
	}

	[Test]
	public async Task GetVideos_ReturnsEmpty_WhenNoVideosAsync()
	{
		var result = await _mediator.Send(new GetVideosQuery());

		// Assert
		Assert.IsNotNull(result);
		Assert.IsEmpty(result);
	}

	[Test]
	public async Task GetVideos_ReturnsVideos_WhenVideosExistAsync()
	{
		var videoFiles  = VideoFileMockHelpers.GenerateEntities(_dbContext);

		var result = await _mediator.Send(new GetVideosQuery());

		// Assert
		Assert.IsNotNull(result);
		Assert.IsNotEmpty(result);
		Assert.IsNotEmpty(videoFiles.First().Title, result.First().Title);
	}
}
