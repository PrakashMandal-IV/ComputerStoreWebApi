using ComputerStoreWebApi.Data.Model;
using ComputerStoreWebApi.Hash;
namespace ComputerStoreWebApi.Data
{
    public class AppDbInitializer
    {
        
        public static void Seed(IApplicationBuilder applicationbuilder)
        {
            using(var serviceScope= applicationbuilder.ApplicationServices.CreateScope())
            {
                HashPass hash = new HashPass();
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
                if (!context.Admin.Any())
                {
                    context.Admin.Add(new Admin()
                    {
                        
                        UserName = "Admin",
                        Password = hash.Hash("Admin"),
                        Email = "prakashmandal.iv@gmail.com",
                        PhoneNumber = 0000000000,                      
                    }); 
                    context.SaveChanges();
                }
            }
        }
    }
}
