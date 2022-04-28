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
    }
}
