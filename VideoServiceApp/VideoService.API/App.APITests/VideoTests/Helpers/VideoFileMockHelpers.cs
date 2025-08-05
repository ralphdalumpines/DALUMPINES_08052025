using App.API.Model;
using App.APITests.VideoTests.Mocks;

namespace App.APITests.VideoTests.Helpers;

internal class VideoFileMockHelpers
{
	internal static List<VideoFile> GenerateEntities(AppDbContext appDbContext, int instance = 1)
	{
		List<VideoFile> videoFiles = [];

		for (int i = 0; i < instance; i++)
		{		
			VideoFile videoFile = VideoFileMocks.CreateMockVideoFile();
			videoFiles.Add(videoFile);
		}

		appDbContext.VideoFiles.AddRangeAsync(videoFiles);

		appDbContext.SaveChanges();

		return videoFiles;
	}
}
