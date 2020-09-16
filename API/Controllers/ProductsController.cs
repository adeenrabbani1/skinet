using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Core.Entities;
using Infrastructure.Data;
using Core.Interfaces;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _repo;
        public ProductsController(IProductRepository repo)
        {
            _repo = repo;
        }

        //here we can make the routes 
        [HttpGet]
        public async Task<ActionResult<Product>> getProducts()
        {
            var products = await _repo.GetProductsAsync();
            return Ok(products);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> getProduct(int id)
        {
            var product = await _repo.GetProductByIdAsync(id); //data access code in the cotroller.P
            return Ok(product);

        }
        [HttpGet("types")]
        public async Task<ActionResult<Product>> getProductTypes()
        {
            var types = await _repo.GetProductsTypesAsync(); 
            return Ok(types);

        }

        [HttpGet("brands")]
        public async Task<ActionResult<Product>> getProductBrands()
        {
            var brands = await _repo.GetProductBrandsAsync(); 
            return Ok(brands);

        }

    }
}