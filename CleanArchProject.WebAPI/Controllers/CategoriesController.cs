using CleanArchProject.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace CleanArchProject.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategories() => 
            Ok(await _categoryService.GetCategories());
    }
}
