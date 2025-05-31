using Microsoft.AspNetCore.Mvc;
using MiddysProducts.Services;
using MiddysProducts.Services.Models;

namespace MiddysProducts.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductsController(IProductService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetAll(CancellationToken cancellationToken = default)
        {
            var products = await _service.GetAllAsync(cancellationToken);
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetById([FromRoute] int id, CancellationToken cancellationToken = default)
        {
            var product = await _service.GetByIdAsync(id, cancellationToken);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<ProductDto>> Create([FromBody] CreateProductDto product, CancellationToken cancellationToken = default)
        {
            var result = await _service.CreateAsync(product, cancellationToken);

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateProductDto dto, CancellationToken cancellationToken = default)
        {
            var success = await _service.UpdateAsync(id, dto, cancellationToken);
            if (!success)
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id, CancellationToken cancellationToken = default)
        {
            var success = await _service.DeleteAsync(id, cancellationToken);
            if (!success)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}
