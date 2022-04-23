

using ComputerStoreWebApi.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace ComputerStoreWebApi.Data
{
    public class AppDbContext:DbContext
    {
       public AppDbContext(DbContextOptions options):base(options)
        {

        }
        public DbSet<Admin> Admin { get; set; }
    }
}
