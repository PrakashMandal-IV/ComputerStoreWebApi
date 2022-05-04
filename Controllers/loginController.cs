using ComputerStoreWebApi.Data.Services;
using ComputerStoreWebApi.Data.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ComputerStoreWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class  LoginController : ControllerBase
    {
        private readonly LoginService? _loginService;
        public LoginController(LoginService loginService)
        {
            _loginService = loginService;
        }
        [HttpPost("admin-login")]
        public IActionResult AdminLogin([FromBody]AdminLoginVM adminLogin)
        {
            var _response = _loginService.AdminLogin(adminLogin);
            if(_response == "Not Found")
            {
                return NotFound();
            }
            else if(_response== "Invalid Detail")
            {
                return BadRequest("Invalid Details");
            }
            else
            {
                return Ok(_response);
            }
        }
    }
}
