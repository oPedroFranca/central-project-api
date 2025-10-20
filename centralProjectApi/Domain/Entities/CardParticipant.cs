using System;

namespace centralProjectApi.Domain.Entities
{
  public class CardParticipant
  {
    public Guid Id { get; set; }
    public Guid CardId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Role { get; set; }
    public string? LinkedinUrl { get; set; }
    public string? GithubUrl { get; set; }
    public CardProject? Card { get; set; }
  }
}
