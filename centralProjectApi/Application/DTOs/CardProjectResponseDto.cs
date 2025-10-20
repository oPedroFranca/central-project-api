
namespace centralProjectApi.Application.DTOs.CardProject
{
    public class CardProjectResponseDto
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
        public List<CardParticipantResponseDto> Participants { get; set; } = new();
    }

    public class CardParticipantResponseDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Role { get; set; }
        public string? LinkedinUrl { get; set; }
        public string? GithubUrl { get; set; }
    }
}
