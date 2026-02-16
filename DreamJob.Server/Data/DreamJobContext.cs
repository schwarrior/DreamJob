using Microsoft.EntityFrameworkCore;
using DreamJob.Server.Models;

namespace DreamJob.Server.Data;

public class DreamJobContext : DbContext
{
    public DreamJobContext(DbContextOptions<DreamJobContext> options)
        : base(options)
    {
    }

    public DbSet<Models.DreamJob> DreamJobs { get; set; }
    public DbSet<JobSkill> JobSkills { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Models.DreamJob>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Title).IsRequired().HasMaxLength(200);
            entity.Property(e => e.JobDetails).IsRequired();
            entity.HasMany(e => e.Skills)
                  .WithOne(e => e.DreamJob)
                  .HasForeignKey(e => e.DreamJobId)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<JobSkill>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
        });

        // Seed default dream job
        modelBuilder.Entity<Models.DreamJob>().HasData(
            new Models.DreamJob
            {
                Id = 1,
                Title = "Senior Full Stack Developer",
                JobDetails = @"We are seeking a talented Senior Full Stack Developer to join our innovative team. 

**About the Role:**
In this position, you will be responsible for designing, developing, and maintaining both front-end and back-end components of our web applications. You'll work closely with cross-functional teams to deliver high-quality software solutions.

**What You'll Do:**
• Design and implement scalable web applications
• Collaborate with designers and product managers
• Write clean, maintainable code
• Mentor junior developers
• Participate in code reviews and technical discussions

**What We Offer:**
• Competitive salary and benefits
• Remote-first work environment
• Professional development opportunities
• Flexible working hours
• Modern tech stack",
                CreatedDate = DateTime.UtcNow,
                LastModifiedDate = DateTime.UtcNow
            }
        );

        modelBuilder.Entity<JobSkill>().HasData(
            new JobSkill { Id = 1, Name = "C#", IsCustom = false, DreamJobId = 1 },
            new JobSkill { Id = 2, Name = "Angular", IsCustom = false, DreamJobId = 1 },
            new JobSkill { Id = 3, Name = "TypeScript", IsCustom = false, DreamJobId = 1 },
            new JobSkill { Id = 4, Name = "SQL Server", IsCustom = false, DreamJobId = 1 },
            new JobSkill { Id = 5, Name = "REST APIs", IsCustom = false, DreamJobId = 1 },
            new JobSkill { Id = 6, Name = "Git", IsCustom = false, DreamJobId = 1 }
        );
    }
}
