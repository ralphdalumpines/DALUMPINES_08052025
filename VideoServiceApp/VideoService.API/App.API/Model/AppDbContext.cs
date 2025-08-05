using Microsoft.EntityFrameworkCore;

namespace App.API.Model;

public class AppDbContext : DbContext
{
	public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
	{
	}

    public DbSet<VideoFile> VideoFiles { get; set; }

    public DbSet<Category> Categories { get; set; }

    public DbSet<VideoFileCategory> VideoFileCategories { get; set; }

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
	}
}