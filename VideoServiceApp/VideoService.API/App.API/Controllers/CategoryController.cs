using App.API.Implementation.Categories.Commands;
using App.API.Implementation.Categories.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace App.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly IMediator _mediator;

    public CategoryController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("GetCategories")]
    public async Task<IActionResult> GetCategories()
    {
        var categories = await _mediator.Send(new GetCategoriesQuery());

        return Ok(categories);
    }

    [HttpPost("AddCategory")]
    public async Task<IActionResult> AddCategory([FromForm] string name, [FromForm] string description)
    {
        var command = new AddCategoryCommand(name, description);

        // Optionally, add validation here if you have a validator
        // var validator = new AddCategoryCommandValidator();
        // ValidationResult result = validator.Validate(command);
        // if (!result.IsValid)
        //     return BadRequest(result.Errors);

        var category = await _mediator.Send(command);

        return Ok(category);
    }
}
