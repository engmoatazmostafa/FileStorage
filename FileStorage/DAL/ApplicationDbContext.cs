using FileStorage.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FileStorage.DAL
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<FileStorage.Entities.ApplicationUser> ApplicationUsers { get; set; } 
        public DbSet<FileStorage.Entities.FileMetaData> Files { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure the relationship between User and FileMetadata
            modelBuilder.Entity<FileStorage.Entities.FileMetaData>()
                .HasOne(f => f.ApplicationUser)
                .WithMany(u => u.Files)
                .HasForeignKey(f => f.UserId);
        }

    }
}
