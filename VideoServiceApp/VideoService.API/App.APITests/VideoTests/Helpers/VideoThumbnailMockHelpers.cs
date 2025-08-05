using App.API.Model;
using App.APITests.VideoTests.Mocks;

namespace App.APITests.VideoTests.Helpers;

internal class VideoThumbnailMockHelpers
{
	internal static VideoThumbnail GenerateEntities(AppDbContext dbContext, int videoFileId)
	{
		VideoThumbnail videoThumbnail = ThumbnailMocks.CreateMockThumbnail(videoFileId);
		
		dbContext.VideoThumbnails.Add(videoThumbnail);

		dbContext.SaveChanges();

		return videoThumbnail;
	}
}