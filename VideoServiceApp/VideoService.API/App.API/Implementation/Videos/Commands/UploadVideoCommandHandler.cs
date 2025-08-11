using App.API.Dto;
using App.API.Model;
using App.API.Service;
using App.API.Validations;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace App.API.Implementation.Videos.Commands;

public record UploadVideoCommand(IFormFile File, string Title, string Description, List<CategoryDto> Categories) : IRequest<Result<VideoFile>>;

public class UploadVideoCommandHandler : IRequestHandler<UploadVideoCommand, Result<VideoFile>>
{
	private readonly AppDbContext _dbContext;
	private const string SaveDirectory = @"C:\\Projects\\VideoServiceApp\\VideoServiceApp\\VideoService.API\\";

	public UploadVideoCommandHandler(AppDbContext dbContext)
	{
		_dbContext = dbContext;
	}

	public async Task<Result<VideoFile>> Handle(UploadVideoCommand request, CancellationToken cancellationToken)
	{
		var file = request.File;
		var uploadsDir = Path.Combine(SaveDirectory, "Uploads");

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

		var videoFileCatValidator = new VideoFileCategoryValidator();
		result = videoFileCatValidator.Validate(request.Categories);

		if (!result.IsValid)
			return Result<VideoFile>.Failure(result.Errors.FirstOrDefault()?.ErrorMessage ?? "Category validation failed");

		var categoriesVideo = _dbContext.VideoFileCategories.Where(c => c.VideoFileId == video.Id).Select(c => c.CategoryId).ToList();

		foreach (var category in request.Categories)
		{
			if (categoriesVideo.Contains(category.Id)) 
				continue;

			_dbContext.VideoFileCategories.Add(new VideoFileCategory
			{
				VideoFileId = video.Id,
				CategoryId = category.Id
			});
		}

		var thumbnailDir = Path.Combine(SaveDirectory, "Thumbnails");

		if (!Directory.Exists(thumbnailDir))
			Directory.CreateDirectory(thumbnailDir);

		var thumbnailPath = Path.Combine(thumbnailDir, Path.GetFileNameWithoutExtension(file.FileName) + ".jpg");

		VideoThumbnailService.GenerateThumbnail(videoPath, thumbnailPath);

		return Result<VideoFile>.Success(video);
	}
}