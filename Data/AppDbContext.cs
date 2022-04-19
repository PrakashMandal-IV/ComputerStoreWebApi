using ComputerStoreBackEnd.Controllers;
using Microsoft.EntityFrameworkCore;

namespace ComputerStoreBackEnd.Data
{
    public class AppDbContext:DbContext
    {
       public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }
        public DbSet<Admin> Admin { get; set; }
    }
}
