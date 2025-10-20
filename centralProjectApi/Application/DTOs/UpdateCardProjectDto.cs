using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace centralProjectApi.Application.DTOs.CardProject
{
    public class UpdateCardProjectDto
    {
        public Guid? CategoryId { get; set; }

        [StringLength(255)]
        public string? Name { get; set; }

        public string? Description { get; set; }

        [StringLength(50)]
        public string? Status { get; set; }

        public string? Link { get; set; }

        public string? GithubLink { get; set; }

        public List<string>? Technologies { get; set; }

        public List<string>? Images { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public List<CreateCardParticipantDto>? Participants { get; set; }
    }
}
