using Microsoft.AspNetCore.Mvc;
using SharedLibrary.Models;
using SharedLibrary.ProductRepositories;
namespace DemoBlazorCRUDOperationsWithDotNet8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository productRepository;
        public ProductController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        [HttpGet("All-Products")]
        public async Task<ActionResult<List<Product>>> GetAllProductAsync()
        {
            var products = await productRepository.GetAllProductsAsync();
            return Ok(products);
        } 
        
        [HttpGet("Single-Product/{id}")]
        public async Task<ActionResult<List<Product>>> GetSingleProductAsync(int id)
        {
            var product = await productRepository.GetProductByIdAsync(id);
            return Ok(product);
        }

        [HttpPost("Add-Product")]
        public async Task<ActionResult<List<Product>>> AddProductAsync(Product model)
        {
            var product = await productRepository.AddProductAsync(model);
            return Ok(product);
        }

        [HttpPut("Update-Product")]
        public async Task<ActionResult<List<Product>>> UpdateProductAsync(Product model)
        {
            var product = await productRepository.UpdateProductAsync(model);
            return Ok(product);
        }

        [HttpDelete("Delete-Product/{id}")]
        public async Task<ActionResult<List<Product>>> DeleteProductAsync(int id)
        {
            var product = await productRepository.DeleteProductAsync(id);
            return Ok(product);
        }

    }
}
