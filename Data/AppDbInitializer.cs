using ComputerStoreWebApi.Data.Model;
using ComputerStoreWebApi.Hash;
namespace ComputerStoreWebApi.Data
{
    public class AppDbInitializer
    {
        
        public static void Seed(IApplicationBuilder applicationbuilder)
        {
            using var serviceScope = applicationbuilder.ApplicationServices.CreateScope();
            HashPass hash = new();
            var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            if (!context.Admin.Any())
            {
                context.Admin.Add(new Admin()
                {
                    FirstName = "Admin",
                    Password = hash.Hash("Admin"),
                    Email = "prakashmandal.iv@gmail.com",               
                    PhoneNumber = 0000000000,
                });              
                context.SaveChanges();
            }
#pragma warning restore CS8602 // Dereference of a possibly null reference.
        }
    }
}
