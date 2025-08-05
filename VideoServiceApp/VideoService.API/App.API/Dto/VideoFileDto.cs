namespace App.API.Dto;

public class VideoFileDto
{
	public int Id { get; set; }

	public required string Path { get; set; }

	public required string Title { get; set; }

	public required string Description { get; set; }
	 
	public List<CategoryDto> Categories { get; set; }

	public VideoThumbnailDto? Thumbnail { get; set; }
}
