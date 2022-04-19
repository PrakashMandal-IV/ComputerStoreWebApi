using ComputerStoreWebApi.Data;
using Microsoft.AspNetCore.Mvc;

namespace ComputerStoreWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdminController : ControllerBase
    {
        private int id = 0;    
        private readonly AppDbContext _dbContext;

        public AdminController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
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
        [HttpPost ]
    }
}