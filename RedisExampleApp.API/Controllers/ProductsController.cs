using Microsoft.AspNetCore.Mvc;
using RedisExampleApp.API.Models;
using RedisExampleApp.API.Repository;
using RedisExampleApp.API.Services;
using RedisExampleApp.Cache;

namespace RedisExampleApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        //private readonly IProductRepository _productService;

        //public ProductsController(IProductRepository porductRepository)
        //{
        //    _productService = porductRepository;
        //}

        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() 
        {
            var value = await _productService.GetAsync();
            return Ok(value);
        }


        // www.api.com/products/10
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) 
        {
            var value = await _productService.GetByIdAsync(id);
            return Ok(value);
        }


        [HttpPost]
        public async Task<IActionResult> Create(Product product) 
        {
            await _productService.CreateAsync(product);
            return Created();
        }

    }
}
