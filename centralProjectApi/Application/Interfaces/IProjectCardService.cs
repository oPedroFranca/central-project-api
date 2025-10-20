using centralProjectApi.Application.DTOs.CardProject;

namespace centralProjectApi.Application.Interfaces
{
  public interface IProjectCardService
  {
    Task<List<CardProjectResponseDto>> ListProjectCardsByUserAsync();
    Task<List<CardProjectResponseDto>> ListProjectCardsByCategoryAsync(Guid categoryId);
  }
}
