using App.API.Implementation.Videos.Commands;
using App.API.Implementation.Videos.Queries;
using App.API.Validations;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace App.API.Controllers;

[ApiController]
[Route("api/[controller]")]
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
    public async Task<IActionResult> GetVideos()
    {
		var videos = await _mediator.Send(new GetVideosQuery());
        return Ok(videos);		
    }

    [HttpGet("GetVideo/{id}")]
    public async Task<IActionResult> GetVideo(int id)
    {
        if (id <= 0)
            return BadRequest("Invalid video ID.");
        var video = await _mediator.Send(new GetVideoQuery(id));
        
        if (video == null)
            return NotFound($"Video with ID {id} not found.");
        return Ok(video);
	}

	[HttpPost("UploadVideo")]
    public async Task<IActionResult> UploadVideo(IFormFile file, [FromForm] string title, [FromForm] string description, [FromForm] List<int> categories)
    {
        if (file == null || file.Length == 0)
            return BadRequest("No file uploaded."); 

        var command = new UploadVideoCommand(file, title, description, categories);

        // Instantiate the validator
        var validator = new UploadVideoCommandValidator();

        // Validate synchronously
        ValidationResult result = validator.Validate(command);

        if (!result.IsValid)
        {
            foreach (var error in result.Errors)
            {
                Console.WriteLine($"{error.PropertyName}: {error.ErrorMessage}");
            }

            return BadRequest(result.Errors);
        }

        var video = await _mediator.Send(command);

        return Ok(video);
    }
}
