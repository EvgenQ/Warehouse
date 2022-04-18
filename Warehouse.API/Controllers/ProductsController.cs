using Microsoft.AspNetCore.Mvc;
using Warehouse.API.Contracts;
using Warehouse.Domain;

namespace Warehouse.API.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class ProductsController : ControllerBase
    {
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(ILogger<ProductsController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductRequest request)
        {
            var (product, errors) = Product.CreateProduct(
                request.Name,
                request.Description,
                request.PricePerKg,
                request.Weight,
                request.Category);

            if (product is null || errors.Any())
            {
                _logger.LogError("{errors}", errors);
                return BadRequest(errors);
            }

            ProductRepository.Add(product);

            return Ok(product);
        }
    }
}
