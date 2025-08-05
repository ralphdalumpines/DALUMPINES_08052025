using App.API.Dto;
using App.API.Implementation.Videos.Commands;
using App.API.Implementation.Videos.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace App.API.Controllers;

[ApiController]
[Route("[controller]")]
public class VideoController : ControllerBase
{       
    private readonly ILogger<VideoController> _logger;
    private readonly IMediator _mediator;

    public VideoController(ILogger<VideoController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpGet("GetVideos")]
    public async Task<IList<VideoFileDto>> GetVideos()
    {
        return await _mediator.Send(new GetVideosQuery());
    }

    [HttpPost("UploadVideo")]
    public async Task<IActionResult> UploadVideo(IFormFile file, [FromForm] string title, [FromForm] string description)
    {
        if (file == null || file.Length == 0)
            return BadRequest("No file uploaded."); 

        var video = await _mediator.Send(new UploadVideoCommand(file, title, description));

        return Ok(video);
    }
}
