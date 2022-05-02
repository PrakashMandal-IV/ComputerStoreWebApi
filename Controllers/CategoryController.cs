using ComputerStoreWebApi.Data.Services;
using ComputerStoreWebApi.Data.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace ComputerStoreWebApi.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class CategoryController : Controller
    {
        public CategpryService _categoryService;
        public CategoryController(CategpryService categpryService)
        {
            _categoryService = categpryService;
        }
        [HttpGet("get-all-category")]
        public IActionResult GetCategoryList()
        {
            var allCategory = _categoryService.GetCategoryList();
                return Ok(allCategory);
        }
        [HttpPost("add-category")]
        public IActionResult AddCategory([FromBody] CategoryVM category)
        {
            _categoryService.AddCategory(category); 
            return Ok();
        }
        [HttpPut("update-category/{id}")]
        public async Task<IActionResult> UpdateCategory(int id, [FromBody] CategoryVM category)
        {
            await Task.Run(() =>
            {
                var updateCategory = _categoryService.UpdateCategory(id, category);
                return Ok(updateCategory);
            });
            return Ok();
        }
        [HttpDelete("delete-category/{id}")]
        public async Task<IActionResult> Deletecategory(int id)
        {
            await Task.Run(() =>
            {
                _categoryService.DeleteCategory(id);
            });
            return Ok();
        }
    }
}
