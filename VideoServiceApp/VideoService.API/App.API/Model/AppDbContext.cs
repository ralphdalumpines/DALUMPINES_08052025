using Microsoft.EntityFrameworkCore;

namespace App.API.Model;

public class AppDbContext : DbContext
{
	public AppDbContext(DbContextOptions<AppDbContext> options)
		: base(options)
	{
	}

    public virtual DbSet<VideoFile> VideoFiles { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<VideoFileCategory> VideoFileCategories { get; set; }

	public virtual DbSet<VideoThumbnail> VideoThumbnails { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Explicitly configure primary keys for VideoFile and Category
        modelBuilder.Entity<VideoFile>()
            .HasKey(v => v.Id);

        modelBuilder.Entity<Category>()
            .HasKey(c => c.Id);

        // Configure the relationship between VideoFile and Category through VideoFileCategory
        modelBuilder.Entity<VideoFile>()
            .HasMany<VideoFileCategory>()
            .WithOne(vfc => vfc.VideoFile)
            .HasForeignKey(vfc => vfc.VideoFileId);

		// Configure the one-to-one relationship between VideoFile and VideoThumbnail (Thumbnail property)
		modelBuilder.Entity<VideoFile>()
			.HasOne(vf => vf.Thumbnail)
			.WithOne()
			.HasForeignKey<VideoThumbnail>(vt => vt.VideoFileId)
			.OnDelete(DeleteBehavior.Cascade);

		modelBuilder.Entity<Category>()
            .HasMany<VideoFileCategory>()
            .WithOne(vfc => vfc.Category)
            .HasForeignKey(vfc => vfc.CategoryId);

		// Configure the join entity for many-to-many relationship
		modelBuilder.Entity<VideoFileCategory>()
			.HasKey(vfc => new { vfc.VideoFileId, vfc.CategoryId });

		modelBuilder.Entity<VideoFileCategory>()
			.HasOne(vfc => vfc.VideoFile)
			.WithMany()
			.HasForeignKey(vfc => vfc.VideoFileId)
			.OnDelete(DeleteBehavior.Cascade);

		modelBuilder.Entity<VideoFileCategory>()
			.HasOne(vfc => vfc.Category)
			.WithMany()
			.HasForeignKey(vfc => vfc.CategoryId)
			.OnDelete(DeleteBehavior.Cascade);

		// Configure the relationship between VideoThumbnail and VideoFile
		modelBuilder.Entity<VideoThumbnail>()
			.HasKey(vt => vt.Id);

		modelBuilder.Entity<VideoThumbnail>()
			.HasOne(vt => vt.VideoFile)
			.WithMany() 
			.HasForeignKey(vt => vt.VideoFileId)
			.OnDelete(DeleteBehavior.Cascade);
	}
}