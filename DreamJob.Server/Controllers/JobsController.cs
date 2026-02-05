using DreamJob.Server.Data;
using DreamJob.Server.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DreamJob.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class JobsController : ControllerBase
{
    private readonly DreamJobDbContext _context;
    private readonly ILogger<JobsController> _logger;

    public JobsController(DreamJobDbContext context, ILogger<JobsController> logger)
    {
        _context = context;
        _logger = logger;
    }

    // GET: api/Jobs
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Job>>> GetJobs()
    {
        return await _context.Jobs
            .Include(j => j.Company)
            .Where(j => j.IsActive)
            .OrderByDescending(j => j.PostedDate)
            .ToListAsync();
    }

    // GET: api/Jobs/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Job>> GetJob(int id)
    {
        var job = await _context.Jobs
            .Include(j => j.Company)
            .FirstOrDefaultAsync(j => j.Id == id);

        if (job == null)
        {
            return NotFound();
        }

        return job;
    }

    // POST: api/Jobs
    [HttpPost]
    public async Task<ActionResult<Job>> PostJob(Job job)
    {
        job.PostedDate = DateTime.Now;
        _context.Jobs.Add(job);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetJob), new { id = job.Id }, job);
    }

    // PUT: api/Jobs/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutJob(int id, Job job)
    {
        if (id != job.Id)
        {
            return BadRequest();
        }

        _context.Entry(job).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!JobExists(id))
            {
                return NotFound();
            }
            throw;
        }

        return NoContent();
    }

    // DELETE: api/Jobs/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteJob(int id)
    {
        var job = await _context.Jobs.FindAsync(id);
        if (job == null)
        {
            return NotFound();
        }

        _context.Jobs.Remove(job);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool JobExists(int id)
    {
        return _context.Jobs.Any(e => e.Id == id);
    }
}
