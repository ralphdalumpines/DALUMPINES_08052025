using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.API.Model;

[Table("VideoFile", Schema = "dbo")]
public class VideoFile
{
	[Key]
	public int Id { get; set; }

	public DateTime DateUploaded { get; set; }

	public string Path { get; set; }

	public string Title { get; set; }

	public int Size { get; set; }

	public string ExtensionType { get; set; }

	public string Description { get; set; }

	// Navigation property for the many-to-many relationship
	public ICollection<VideoFileCategory> VideoFileCategories { get; set; } = [];

	public VideoThumbnail? Thumbnail { get; set; }
}
