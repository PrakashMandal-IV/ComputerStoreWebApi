using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ComputerStoreWebApi.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    [Authorize]
    public class OrdersController : Controller
    {
        private readonly OrdersService _ordersService;
        public OrdersController(OrdersService ordersService)
        {
          _ordersService = ordersService;
        }
        [HttpPost("generate-order")]
        public async Task<IActionResult> GenerateOrder([FromBody]OrderVM order)
        {
            string email = User.FindFirstValue(ClaimTypes.Email);
            await Task.Run(() => _ordersService.CreateOrder(order, email));
            return Ok();
        }
    }
}
