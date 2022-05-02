using ComputerStoreWebApi.Data.Services;
using ComputerStoreWebApi.Data.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace ComputerStoreWebApi.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class ProductController : Controller
    {
        public ProductService _productService;
        public ProductController(ProductService productService)
        {
            _productService = productService;
        }
        [HttpPost("add-product")]
        public IActionResult AddProduct([FromBody] ProductVM product)
        {
            _productService.AddProduct(product);
            return Ok();
        }
        [HttpPut("update-product-name/{id}")]
        public async Task<IActionResult> UpdateProductName(int id,[FromBody] ProductVMbyName product)
        {
            await Task.Run(() =>
            {
                var _response = _productService.UpdateProductName(id, product);
                return Ok(_response);
            });
            return Ok();
        }
        [HttpPut("update-product-description/{id}")]
        public async Task<IActionResult> UpdateProductDescription(int id, [FromBody] ProductVMbyDescription product)
        {
            await Task.Run(() =>
            {
                var _response = _productService.UpdateProductDescription(id, product);
                return Ok(_response);
            });
            return Ok();           
        }
        [HttpPut("update-product-image/{id}")]
        public async Task<IActionResult> UpdateProductImage(int id, [FromBody] ProductVMImage product)
        {
            await Task.Run(() =>
            {
                var _response = _productService.UpdateProductImage(id, product);
                return Ok(_response);
            });
            return Ok();
        }
        [HttpPut("update-product-price/{id}")]
        public async Task<IActionResult> UpdateProductprice(int id, [FromBody] ProductVMPrice product)
        {
            await Task.Run(() =>
            {
                var _response = _productService.UpdateProductPrice(id, product);
                return Ok(_response);
            });
            return Ok();
        }
    }
}
