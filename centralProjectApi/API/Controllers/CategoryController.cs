using centralProjectApi.Application.DTOs;
using centralProjectApi.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize]
        [HttpPost("CreateCategory")]
        public async Task<IActionResult> CreateCategory([FromBody] CategoryCreateDto dto)
        {
            try
            {
                await _categoryService.CreateCategoryAsync(dto);

                return Ok(new { success = true, message = "Category created successfully" });
            }
            catch { return StatusCode(500, "An unexpected error occurred. Try again later."); }
        }

        [Authorize]
        [HttpGet("ListCategory")]
        public async Task<IActionResult> ListCategories()
        {
            try
            {
                var categories = await _categoryService.GetUserCategoriesAsync();
                return Ok(categories);
            }
            catch
            {
                return StatusCode(500, "An unexpected error occurred while fetching categories.");
            }
        }

        [Authorize]
        [HttpPut("UpdateCategory")]
        public async Task<IActionResult> UpdateCategory([FromBody] CategoryUpdateDto dto)
        {
            try
            {
                await _categoryService.UpdateCategoryAsync(dto);
                return Ok(new { success = true, message = "Category updated successfully" });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { success = false, message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, message = "Erro inesperado ao atualizar categoria.", details = ex.Message });
            }
        }

        [Authorize]
        [HttpDelete("DeleteCategory")]
        public async Task<IActionResult> DeleteCategory(Guid categoryId)
        {
            try
            {
                await _categoryService.DeleteCategoryAsync(categoryId);
                return Ok(new { success = true, message = "Category deleted successfully" });
            }
            catch
            {
                return StatusCode(500, "An unexpected error occurred while deleting the category.");
            }
        }
    }
}
