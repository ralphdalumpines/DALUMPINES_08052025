using App.API.Model;
using FluentValidation;

namespace App.API.Validations;

public class VideoFileValidator : AbstractValidator<VideoFile>
{
	private static readonly string[] AllowedExtensions = [".mp4", ".avi", ".mov"];
	private const long MaxFileSize = 100 * 1024 * 1024; // 100 MB

	public VideoFileValidator()
	{
		RuleFor(x => x.Path)
			.NotEmpty().WithMessage("File path is required.")
			.Must(path => AllowedExtensions.Contains(Path.GetExtension(path).ToLower()))
				.WithMessage("Only mp4, avi, and mov files are allowed.")
			.Must(path => new FileInfo(path).Length <= MaxFileSize)
				.WithMessage("File size must not exceed 100 MB.");
		RuleFor(x => x.Title)
			.NotEmpty().WithMessage("Title is required.")
			.MaximumLength(200).WithMessage("Title must not exceed 200 characters.");
		RuleFor(x => x.Description)
			.NotEmpty().WithMessage("Description is required.")
			.MaximumLength(160).WithMessage("Description must be 160 characters or less.");
	}
}
