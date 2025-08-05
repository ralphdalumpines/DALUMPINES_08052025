using App.API.Implementation.Videos.Commands;
using App.API.Implementation.Videos.Queries;
using App.API.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

internal abstract class BaseVideoTests : IDisposable
{
    protected AppDbContext _dbContext;
	protected ServiceFactory _serviceFactory;
	protected IMediator _mediator;

	[SetUp]
	protected void Setup()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;
        _dbContext = new AppDbContext(options);
	        
        // Register the DbContext and Mediator
        var services = new ServiceCollection();
        services.AddSingleton(_dbContext);
        services.AddMediatR(typeof(GetVideosQueryHandler).Assembly);
		services.AddMediatR(typeof(UploadVideoCommandHandler).Assembly);

		_serviceFactory = services.BuildServiceProvider().GetRequiredService<ServiceFactory>();
        _mediator = new Mediator(_serviceFactory);
    }   
   
    public void Dispose()
    {
        _dbContext?.Dispose();
    }
}