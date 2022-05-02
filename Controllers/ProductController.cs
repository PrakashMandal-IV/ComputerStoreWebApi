﻿using ComputerStoreWebApi.Data.Services;
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
        public async Task<IActionResult> UpdateProduct(int id,[FromBody] ProductVMbyName product)
        {
            var _response = _productService.UpdateProductName(id,product);
            return Ok(_response);

        }
    }
}
