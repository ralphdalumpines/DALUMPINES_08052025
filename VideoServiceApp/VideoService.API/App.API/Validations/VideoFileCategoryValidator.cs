using FluentValidation;

namespace App.API.Validations;

public class VideoFileCategoryValidator : AbstractValidator<List<int>>
{
    public VideoFileCategoryValidator()
    {    
		RuleFor(x => x)
            .NotNull().WithMessage("Categories must not be null.")
            .Must(categories => categories != null && categories.Any())
            .WithMessage("At least one category must be associated with the video file.")
            .Must(categories =>
            {
                if (categories == null) return true;
                var categoryIds = categories.Select(c => c);
                return categoryIds.Distinct().Count() == categoryIds.Count();
            })
            .WithMessage("Duplicate categories are not allowed for the video file.");
    }
}