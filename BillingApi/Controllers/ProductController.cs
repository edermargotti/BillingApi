using BillingApi.Domain.Models;
using BillingApi.Service.Interfaces;
using BillingApi.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BillingApi.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService) => _productService = productService;

        [HttpGet]
        [ProducesDefaultResponseType(typeof(List<Product>))]
        public async Task<ActionResult> GetProducts()
        {
            try
            {
                var response = await _productService.GetProducts();
                if (response != null)
                    return Ok(response);
                else
                    return NotFound();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        [ProducesDefaultResponseType(typeof(Product))]
        public async Task<ActionResult> GetProduct(int id)
        {
            try
            {
                var response = await _productService.GetProduct(id);
                if (response != null)
                    return Ok(response);
                else
                    return NotFound();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [ProducesDefaultResponseType(typeof(Product))]
        public async Task<ActionResult> PostProduct(ProductViewModel product)
        {
            try
            {
                //return Ok(response);

                var response = await _productService.PostProduct(product);
                if (response != null)
                    return CreatedAtAction(nameof(GetProduct), new { id = response }, product);
                else
                    return NotFound();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, ProductViewModel product)
        {
            try
            {
                if (id != product.Id)
                    return BadRequest();

                await _productService.PutProduct(product);

                return NotFound();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            try
            {
                await _productService.DeleteProduct(id);

                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
