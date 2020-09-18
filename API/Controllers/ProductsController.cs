using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Core.Entities;
using Infrastructure.Data;
using Core.Interfaces;
using Core.Specifications;
using AutoMapper;
using API.Dtos;
using System.Linq;
using System.Collections.Generic;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IGenericRepository<Product> _productRepo;
        private readonly IGenericRepository<ProductBrand> _productBrandRepo;
        private readonly IGenericRepository<ProductType> _productTypeRepo;
        private readonly IMapper _mapper;

        public ProductsController(IGenericRepository<Product> productRepo,
         IGenericRepository<ProductBrand> productBrandRepo,
        IGenericRepository<ProductType> productTypeRepo, IMapper mapper)
        {
            _mapper = mapper;
            //each entity has its own repository methods
            _productTypeRepo = productTypeRepo;
            _productBrandRepo = productBrandRepo;
            _productRepo = productRepo;

        }

        //here we can make the routes 
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProductDto>>> getProducts()
        {
            var spec = new ProductWithBrandAndTypesSpecification();
            var products = await _productRepo.ListAsync(spec);
            return Ok(_mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductDto>>(products));

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> getProduct(int id)
        {
            var spec = new ProductWithBrandAndTypesSpecification(id); //criteria will be set
            var product = await _productRepo.GetEntityBySpec(spec); //data access code in the cotroller.P
            return Ok(_mapper.Map<Product, ProductDto>(product));

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