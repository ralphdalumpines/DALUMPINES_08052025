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
        Assert.IsEmpty(result.Value);
    }

    [Test]
    public async Task GetVideos_ReturnsVideos_WhenVideosExistAsync()
    {
        var videoFiles = VideoFileMockHelpers.GenerateEntities(_dbContext);
        foreach (var videoFile in videoFiles)
        {
            videoFile.Thumbnail = VideoThumbnailMockHelpers.GenerateEntities(_dbContext, videoFile.Id);
        }

        var result = await _mediator.Send(new GetVideosQuery());

        // Assert
        Assert.IsNotNull(result);
        Assert.IsNotEmpty(result.Value);
        Assert.IsNotEmpty(videoFiles.First().Title, result.Value.First().Title);
    }

    [Test]
    public async Task GetVideoQuery_ReturnsVideo_WhenVideoExists()
    {
        // Arrange
        var videoFiles = VideoFileMockHelpers.GenerateEntities(_dbContext);
        var targetVideo = videoFiles.First();
        targetVideo.Thumbnail = VideoThumbnailMockHelpers.GenerateEntities(_dbContext, targetVideo.Id);

        // Act
        var result = await _mediator.Send(new GetVideoQuery(targetVideo.Id));

        // Assert
        Assert.IsNotNull(result);
        Assert.IsTrue(result.IsSuccess);
        Assert.IsNotNull(result.Value);
        Assert.AreEqual(targetVideo.Id, result.Value.Id);
    }

    [Test]
    public async Task GetVideoQuery_ReturnsFailure_WhenVideoDoesNotExist()
    {
        // Arrange
        int nonExistentId = short.MinValue;

        // Act
        var result = await _mediator.Send(new GetVideoQuery(nonExistentId));

        // Assert
        Assert.IsNotNull(result);
        Assert.IsFalse(result.IsSuccess);
        Assert.IsNull(result.Value);
    }
}
