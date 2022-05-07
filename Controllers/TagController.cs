using ComputerStoreWebApi.Data.Services;
using ComputerStoreWebApi.Data.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace ComputerStoreWebApi.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class TagController : Controller
    {
        public TagService _tagService;
        public TagController(TagService tagService)
        {
            _tagService = tagService;
        }

        [HttpPost("add-tag")]
        public IActionResult AddTag([FromBody]TagVM tag)
        {
            _tagService.AddTag(tag);
            return Ok();
        }     
        [HttpGet("search-product-by-tag/{name}")]
        public IActionResult GetProductByTag(string name)
        {
            var _response = _tagService.GetProductVM(name);
            if (_response != null)
            {
                return Ok(_response);
            }
            else return NotFound("No Products found");
        }
    }
}
