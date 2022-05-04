using ComputerStoreWebApi.Data.ViewModel;
using ComputerStoreWebApi.Hash;

namespace ComputerStoreWebApi.Data.Services
{
    public class LoginService
    {
        private readonly HashPass hash = new();
        private readonly AppDbContext _context;
        public LoginService(AppDbContext context)
        {
            _context = context;
        }
        public string? AdminLogin(AdminLoginVM adminLoginVM)
        {
            var _adminlogin = new AdminLoginVM()
            {
                Email = adminLoginVM.Email,
                Password = adminLoginVM.Password,
                
            };
            var _admin = _context.Admin.FirstOrDefault(n => n.Email == _adminlogin.Email);
            if (_admin == null)
            {
                return null;
            }
            else if(hash.Hash(_adminlogin.Password)==_admin.Password)
            {
                int id = _admin.Id;
                return id.ToString();
            }
            
            return "Invalid Detail";


        }
    }
}
