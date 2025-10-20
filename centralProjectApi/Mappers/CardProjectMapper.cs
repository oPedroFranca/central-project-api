using centralProjectApi.Application.DTOs.CardProject;
using centralProjectApi.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace centralProjectApi.Application.Mappers
{
  public static class CardProjectMapper
  {
    public static CardProjectResponseDto ToResponseDto(this CardProject cardProject)
    {
      if (cardProject == null) return null;

      return new CardProjectResponseDto
      {
        Id = cardProject.Id,
        CategoryId = cardProject.CategoryId,
        Name = cardProject.Name,
        Description = cardProject.Description,
        Status = cardProject.Status,
        Link = cardProject.Link,
        GithubLink = cardProject.GithubLink,
        Technologies = cardProject.Technologies,
        Images = cardProject.Images,
        StartDate = cardProject.StartDate,
        EndDate = cardProject.EndDate,
        CreatedAt = cardProject.CreatedAt,
        UpdatedAt = cardProject.UpdatedAt,
        Participants = cardProject.Participants?
              .Select(p => p.ToResponseDto())
              .ToList() ?? new List<CardParticipantResponseDto>()
      };
    }

    public static CardParticipantResponseDto ToResponseDto(this CardParticipant participant)
    {
      if (participant == null) return null;

      return new CardParticipantResponseDto
      {
        Id = participant.Id,
        Name = participant.Name,
        Role = participant.Role,
        LinkedinUrl = participant.LinkedinUrl,
        GithubUrl = participant.GithubUrl
      };
    }

    public static List<CardProjectResponseDto> ToResponseDtoList(this IEnumerable<CardProject> cards)
    {
      return cards?.Select(c => c.ToResponseDto()).ToList() ?? new List<CardProjectResponseDto>();
    }
  }
}
