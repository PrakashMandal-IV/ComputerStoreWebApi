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
        [HttpGet("get-all-product")]
        public async Task<IActionResult> GetProduct()
        {         
                var _product = await Task.Run(()=> _productService.GetAllProduct());
                return Ok(_product);         
        }
        [HttpPut("update-product-name/{id}")]
        public async Task<IActionResult> UpdateProductName(int id,[FromBody] ProductVMbyName product)
        {          
                string email = User.FindFirstValue(ClaimTypes.Email);
                var _response = await Task.Run(() => _productService.UpdateProductName(id, product, email));
                return Ok(_response);  
        }
        [HttpPut("update-product-description/{id}")]
        public async Task<IActionResult> UpdateProductDescription(int id,[FromBody] ProductVMbyDescription product)
        {
                string email = User.FindFirstValue(ClaimTypes.Email);
                var _response = await Task.Run(() => _productService.UpdateProductDescription(id, product, email));
                return Ok(_response);
                     
        }
        [HttpPut("update-product-image/{id}")]
        public async Task<IActionResult> UpdateProductImage(int id, [FromBody] ProductVMImage product)
        {          
                string email = User.FindFirstValue(ClaimTypes.Email);
                var _response = await Task.Run(() => _productService.UpdateProductImage(id, product, email));
                return Ok(_response);
        }
        [HttpPut("update-product-price/{id}")]
        public async Task<IActionResult> UpdateProductprice(int id, [FromBody] ProductVMPrice product)
        {      
                string email = User.FindFirstValue(ClaimTypes.Email);
                var _response = await Task.Run(() => _productService.UpdateProductPrice(id, product, email));
                return Ok(_response);
           
        }
        [HttpPut("update-product-stock/{id}")]
        public async Task<IActionResult> UpdateProductStock(int id, [FromBody] ProductVMStock product)
        {
           
                string email = User.FindFirstValue(ClaimTypes.Email);
                var _response = await Task.Run(() => _productService.UpdateProductStock(id, product, email));
                return Ok(_response);           
        }
    }
}
