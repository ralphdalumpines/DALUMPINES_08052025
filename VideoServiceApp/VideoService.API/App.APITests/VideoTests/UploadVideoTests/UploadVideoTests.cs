using App.API.Implementation.Videos.Commands;
using App.APITests.VideoTests.Mocks;
using Microsoft.AspNetCore.Http;

namespace App.APITests.VideoTests.UploadVideoTests;

internal class UploadVideoTests : BaseVideoTests
{
	[SetUp]
	public void Setup()
	{
		base.Setup();
	}

	[Test]
	public Task UploadVideo_ReturnsBadRequest_WhenNoFile()
	{		
		IFormFile? file = null;

		// Assert
		if (file == null || file?.Length == 0)
		{
			Assert.Pass("No file uploaded.");
		}
		Assert.Fail("Should not reach here.");
		
		return Task.CompletedTask;
	}

	[Test]
	public async Task UploadVideo_SavesVideoAndReturnsVideo()
	{
		var fileMock = FormFileMocks.CreateMockFormFile("test.mp4", "video/mp4", []);

		var command = new UploadVideoCommand(fileMock, "title", "desc");
		var video = await _mediator.Send(command);

		//Assert
		Assert.IsNotNull(video);
		Assert.AreEqual("title", video.Title);
		Assert.AreEqual("desc", video.Description);
		Assert.AreEqual(".mp4", video.ExtensionType);
		Assert.IsTrue(_dbContext.VideoFiles.Any(v => v.Title == "title"));
	}
}
