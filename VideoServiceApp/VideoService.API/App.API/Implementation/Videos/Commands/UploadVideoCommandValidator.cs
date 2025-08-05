using FluentValidation;

namespace App.API.Implementation.Videos.Commands;

public class UploadVideoCommandValidator : AbstractValidator<UploadVideoCommand>
{
    private static readonly string[] AllowedExtensions = [".mp4", ".avi", ".mov"];
    private const long MaxFileSize = 100 * 1024 * 1024; // 100 MB

    public UploadVideoCommandValidator()
    {
        RuleFor(x => x.File)
            .NotNull().WithMessage("File is required.")
            .Must(f => f != null && f.Length > 0).WithMessage("File must not be empty.")
            .Must(f => f == null || AllowedExtensions.Contains(Path.GetExtension(f.FileName).ToLower()))
                .WithMessage("Only mp4, avi, and mov files are allowed.")
            .Must(f => f == null || f.Length <= MaxFileSize)
                .WithMessage("File size must not exceed 100 MB.");

        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Title is required.")
            .MaximumLength(200).WithMessage("Title must not exceed 200 characters.");

        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Description is required.")
            .MaximumLength(160).WithMessage("Description must be 160 characters or less.");
    }
}