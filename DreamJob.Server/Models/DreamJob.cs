namespace DreamJob.Server.Models;

public class DreamJob
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public required string JobDetails { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime LastModifiedDate { get; set; }
    
    public ICollection<JobSkill> Skills { get; set; } = new List<JobSkill>();
}
