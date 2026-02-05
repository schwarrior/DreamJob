namespace DreamJob.Server.Models;

public class Job
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int CompanyId { get; set; }
    public Company? Company { get; set; }
    public string Location { get; set; } = string.Empty;
    public decimal? Salary { get; set; }
    public DateTime PostedDate { get; set; }
    public bool IsActive { get; set; }
    public ICollection<Application> Applications { get; set; } = new List<Application>();
}
