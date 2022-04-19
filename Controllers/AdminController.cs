using Microsoft.AspNetCore.Mvc;

namespace ComputerStoreBackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdminController : ControllerBase
    {
        private int id = 0;    
        private readonly ILogger<AdminController> _logger;

        public AdminController(ILogger<AdminController> logger)
        {
            _logger = logger;
        }
        [HttpGet(Name = "Admin")]
        public IEnumerable<Admin> Get()
        {
            return Enumerable.Range(1, 1).Select(Index => new Admin
            {
                Id = id++,
                FirstName = "Admin",
                LastName = "Admin",
                Password = "Admim"
            });
        }
    }
}