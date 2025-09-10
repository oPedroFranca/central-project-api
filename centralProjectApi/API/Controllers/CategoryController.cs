using centralProjectApi.Application.DTOs;
using centralProjectApi.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace centralProjectApi.API.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost("CreateCategory")]
        public async Task<IActionResult> CreateCategory([FromBody] CategoryCreateDto dto)
        {
            if (dto == null || string.IsNullOrEmpty(dto.Name)) return BadRequest("Invalid category data");

            try
            {
                await _categoryService.CreateCategoryAsync(dto);

                return Ok(new { success = true, message = "Category created successfully" });
            }
            catch { return StatusCode(500, "An unexpected error occurred. Try again later."); }
        }

    }
}
