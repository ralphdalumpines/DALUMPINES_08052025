using App.API.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;

public class GetVideosHandler : IRequestHandler<GetVideosQuery, IEnumerable<VideoFile>>
{
    private readonly AppDbContext _dbContext;

    public GetVideosHandler(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<VideoFile>> Handle(GetVideosQuery request, CancellationToken cancellationToken)
    {
        return await _dbContext.VideoFiles.Include(v => v.Categories).ToListAsync(cancellationToken);
    }
}