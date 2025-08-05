using App.API.Dto;
using App.API.Model;
using MediatR;

namespace App.API.Implementation.Categories.Commands;

public record AddCategoryCommand(string Name, string Description) : IRequest<Result<Category>>;

public class AddCategoryCommandHandler : IRequestHandler<AddCategoryCommand, Result<Category>>
{
    private readonly AppDbContext _dbContext;

    public AddCategoryCommandHandler(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Result<Category>> Handle(AddCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = new Category { Name = request.Name , Description = request.Description};

        _dbContext.Categories.Add(category);

        await _dbContext.SaveChangesAsync(cancellationToken);

        return Result<Category>.Success(category);
    }
}