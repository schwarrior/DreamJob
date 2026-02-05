namespace DreamJob.Server.Models;

public class Application
{
    public int Id { get; set; }
    public int JobId { get; set; }
    public Job? Job { get; set; }
    public string ApplicantName { get; set; } = string.Empty;
    public string ApplicantEmail { get; set; } = string.Empty;
    public string? Resume { get; set; }
    public string? CoverLetter { get; set; }
    public DateTime AppliedDate { get; set; }
    public string Status { get; set; } = "Submitted"; // Submitted, Under Review, Interview, Rejected, Accepted
}
