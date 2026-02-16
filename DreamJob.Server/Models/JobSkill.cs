namespace DreamJob.Server.Models;

public class JobSkill
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public bool IsCustom { get; set; }
    
    public int DreamJobId { get; set; }
    public DreamJob? DreamJob { get; set; }
}
