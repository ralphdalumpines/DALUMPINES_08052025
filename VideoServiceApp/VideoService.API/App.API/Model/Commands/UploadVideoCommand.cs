using App.API.Model;
using MediatR;

public record UploadVideoCommand(IFormFile File, string Title, string Description) : IRequest<VideoFile>;