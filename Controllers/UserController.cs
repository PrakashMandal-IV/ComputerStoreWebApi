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
    }
}
