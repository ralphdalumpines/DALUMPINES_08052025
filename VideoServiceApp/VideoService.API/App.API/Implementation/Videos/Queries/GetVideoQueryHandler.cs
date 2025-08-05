using App.API.Dto;
using App.API.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace App.API.Implementation.Videos.Queries;

public class GetVideoQuery : IRequest<Result<VideoFile>>
{
	public int Id { get; }

	public GetVideoQuery(int id)
	{
		Id = id;
	}
}

internal class GetVideoQueryHandler : IRequestHandler<GetVideoQuery, Result<VideoFile>>
{
    private readonly AppDbContext _dbContext;

    public GetVideoQueryHandler(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Result<VideoFile>> Handle(GetVideoQuery request, CancellationToken cancellationToken)
    {
        var video = await _dbContext.VideoFiles
            .Include(v => v.VideoFileCategories)
            .Include(v => v.Thumbnail)
            .FirstOrDefaultAsync(v => v.Id == request.Id, cancellationToken);

        if (video == null)
            return Result<VideoFile>.Failure("Video file not found.");

        return Result<VideoFile>.Success(video);
    }
}