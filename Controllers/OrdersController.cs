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
        [HttpPost("update-order-status/{id}")]
        public async Task<IActionResult> ChangeStatus([FromBody]OrderStatus order,int id)
        {
            string email = User.FindFirstValue(ClaimTypes.Email);
           bool _response =  await Task.Run(() => _ordersService.ChangeOrderStatus(order, id, email));
            if (_response)
            {
                return Ok();
            }
            else return BadRequest();
        }

    }
}
