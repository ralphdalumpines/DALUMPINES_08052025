using System.ComponentModel.DataAnnotations.Schema;

namespace App.API.Model;

[Table("VideoFileCategory", Schema = "dbo")]
public class VideoFileCategory
{
	// This class represents the join entity for the many-to-many relationship
	[ForeignKey("VideoFile")]
	public int VideoFileId { get; set; }

	// Navigation property to the VideoFile
	public VideoFile? VideoFile { get; set; }

	// This is the foreign key to the Category
	[ForeignKey("Category")]
	public int CategoryId { get; set; }

	// Navigation property to the Category
	public Category? Category { get; set; }
}