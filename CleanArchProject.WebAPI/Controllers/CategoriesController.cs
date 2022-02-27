using CleanArchProject.Application.DTOs;
using CleanArchProject.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchProject.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<ActionResult<CategoryDTO>> Get()
        {
            var categories = await _categoryService.GetCategories();
            if (categories == null) return NotFound("Categories not found");
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDTO>> GetByid(int id)
        {
            var category = await _categoryService.GetCategoryById(id);
            if (category == null) return NotFound("Category not found");
            return Ok(category);
        }

        [HttpPost]
        public async Task<ActionResult<CategoryDTO>> Create(CategoryDTO categoryDto)
        {
            if(categoryDto == null) 
                return BadRequest("Invalid Data");
            await _categoryService.Add(categoryDto);
            return CreatedAtAction(nameof(Create), categoryDto);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Update(int id, CategoryDTO categoryDto)
        {
            if (id != categoryDto.Id) return BadRequest("Not corresponding data");

            var existingCategory = await _categoryService.GetCategoryById(id);
            if (existingCategory == null) return NotFound("There's nothing to update");

            await _categoryService.Update(categoryDto);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteCategories(int id)
        {
            var existingCategory = await _categoryService.GetCategoryById(id);
            if (existingCategory is null) 
                return NotFound("Category not found");
            await _categoryService.Delete(id);
            return NoContent();
        }
    }
}
