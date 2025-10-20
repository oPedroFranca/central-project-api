using System.ComponentModel.DataAnnotations;

namespace centralProjectApi.Application.DTOs.CardProject
{
    public class CreateCardProjectDto
    {
        [Required]
        public Guid CategoryId { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }

        [StringLength(50)]
        public string Status { get; set; } = "active";
        public string? Link { get; set; }
        public string? GithubLink { get; set; }
        public List<string>? Technologies { get; set; }
        public List<string>? Images { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public List<CreateCardParticipantDto>? Participants { get; set; }
    }

    public class CreateCardParticipantDto
    {
        [Required]
        [StringLength(255)]
        public string Name { get; set; } = string.Empty;

        [StringLength(100)]
        public string? Role { get; set; }
        public string? LinkedinUrl { get; set; }
        public string? GithubUrl { get; set; }
    }
}
