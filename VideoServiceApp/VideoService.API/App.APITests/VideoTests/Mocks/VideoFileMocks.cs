using App.API.Model;
using Bogus;
using Moq;

namespace App.APITests.VideoTests.Mocks;

internal class VideoFileMocks
{
	private static IList<string> ApplicableExtensions = [".mp4", ".avi", ".mov" ];

	//using Moq create a mock of VideoFile class
	public static VideoFile CreateMockVideoFile(int id,
		string title,
		string description, 
		string path, 
		DateTime dateUploaded, 
		int size,
		string extensionType)
	{
		var videoFile = new Mock<VideoFile>();

		videoFile.Setup(v => v.Id).Returns(id);
		videoFile.Setup(v => v.Title).Returns(title);
		videoFile.Setup(v => v.Description).Returns(description);
		videoFile.Setup(v => v.Path).Returns(path);
		videoFile.Setup(v => v.DateUploaded).Returns(dateUploaded);
		videoFile.Setup(v => v.Size).Returns(size);
		videoFile.Setup(v => v.ExtensionType).Returns(extensionType);

		return videoFile.Object;
	}


	//using Bogus create a mock of VideoFile class
	public static VideoFile CreateMockVideoFile()
	{
		var faker = new Faker<VideoFile>()
			.RuleFor(v => v.Id, f => f.IndexFaker + 1)
			.RuleFor(v => v.Title, f => f.Lorem.Sentence(3))
			.RuleFor(v => v.Description, f => f.Lorem.Paragraph(60))
			.RuleFor(v => v.Path, f => f.System.FileName())
			.RuleFor(v => v.DateUploaded, f => f.Date.Past())
			.RuleFor(v => v.Size, f => f.Random.Int(1, 100))
			.RuleFor(v => v.ExtensionType, f => $"{ApplicableExtensions[f.Random.Int(0, ApplicableExtensions.Count - 1)]}");

		return faker.Generate();
	}
}
