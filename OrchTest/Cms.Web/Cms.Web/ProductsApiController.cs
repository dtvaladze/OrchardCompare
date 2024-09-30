using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrchardCore.ContentManagement;

namespace Cms.Web
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsApiController : ControllerBase
    {
        private readonly IContentManager _contentManager;

        public ProductsApiController(IContentManager contentManager)
        {
            _contentManager = contentManager;
        }

        // GET: api/products
        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _contentManager.Query("Product").ListAsync();
            return Ok(products);
        }

        // GET: api/products/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(string id)
        {
            var product = await _contentManager.GetAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        // POST: api/products
        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] Product product)
        {
            var newProduct = await _contentManager.NewAsync("Product");
            newProduct.Alter<ContentPart>(p =>
            {
                p.Content.Product.Name.Text = product.Name;
                p.Content.Product.Description.Text = product.Description;
                p.Content.Product.Price.Value = product.Price;
            });
            await _contentManager.CreateAsync(newProduct);
            return CreatedAtAction(nameof(GetProductById), new { id = newProduct.ContentItemId }, newProduct);
        }

        // PUT: api/products/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(string id, [FromBody] Product updatedProduct)
        {
            var product = await _contentManager.GetAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            product.Alter<ContentPart>(p =>
            {
                p.Content.Product.Name.Text = updatedProduct.Name;
                p.Content.Product.Description.Text = updatedProduct.Description;
                p.Content.Product.Price.Value = updatedProduct.Price;
            });

            await _contentManager.UpdateAsync(product);
            return NoContent();
        }

        // DELETE: api/products/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            var product = await _contentManager.GetAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            await _contentManager.RemoveAsync(product);
            return NoContent();
        }

    }
}
