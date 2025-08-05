using App.API.Dto;
using App.API.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace App.API.Implementation.Categories.Queries;

public record GetCategoriesQuery(int? VideoFileId = null) : IRequest<Result<IList<Category>>>;

public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQuery, Result<IList<Category>>>
{
	private readonly AppDbContext _dbContext;

	public GetCategoriesQueryHandler(AppDbContext dbContext)
	{
		_dbContext = dbContext;
	}

	public async Task<Result<IList<Category>>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
	{
		IQueryable<Category> query = _dbContext.Categories.AsNoTracking();

		if (request.VideoFileId.HasValue)
		{
			// Filter categories by VideoFileId via VideoFileCategory join
			query = query.Where(c =>
				_dbContext.VideoFileCategories.Any(vfc =>
					vfc.VideoFileId == request.VideoFileId.Value && vfc.CategoryId == c.Id));
		}

		var categories = await query.ToListAsync(cancellationToken);

		return Result<IList<Category>>.Success(categories);
	}
}