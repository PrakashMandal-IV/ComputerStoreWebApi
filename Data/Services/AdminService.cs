using ComputerStoreWebApi.Data.Models;
using ComputerStoreWebApi.Data.ViewModel;

namespace ComputerStoreWebApi.Data.Services
{
    public class AdminService
    {
        private AppDbContext _context;
        public AdminService(AppDbContext context)
        {
            _context = context;
        }
         
        public void AddAdmin(AdminVM admin)
        {
            var _admin = new Admin()
            {
                UserName = admin.UserName,
                Password = admin.Password,
                FirstName = admin.FirstName,
                LastName = admin.LastName,
                Email = admin.Email,
                ImageUrl = admin.ImageUrl,
                PhoneNumber = admin.PhoneNumber,
                DateOfBirth = DateTime.Now
            };
            _context.Admin.Add(_admin);
            _context.SaveChanges(); 
        }

        public List<Admin> GetAdminList() => _context.Admin.ToList();

        public Admin GetAdminById(int AdminId) => _context.Admin.FirstOrDefault(n => n.Id == AdminId);
    }
}
