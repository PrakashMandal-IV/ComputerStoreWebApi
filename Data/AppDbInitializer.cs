using ComputerStoreWebApi.Controllers;
using Microsoft.EntityFrameworkCore;

namespace ComputerStoreWebApi.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationbuilder)
        {
            using(var serviceScope= applicationbuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
                
                    context.Admin.Add(new Admin()
                    {
                        UserName = "Admin",
                        Password = "Admin",
                        Email = "prakashmandal.iv@gmail.com",
                        PhoneNumber = 0000000000,
                        CreatedAt = DateTime.Now,
                        CreatedBy = 0,
                        ModifiedAt = DateTime.Now,
                        ModifiedBy = 0,
                    });
                    context.SaveChanges();
                        

                    
                
            }
        }
    }
}
