


using ComputerStoreBackEnd.Controllers;
using ComputerStoreBackEnd.Data;
using ComputerStoreWebApi.Data;

namespace ComputerStoreWebApi.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationbuilder)
        {
            using(var serviceScope= applicationbuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
                if(!context.Admin.Any())
                {
                    context.Admin.Add(new Admin()
                    {

                    });
                        

                    
                }
            }
        }
    }
}
