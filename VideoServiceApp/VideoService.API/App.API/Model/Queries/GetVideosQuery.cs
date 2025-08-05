using App.API.Model;
using MediatR;

public record GetVideosQuery : IRequest<IEnumerable<VideoFile>>;