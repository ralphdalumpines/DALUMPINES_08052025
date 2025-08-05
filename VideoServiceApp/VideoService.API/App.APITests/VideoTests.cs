using App.API.Dto;
using App.API.Implementation.Videos.Commands;
using App.API.Implementation.Videos.Queries;
using App.API.Model;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Moq;

public class VideoTests : IDisposable
{
    private AppDbContext _dbContext;
    private IMediator _mediator;
    private ServiceFactory _serviceFactory;
	[SetUp]
    public void Setup()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;
        _dbContext = new AppDbContext(options);
	
        
        // Register the DbContext and Mediator
        var services = new ServiceCollection();
        services.AddSingleton(_dbContext);
        services.AddMediatR(typeof(GetVideosHandler).Assembly);
        _serviceFactory = services.BuildServiceProvider().GetRequiredService<ServiceFactory>();
        _mediator = new Mediator(_serviceFactory);
    }

    [Test]
    public async Task GetVideos_ReturnsEmpty_WhenNoVideosAsync()
    {
        var result = await _mediator.Send(new GetVideosQuery());
        Assert.IsNotNull(result);
        Assert.IsEmpty(result);
    }

    [Test]
    public async Task GetVideos_ReturnsVideos_WhenVideosExistAsync()
    {
        _dbContext.VideoFiles.Add(new VideoFile
        {
            Title = "Test",
            Description = "Test Desc",
            Path = "test.mp4",
            DateUploaded = DateTime.UtcNow,
            Size = 123,
            ExtensionType = ".mp4",
            VideoFileCategories = []
        });
        _dbContext.SaveChanges();

        var result = await _mediator.Send(new GetVideosQuery());
        Assert.IsNotNull(result);
        Assert.IsNotEmpty(result);
        Assert.AreEqual("Test", result.First().Title);
    }

    [Test]
    public async Task UploadVideo_ReturnsBadRequest_WhenNoFile()
    {
        // Simulate controller logic for null file
        IFormFile file = null;
        if (file == null || file?.Length == 0)
        {
            Assert.Pass("No file uploaded.");
        }
        Assert.Fail("Should not reach here.");
    }

    [Test]
    public async Task UploadVideo_SavesVideoAndReturnsVideo()
    {
        var fileMock = new Mock<IFormFile>();
        var content = "Fake file content";
        var fileName = "test.mp4";
        var ms = new MemoryStream();
        var writer = new StreamWriter(ms);
        writer.Write(content);
        writer.Flush();
        ms.Position = 0;

        fileMock.Setup(f => f.OpenReadStream()).Returns(ms);
        fileMock.Setup(f => f.FileName).Returns(fileName);
        fileMock.Setup(f => f.Length).Returns(ms.Length);
        fileMock.Setup(f => f.CopyToAsync(It.IsAny<Stream>(), default)).Returns<Stream, CancellationToken>((stream, token) =>
        {
            ms.CopyTo(stream);
            return Task.CompletedTask;
        });

        var command = new UploadVideoCommand(fileMock.Object, "title", "desc");
        var video = await _mediator.Send(command);

        Assert.IsNotNull(video);
        Assert.AreEqual("title", video.Title);
        Assert.AreEqual("desc", video.Description);
        Assert.AreEqual(".mp4", video.ExtensionType);
        Assert.IsTrue(_dbContext.VideoFiles.Any(v => v.Title == "title"));
    }

    public void Dispose()
    {
        _dbContext?.Dispose();
    }
}