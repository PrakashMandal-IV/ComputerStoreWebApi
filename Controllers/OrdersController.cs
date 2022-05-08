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
        [HttpPost("update-order-status/{id}"),Authorize(Roles ="Admin")]
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
        [HttpPost("update-order-status/{id}"), Authorize(Roles = "Admin")]
        public async Task<IActionResult> ChangeSubStatus([FromBody] OrderSubStatus order, int id)
        {
            string email = User.FindFirstValue(ClaimTypes.Email);
            bool _response = await Task.Run(() => _ordersService.ChangeOrderSubStatus(order, id, email));
            if (_response)
            {
                return Ok();
            }
            else return BadRequest("Invalid Input");
        }
        [HttpGet("get-all-orders/{sort}"),Authorize(Roles ="Admin")]
        public async Task<IActionResult> GetAllOrders(string sort)
        {
            var _response = await Task.Run(() => _ordersService.GetAllOrders(sort));
            if(_response != null)
            {
                return Ok(_response);
            }
            else return NotFound();
        }
        [HttpGet("get-pending-orders"), Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetPendingOrders()
        {
            var _response = await Task.Run(() => _ordersService.GetPendingOrders());
            if (_response != null)
            {
                return Ok(_response);
            }
            else return NotFound();
        }
        [HttpGet("get-completed-orders"), Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetCompletedOrders()
        {
            var _response = await Task.Run(() => _ordersService.GetCompletedOrders());
            if (_response != null)
            {
                return Ok(_response);
            }
            else return NotFound();
        }
        [HttpGet("get-return-orders"), Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetReturnOrders()
        {
            var _response = await Task.Run(()=> _ordersService.GetReturnOrders());
            if (_response != null)
            {
                return Ok(_response);
            }
            else return NotFound();
        }
        [HttpGet("get-product-orders/{id}"), Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetPorductOrders(int id)
        {
            var _response = await Task.Run(() => _ordersService.GetOrderByProductId(id));
            if (_response != null)
            {
                return Ok(_response);
            }
            else return NotFound();
        }

    }
}
