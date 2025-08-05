namespace App.API.Model;

public class VideoFile
{
	public int Id { get; set; }

	public DateTime DateUploaded { get; set; }

	public string Path { get; set; }

	public string Title { get; set; }

	public int Size { get; set; }

	public string ExtensionType { get; set; }

	public string Description { get; set; }

	public List<Category> Categories { get; set; }
}
