using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DreamJob.Server.Data;
using DreamJob.Server.Models;

namespace DreamJob.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DreamJobsController : ControllerBase
{
    private readonly DreamJobContext _context;
    private readonly ILogger<DreamJobsController> _logger;

    public DreamJobsController(DreamJobContext context, ILogger<DreamJobsController> logger)
    {
        _context = context;
        _logger = logger;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<DreamJobDto>>> GetDreamJobs()
    {
        var dreamJobs = await _context.DreamJobs
            .Include(d => d.Skills)
            .ToListAsync();

        return Ok(dreamJobs.Select(d => MapToDto(d)));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<DreamJobDto>> GetDreamJob(int id)
    {
        var dreamJob = await _context.DreamJobs
            .Include(d => d.Skills)
            .FirstOrDefaultAsync(d => d.Id == id);

        if (dreamJob == null)
        {
            return NotFound();
        }

        return Ok(MapToDto(dreamJob));
    }

    [HttpPost]
    public async Task<ActionResult<DreamJobDto>> CreateDreamJob(CreateDreamJobDto dto)
    {
        var dreamJob = new Models.DreamJob
        {
            Title = dto.Title,
            JobDetails = dto.JobDetails,
            CreatedDate = DateTime.UtcNow,
            LastModifiedDate = DateTime.UtcNow,
            Skills = dto.Skills.Select(s => new JobSkill
            {
                Name = s,
                IsCustom = !IsCommonSkill(s)
            }).ToList()
        };

        _context.DreamJobs.Add(dreamJob);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetDreamJob), new { id = dreamJob.Id }, MapToDto(dreamJob));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateDreamJob(int id, UpdateDreamJobDto dto)
    {
        var dreamJob = await _context.DreamJobs
            .Include(d => d.Skills)
            .FirstOrDefaultAsync(d => d.Id == id);

        if (dreamJob == null)
        {
            return NotFound();
        }

        dreamJob.Title = dto.Title;
        dreamJob.JobDetails = dto.JobDetails;
        dreamJob.LastModifiedDate = DateTime.UtcNow;

        // Remove old skills
        _context.JobSkills.RemoveRange(dreamJob.Skills);

        // Add new skills
        dreamJob.Skills = dto.Skills.Select(s => new JobSkill
        {
            Name = s,
            IsCustom = !IsCommonSkill(s),
            DreamJobId = dreamJob.Id
        }).ToList();

        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteDreamJob(int id)
    {
        var dreamJob = await _context.DreamJobs.FindAsync(id);
        if (dreamJob == null)
        {
            return NotFound();
        }

        _context.DreamJobs.Remove(dreamJob);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpGet("common-skills")]
    public ActionResult<IEnumerable<string>> GetCommonSkills()
    {
        return Ok(CommonSkills);
    }

    private static DreamJobDto MapToDto(Models.DreamJob dreamJob)
    {
        return new DreamJobDto
        {
            Id = dreamJob.Id,
            Title = dreamJob.Title,
            JobDetails = dreamJob.JobDetails,
            Skills = dreamJob.Skills.Select(s => s.Name).ToList(),
            CreatedDate = dreamJob.CreatedDate,
            LastModifiedDate = dreamJob.LastModifiedDate
        };
    }

    private static bool IsCommonSkill(string skill)
    {
        return CommonSkills.Contains(skill, StringComparer.OrdinalIgnoreCase);
    }

    private static readonly List<string> CommonSkills = new()
    {
        "C#", "Java", "Python", "JavaScript", "TypeScript", "Go", "Rust", "PHP",
        "Angular", "React", "Vue.js", "Node.js", "ASP.NET", "Spring Boot",
        "SQL Server", "PostgreSQL", "MySQL", "MongoDB", "Redis",
        "Docker", "Kubernetes", "AWS", "Azure", "GCP",
        "Git", "CI/CD", "Agile", "REST APIs", "GraphQL", "Microservices"
    };
}
