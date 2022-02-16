using CleanArchProject.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchProject.WebAPI.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts() =>
            Ok(await _productService.GetProducts());
    }
}
