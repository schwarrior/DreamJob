using DreamJob.Server.Data;
using DreamJob.Server.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DreamJob.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ApplicationsController : ControllerBase
{
    private readonly DreamJobDbContext _context;

    public ApplicationsController(DreamJobDbContext context)
    {
        _context = context;
    }

    // GET: api/Applications
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Application>>> GetApplications()
    {
        return await _context.Applications
            .Include(a => a.Job)
            .ThenInclude(j => j.Company)
            .OrderByDescending(a => a.AppliedDate)
            .ToListAsync();
    }

    // GET: api/Applications/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Application>> GetApplication(int id)
    {
        var application = await _context.Applications
            .Include(a => a.Job)
            .ThenInclude(j => j.Company)
            .FirstOrDefaultAsync(a => a.Id == id);

        if (application == null)
        {
            return NotFound();
        }

        return application;
    }

    // GET: api/Applications/ByJob/5
    [HttpGet("ByJob/{jobId}")]
    public async Task<ActionResult<IEnumerable<Application>>> GetApplicationsByJob(int jobId)
    {
        return await _context.Applications
            .Where(a => a.JobId == jobId)
            .OrderByDescending(a => a.AppliedDate)
            .ToListAsync();
    }

    // POST: api/Applications
    [HttpPost]
    public async Task<ActionResult<Application>> PostApplication(Application application)
    {
        application.AppliedDate = DateTime.Now;
        application.Status = "Submitted";
        
        _context.Applications.Add(application);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetApplication), new { id = application.Id }, application);
    }

    // PUT: api/Applications/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutApplication(int id, Application application)
    {
        if (id != application.Id)
        {
            return BadRequest();
        }

        _context.Entry(application).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ApplicationExists(id))
            {
                return NotFound();
            }
            throw;
        }

        return NoContent();
    }

    // DELETE: api/Applications/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteApplication(int id)
    {
        var application = await _context.Applications.FindAsync(id);
        if (application == null)
        {
            return NotFound();
        }

        _context.Applications.Remove(application);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool ApplicationExists(int id)
    {
        return _context.Applications.Any(e => e.Id == id);
    }
}
