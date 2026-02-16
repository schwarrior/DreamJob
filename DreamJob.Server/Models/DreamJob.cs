namespace DreamJob.Server.Models;

public class DreamJob
{
	public DreamJob()
	{
		Skills = new List<JobSkill>();
	}

    public int Id { get; set; }
    public required string Title { get; set; }
    public required string JobDetails { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime LastModifiedDate { get; set; }
    
    public virtual ICollection<JobSkill> Skills { get; set; }
}
