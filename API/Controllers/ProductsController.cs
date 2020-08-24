using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Core.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Data;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly StoreContext _context;
        public ProductsController(StoreContext context)
        {
            _context = context;
        }

        //here we can make the routes 
        [HttpGet]

        public async Task<ActionResult<Product>> getProducts()
        {
            var products = await _context.Products.ToListAsync();
            return Ok(products);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> getproduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            return Ok(product);

        }

    }
}