using DreamJob.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace DreamJob.Server.Data;

public class DreamJobDbContext : DbContext
{
    public DreamJobDbContext(DbContextOptions<DreamJobDbContext> options)
        : base(options)
    {
    }

    public DbSet<Job> Jobs { get; set; }
    public DbSet<Company> Companies { get; set; }
    public DbSet<Application> Applications { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configure Job entity
        modelBuilder.Entity<Job>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Title).IsRequired().HasMaxLength(200);
            entity.Property(e => e.Description).IsRequired();
            entity.Property(e => e.Salary).HasColumnType("decimal(18,2)");
            
            entity.HasOne(e => e.Company)
                  .WithMany(c => c.Jobs)
                  .HasForeignKey(e => e.CompanyId)
                  .OnDelete(DeleteBehavior.Restrict);
        });

        // Configure Company entity
        modelBuilder.Entity<Company>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(200);
            entity.Property(e => e.Description).HasMaxLength(1000);
        });

        // Configure Application entity
        modelBuilder.Entity<Application>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.ApplicantName).IsRequired().HasMaxLength(200);
            entity.Property(e => e.ApplicantEmail).IsRequired().HasMaxLength(200);
            
            entity.HasOne(e => e.Job)
                  .WithMany(j => j.Applications)
                  .HasForeignKey(e => e.JobId)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        // Seed data
        modelBuilder.Entity<Company>().HasData(
            new Company { Id = 1, Name = "Tech Innovations Inc.", Description = "Leading technology company", Location = "San Francisco, CA" },
            new Company { Id = 2, Name = "Creative Solutions LLC", Description = "Digital marketing agency", Location = "New York, NY" }
        );

        modelBuilder.Entity<Job>().HasData(
            new Job 
            { 
                Id = 1, 
                Title = "Senior Software Engineer", 
                Description = "We are looking for an experienced software engineer...",
                CompanyId = 1,
                Location = "San Francisco, CA",
                Salary = 150000,
                PostedDate = DateTime.Now,
                IsActive = true
            },
            new Job 
            { 
                Id = 2, 
                Title = "UX/UI Designer", 
                Description = "Join our creative team as a UX/UI Designer...",
                CompanyId = 2,
                Location = "New York, NY",
                Salary = 95000,
                PostedDate = DateTime.Now,
                IsActive = true
            }
        );
    }
}
