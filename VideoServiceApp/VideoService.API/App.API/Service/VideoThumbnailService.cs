using MediaToolkit;
using MediaToolkit.Model;
using MediaToolkit.Options;

namespace App.API.Service;

public class VideoThumbnailService
{
	public static void GenerateThumbnail(string videoPath, 
		string thumbnailPath, 
		int width = 256,
		int height = 256, 
		int timeInSeconds = 5)
	{		
		var inputFile = new MediaFile { Filename = videoPath };
		var outputFile = new MediaFile { Filename = thumbnailPath };

		using var engine = new Engine();
		engine.GetMetadata(inputFile);

		// Set the time to capture the thumbnail (e.g., 5 seconds into the video)
		var options = new ConversionOptions 
		{ 
			Seek = TimeSpan.FromSeconds(timeInSeconds),
			CustomHeight = width,
			CustomWidth = height
		};

		engine.GetThumbnail(inputFile, outputFile, options);
	}
}
