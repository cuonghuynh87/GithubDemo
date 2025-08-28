using Application.Contracts;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepo productRepo;

        public ProductController(IProductRepo productRepo)
        {
            this.productRepo = productRepo;
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Product>> CreateProduct(Product model)
        {
            if (model == null)
            {
                return NotFound();
            }
            if (model.Id == Guid.Empty)
            {
                return BadRequest("Not a valid product id");
            }
            var product = await productRepo.CreateProduct(model);
            return Ok(product);
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(string id, Product product)
        {
            if (Guid.Parse(id) != product.Id)
            {
                return BadRequest("Not a valid product id");
            }

            await productRepo.UpdateProduct(product);
            return Ok();
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveProduct(string id)
        {
            if (string.IsNullOrEmpty(id) || Guid.Parse(id) == Guid.Empty)
                return BadRequest("Not a valid product id");

            var product = await productRepo.GetProductById(Guid.Parse(id));
            if (product == null)
            {
                return NotFound();
            }

            await productRepo.RemoveProduct(product);
            return Ok();
        }

        [HttpPost("search")]
        public async Task<ActionResult<IEnumerable<Product>>> SearchProducts([FromBody] string searchText)
        {
            if (string.IsNullOrEmpty(searchText))
            {
                return BadRequest("searchText can not be null");
            }

            return Ok(await productRepo.SearchProducts(searchText));
        }
    }
}
