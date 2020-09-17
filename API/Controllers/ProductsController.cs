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
        private readonly IGenericRepository<Product> _productRepo;
        private readonly IGenericRepository<ProductBrand> _productBrandRepo;
        private readonly IGenericRepository<ProductType> _productTypeRepo;

        public ProductsController(IGenericRepository<Product> productRepo,
         IGenericRepository<ProductBrand> productBrandRepo,
        IGenericRepository<ProductType> productTypeRepo)
        {
            //each entity has its own repository methods
            _productTypeRepo = productTypeRepo;
            _productBrandRepo = productBrandRepo;
            _productRepo = productRepo;

        }

        //here we can make the routes 
        [HttpGet]
        public async Task<ActionResult<Product>> getProducts()
        {
            var products = await _productRepo.ListAllAsync();
            return Ok(products);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> getProduct(int id)
        {
            var product = await _productRepo.GetByIdAsync(id); //data access code in the cotroller.P
            return Ok(product);

        }
        [HttpGet("types")]
        public async Task<ActionResult<Product>> getProductTypes()
        {
            var types = await _productTypeRepo.ListAllAsync();
            return Ok(types);

        }

        [HttpGet("brands")]
        public async Task<ActionResult<Product>> getProductBrands()
        {
            var brands = await _productBrandRepo.ListAllAsync();
            return Ok(brands);

        }

    }
}