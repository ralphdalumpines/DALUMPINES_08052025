using App.API.Model;
using MediatR;

namespace App.API.Implementation.Videos.Commands;

public record UploadVideoCommand(IFormFile File, string Title, string Description) : IRequest<VideoFile>;

public class UploadVideoHandler : IRequestHandler<UploadVideoCommand, VideoFile>
{
    private readonly AppDbContext _dbContext;

    public UploadVideoHandler(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<VideoFile> Handle(UploadVideoCommand request, CancellationToken cancellationToken)
    {
        var file = request.File;
        var uploadsDir = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");

        if (!Directory.Exists(uploadsDir))
            Directory.CreateDirectory(uploadsDir);

        var filePath = Path.Combine(uploadsDir, file.FileName);

        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await file.CopyToAsync(stream, cancellationToken);
        }

        var video = new VideoFile
        {
            Title = request.Title,
            Description = request.Description,
            Path = filePath,
            DateUploaded = DateTime.UtcNow,
            Size = (int)file.Length,
            ExtensionType = Path.GetExtension(file.FileName)
        };

        _dbContext.VideoFiles.Add(video);
        await _dbContext.SaveChangesAsync(cancellationToken);

		//Return the video dto with thumbnail path

		return video;
    }
}   