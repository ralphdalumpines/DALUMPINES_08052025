using App.API.Model;
using Bogus;
using Moq;

namespace App.APITests.VideoTests.Mocks;

internal class ThumbnailMocks
{
	internal static VideoThumbnail CreateMockThumbnail(int Id, string path, int videoFileId)
	{
		var thumbNail = new Mock<VideoThumbnail>();

		thumbNail.Setup(v => v.Id).Returns(Id);
		thumbNail.Setup(v => v.Path).Returns(path);
		thumbNail.Setup(v => v.VideoFileId).Returns(videoFileId);

		return thumbNail.Object;
	}
				
	internal static VideoThumbnail CreateMockThumbnail(int videoFileId)
	{
		var faker = new Faker<VideoThumbnail>()
			.RuleFor(v => v.Id, f => videoFileId)
			.RuleFor(v => v.Path, f => f.System.FileName())
			.RuleFor(v => v.VideoFileId, f => f.Random.Int(1, 100));

		return faker.Generate();
	}
}
