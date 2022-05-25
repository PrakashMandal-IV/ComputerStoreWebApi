using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ComputerStoreWebApi.Controllers
{
    [ApiController]
    [Route("Controller"),Authorize]
    public class UserController : Controller
    {  
        private UserService _userService;
        public UserController(UserService userService)
        {
            _userService = userService;
           
        }


        [HttpPost("add-user-address")]
        public IActionResult AddAddress([FromBody]AddressVM address)
        {
            string user = User.FindFirstValue(ClaimTypes.Email);
            bool _result = _userService.AddUserAddress(address, user);
            if( _result )
            {
                return Ok();
            }
            else
            {
                return BadRequest("User not found!");
            }
        }
        [HttpGet("get-user-address")]
        public ActionResult GetAddress()
        {
            
            string email = User.FindFirstValue(ClaimTypes.Email);
            var _response = _userService.GetUserAddress(email);
            return Ok(_response);
        }
        [HttpGet("get-user-detail")]
        public IActionResult GetUser()
        {
            string email = User.FindFirstValue(ClaimTypes.Email);
            var _response = _userService.GetUserDetail(email);
            if(_response == null)
            {
                return BadRequest("UserNotFound");
            }
            else
            {
                return Ok(_response);
            }  
        }

        [HttpGet("get-user-order")]
        public IActionResult GetOrder()
        {
            string email = User.FindFirstValue(ClaimTypes.Email);
            var _response = _userService.GetUserOrder(email);
            return Ok(_response);
        }

    }
}
