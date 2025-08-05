using Microsoft.AspNetCore.Http;
using Moq;

namespace App.APITests.VideoTests.Mocks;

internal class FormFileMocks
{
	public static IFormFile CreateMockFormFile(string fileName, string contentType, byte[] content)
	{
		var fileMock = new Mock<IFormFile>();
		var ms = new MemoryStream(content);
		fileMock.Setup(f => f.OpenReadStream()).Returns(ms);
		fileMock.Setup(f => f.FileName).Returns(fileName);
		fileMock.Setup(f => f.ContentType).Returns(contentType);
		fileMock.Setup(f => f.Length).Returns(ms.Length);
		fileMock.Setup(f => f.CopyToAsync(It.IsAny<Stream>(), default)).Returns<Stream, CancellationToken>((stream, token) =>
		{
			ms.CopyTo(stream);
			return Task.CompletedTask;
		});

		return fileMock.Object;
	}
}


