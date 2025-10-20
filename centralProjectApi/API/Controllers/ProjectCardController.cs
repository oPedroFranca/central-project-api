using centralProjectApi.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace centralProjectApi.API.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class ProjectCardController : ControllerBase
  {
    private readonly IProjectCardService _projectCardService;
    public ProjectCardController(IProjectCardService projectCardService)
    {
      _projectCardService = projectCardService;
    }

    [Authorize]
    [HttpGet("ListProjectCardsByUser")]
    public async Task<IActionResult> ListProjectCardsByUser()
    {
      try
      {
        var projectCards = await _projectCardService.ListProjectCardsByUserAsync();
        return Ok(projectCards);
      }
      catch
      {
        return StatusCode(500, "An unexpected error occurred while fetching project cards.");
      }
    }

    [Authorize]
    [HttpGet("ListProjectCardsByCategory/{categoryId}")]
    public async Task<IActionResult> ListProjectCardsByCategory(Guid categoryId)
    {
      try
      {
        var projectCards = await _projectCardService.ListProjectCardsByCategoryAsync(categoryId);
        return Ok(projectCards);
      }
      catch
      {
        return StatusCode(500, "An unexpected error occurred while fetching project cards by category.");
      }
    }
  }
}
