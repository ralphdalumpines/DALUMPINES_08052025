using App.API.Dto;
using App.API.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace App.API.Implementation.Videos.Queries;

public record GetVideosQuery : IRequest<IList<VideoFileDto>>;

public class GetVideosHandler : IRequestHandler<GetVideosQuery, IList<VideoFileDto>>
{
	private readonly AppDbContext _dbContext;

	public GetVideosHandler(AppDbContext dbContext)
	{
		_dbContext = dbContext;
	}

	public async Task<IList<VideoFileDto>> Handle(GetVideosQuery request, CancellationToken cancellationToken)
	{
		if (request == null)
			throw new ArgumentNullException(nameof(request), "Request parameters cannot be null");

		if (cancellationToken.IsCancellationRequested)
			throw new OperationCanceledException("Operation was canceled", cancellationToken);

		var query = _dbContext.VideoFiles
			.Include(vf => vf.VideoFileCategories)		
			.AsNoTracking();

		var results = await query.Select(vf => new VideoFileDto
		{
			Id = vf.Id,
			Title = vf.Title,
			Description = vf.Description,
			Path = vf.Path
		}).ToListAsync(cancellationToken);

		// Join with video categories then categories
		foreach (var video in results)
		{
			var categories = await _dbContext.VideoFileCategories
				.Where(vfc => vfc.VideoFileId == video.Id)
				.Select(vfc => vfc.Category)
				.ToListAsync(cancellationToken);
			video.Categories = [.. categories.Select(c => new CategoryDto
			{
				Id = c.Id,
				Name = c.Name
			})];
		}

		return results;
	}
}