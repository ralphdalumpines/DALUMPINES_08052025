using App.API.Dto;
using App.API.Model;
using App.API.Service;
using App.API.Validations;
using MediatR;

namespace App.API.Implementation.Videos.Commands;

public record UploadVideoCommand(IFormFile File, string Title, string Description) : IRequest<Result<VideoFile>>;

public class UploadVideoHandler : IRequestHandler<UploadVideoCommand, Result<VideoFile>>
{
	private readonly AppDbContext _dbContext;

	public UploadVideoHandler(AppDbContext dbContext)
	{
		_dbContext = dbContext;
	}

	public async Task<Result<VideoFile>> Handle(UploadVideoCommand request, CancellationToken cancellationToken)
	{
		var file = request.File;
		var uploadsDir = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");

		if (!Directory.Exists(uploadsDir))
			Directory.CreateDirectory(uploadsDir);

		var videoPath = Path.Combine(uploadsDir, file.FileName);

		using (var stream = new FileStream(videoPath, FileMode.Create))
		{
			await file.CopyToAsync(stream, cancellationToken);
		}

		var video = new VideoFile
		{
			Title = request.Title,
			Description = request.Description,
			Path = videoPath,
			DateUploaded = DateTime.UtcNow,
			Size = (int)file.Length,
			ExtensionType = Path.GetExtension(file.FileName)
		};

		var validator = new VideoFileValidator();
		FluentValidation.Results.ValidationResult result = validator.Validate(video);

		if (!result.IsValid)
			return Result<VideoFile>.Failure(result.Errors.FirstOrDefault()?.ErrorMessage ?? "Validation failed");

		_dbContext.VideoFiles.Add(video);
		await _dbContext.SaveChangesAsync(cancellationToken);

		var thumbnailDir = Path.Combine(Directory.GetCurrentDirectory(), "Thumbnails");

		if (!Directory.Exists(thumbnailDir))
			Directory.CreateDirectory(thumbnailDir);

		var thumbnailPath = Path.Combine(thumbnailDir, Path.GetFileNameWithoutExtension(file.FileName) + ".jpg");

		VideoThumbnailService.GenerateThumbnail(videoPath, thumbnailPath);

		return Result<VideoFile>.Success(video);
	}
}