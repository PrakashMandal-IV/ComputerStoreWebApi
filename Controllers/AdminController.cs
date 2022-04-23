using ComputerStoreWebApi.Data;
using ComputerStoreWebApi.Data.Services;
using ComputerStoreWebApi.Data.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace ComputerStoreWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdminController : ControllerBase
    {
        public AdminService _AdminService;

        public AdminController(AdminService adminService)
        {
            _AdminService = adminService;
        }
        [HttpPost("add-book")]
        public IActionResult AddAdmin([FromBody] AdminVM admin)
        {
            _AdminService.AddAdmin(admin);
            return Ok();
        }
        
    }
}