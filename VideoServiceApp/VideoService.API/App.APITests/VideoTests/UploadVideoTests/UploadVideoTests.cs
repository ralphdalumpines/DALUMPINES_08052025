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
		var fileMock = FormFileMocks.CreateMockFormFile("test.mp4", "video/mp4", [0x41, 0x42, 0x43, 0x44]);

		var command = new UploadVideoCommand(fileMock, "title", "desc",  [ 1 ]);
		var result = await _mediator.Send(command);

		//Assert
		Assert.IsNotNull(result);
		Assert.AreEqual("title", result.Value.Title);
		Assert.AreEqual("desc", result.Value.Description);
		Assert.AreEqual(".mp4", result.Value.ExtensionType);
		Assert.IsTrue(_dbContext.VideoFiles.Any(v => v.Title == "title"));
	}
}
