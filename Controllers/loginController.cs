

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ComputerStoreWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class  LoginController : ControllerBase
    {
       
        private readonly AdminService _adminService;
        private readonly UserService _userService;
        private readonly LoginService? _loginService;
        public LoginController(LoginService loginService,AdminService admin,UserService user)
        {
            _loginService = loginService;
            _adminService = admin;
            _userService = user;
        }
        //register admin
        [HttpGet("check-validation"),Authorize]
        public ActionResult CheckToken()
        {
            return Ok();
        }
       [HttpPost("register-admin"),Authorize(Roles ="Admin")]
        public ActionResult<string> RegisterAdmin([FromBody] AdminVM admin)
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            if(_adminService.AddAdmin(admin,email))
            {
                return Ok("Admin Created Successfully");
            }
            else
            {
                return BadRequest("Admin with same Email or phone number already exist !");
            }         
        } 
        [HttpPost("register-user")]
        public async Task<IActionResult> RegisterUser([FromBody] UserVM user)
        {
            var _user = await Task.Run(() => _userService.RegisterUser(user));
            if(_user == true)
            {
                return Ok();
            }
            else
            {
                return BadRequest("User with same email already exist");
            }

        }
        [HttpPost("user-login")]
        public async Task<IActionResult> UserLogin([FromBody] UserLoginVM user)
        {
            var _response = await Task.Run(()=> _loginService?.UserLogin(user));
            if (_response == "not found")
            {
                return NotFound();
            }
            else if (_response == "Invalid Detail")
            {
                return BadRequest("Invalid details");
            }
            else return Ok(_response);
        }
        //admin lOGIN
        [HttpPost("admin-login")]
        public IActionResult AdminLogin([FromBody]AdminLoginVM adminLogin)
        {
            var _response = _loginService?.AdminLogin(adminLogin);
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
