namespace DreamJob.Server.Models;

public class DreamJobDto
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public required string JobDetails { get; set; }
    public List<string> Skills { get; set; } = new();
    public DateTime CreatedDate { get; set; }
    public DateTime LastModifiedDate { get; set; }
}

public class CreateDreamJobDto
{
    public required string Title { get; set; }
    public required string JobDetails { get; set; }
    public List<string> Skills { get; set; } = new();
}

public class UpdateDreamJobDto
{
    public required string Title { get; set; }
    public required string JobDetails { get; set; }
    public List<string> Skills { get; set; } = new();
}
