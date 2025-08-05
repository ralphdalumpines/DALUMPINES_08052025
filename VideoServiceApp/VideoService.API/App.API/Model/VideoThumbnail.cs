using System.ComponentModel.DataAnnotations.Schema;

namespace App.API.Model;

[Table("VideoThumbnail", Schema = "dbo")]
public class VideoThumbnail
{
	public int Id { get; set; }
	
	public string Path { get; set; }

	[ForeignKey("VideoFile")]
	public int VideoFileId { get; set; }

	// Navigation property to the associated VideoFile
	public VideoFile? VideoFile { get; set; }
}
