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

        //get all admin end point
        [HttpGet("get-all-admin")]
        public IActionResult GetAdminList()
        {
            var allAdmins = _AdminService.GetAdminList();
            return Ok(allAdmins);
        }

        //get admin by id
        [HttpGet("get-by-id-admin/{id}")]
        public IActionResult GetAdminById(int id)
        {
            var admin = _AdminService.GetAdminById(id);
            return Ok(admin);
        }

        //create new admin
        [HttpPost("add-book")]
        public IActionResult AddAdmin([FromBody] AdminVM admin)
        {
            _AdminService.AddAdmin(admin);
            return Ok();
        }
        
    }

}