using ComputerStoreWebApi.Data.Services;
using ComputerStoreWebApi.Data.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ComputerStoreWebApi.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    [Authorize(Roles = "Admin")]
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
            string email = User.FindFirstValue(ClaimTypes.Email);
            _productService.AddProduct(product,email);
            return Ok();
        }
        [HttpPut("update-product-name/{id}")]
        public async Task<IActionResult> UpdateProductName(int id,[FromBody] ProductVMbyName product)
        {
            await Task.Run(() =>
            {
                string email = User.FindFirstValue(ClaimTypes.Email);
                var _response = _productService.UpdateProductName(id, product, email);
                return Ok(_response);
            });
            return Ok();
        }
        [HttpPut("update-product-description/{id}")]
        public async Task<IActionResult> UpdateProductDescription(int id, [FromBody] ProductVMbyDescription product)
        {
            await Task.Run(() =>
            {
                string email = User.FindFirstValue(ClaimTypes.Email);
                var _response = _productService.UpdateProductDescription(id, product, email);
                return Ok(_response);
            });
            return Ok();           
        }
        [HttpPut("update-product-image/{id}")]
        public async Task<IActionResult> UpdateProductImage(int id, [FromBody] ProductVMImage product)
        {
            await Task.Run(() =>
            {
                string email = User.FindFirstValue(ClaimTypes.Email);
                var _response = _productService.UpdateProductImage(id, product, email);
                return Ok(_response);
            });
            return Ok();
        }
        [HttpPut("update-product-price/{id}")]
        public async Task<IActionResult> UpdateProductprice(int id, [FromBody] ProductVMPrice product)
        {
            await Task.Run(() =>
            {
                string email = User.FindFirstValue(ClaimTypes.Email);
                var _response = _productService.UpdateProductPrice(id, product, email);
                return Ok(_response);
            });
            return Ok();
        }
        [HttpPut("update-product-stock/{id}")]
        public async Task<IActionResult> UpdateProductStock(int id, [FromBody] ProductVMStock product)
        {
            await Task.Run(() =>
            {
                string email = User.FindFirstValue(ClaimTypes.Email);
                var _response = _productService.UpdateProductStock(id, product, email);
                return Ok(_response);
            });
            return Ok();
        }
    }
}
