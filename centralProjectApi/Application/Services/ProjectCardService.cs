using centralProjectApi.Application.DTOs.CardProject;
using centralProjectApi.Application.Interfaces;
using centralProjectApi.Application.Mappers;
using centralProjectApi.Domain.Interfaces;

namespace centralProjectApi.Application.Services
{
  public class ProjectCardService : IProjectCardService
  {
    private readonly ICardProjectRepository _cardProjectRepository;
    private readonly IUserContextService _userContextService;

    public ProjectCardService(
      ICardProjectRepository cardProjectRepository,
      IUserContextService userContextService)
    {
      _cardProjectRepository = cardProjectRepository;
      _userContextService = userContextService;
    }

    public async Task<List<CardProjectResponseDto>> ListProjectCardsByUserAsync()
    {
      var userId = _userContextService.GetCurrentUserId();
      var projectCards = await _cardProjectRepository.GetListProjectCardsByUserIdAsync(userId);

      return projectCards.ToResponseDtoList();
    }

    public async Task<List<CardProjectResponseDto>> ListProjectCardsByCategoryAsync(Guid categoryId)
    {
      var projectCards = await _cardProjectRepository.GetListProjectCardsByCategoryIdAsync(categoryId);

      return projectCards.ToResponseDtoList();
    }
  }
}
