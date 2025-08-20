using Microsoft.AspNetCore.Mvc;
using RedisExampleApp.API.Models;
using RedisExampleApp.API.Repository;

namespace RedisExampleApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        private readonly IProductRepository _porductRepository;

        public ProductsController(IProductRepository porductRepository)
        {
            _porductRepository = porductRepository; 
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() 
        {
            var value = await _porductRepository.GetAsync();
            return Ok(value);
        }

        // www.api.com/products/10
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) 
        {
            var value = await _porductRepository.GetByIdAsync(id);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product product) 
        {
            await _porductRepository.CreateAsync(product);
            return Created();
        }

    }
}
