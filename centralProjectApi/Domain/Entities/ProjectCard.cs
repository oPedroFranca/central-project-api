namespace centralProjectApi.Domain.Entities
{
  public class CardProject
  {
    public Guid Id { get; set; }
    public Guid CategoryId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string Status { get; set; } = string.Empty;
    public string? Link { get; set; }
    public string? GithubLink { get; set; }
    public List<string>? Technologies { get; set; }
    public List<string>? Images { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public Category? Category { get; set; }
    public ICollection<CardParticipant> Participants { get; set; } = new List<CardParticipant>();
  }
}
