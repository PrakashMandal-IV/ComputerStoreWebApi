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
        [HttpGet("get-tag-by-name")]
        public IActionResult GetTagByName(string name)
        {
            var tag = _tagService.GetTagByName(name);
            return Ok(tag);
        }
    }
}
