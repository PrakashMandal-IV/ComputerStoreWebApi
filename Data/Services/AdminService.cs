using ComputerStoreWebApi.Hash;

namespace ComputerStoreWebApi.Data.Services
{
    public class AdminService
    {      
        private readonly HashPass hash = new();
        private readonly AppDbContext _context;
        public AdminService(AppDbContext context)
        {
            _context = context;        
        }
         
        public bool AddAdmin(AdminVM admin,string email)
        {
            var _creator =_context.Admin.FirstOrDefault(n => n.Email == email);
            var _existingemail = _context.Admin.FirstOrDefault(n => n.Email == admin.Email);
            var _existingnumber = _context.Admin.FirstOrDefault(n => n.PhoneNumber == admin.PhoneNumber);
            if (_existingemail != null || _existingnumber !=null)
            {
                return false;
            }
            else
            {
                string pass = hash.Hash(admin.Password);
                var _admin = new Admin()
                {
                    Password = pass,
                    FirstName = admin.FirstName,
                    LastName = admin.LastName,
                    Email = admin.Email,
                    ImageUrl = admin.ImageUrl,
                    PhoneNumber = admin.PhoneNumber,
                    DateOfBirth = DateTime.Now
                };
                _context.Admin.Add(_admin);
                _admin.CreatedBy = _creator?.Id;
                _admin.CreatedAt = DateTime.Now;            
                _context.SaveChanges();
                return true;
            }          
        }

        public List<Admin> GetAdminList() => _context.Admin.ToList();

        public Admin? GetAdminById(int AdminId) => _context.Admin.FirstOrDefault(n => n.Id == AdminId);

        public Admin? UpdateAdminById(int adminId, AdminVM admin )
        {
            var _admin = _context.Admin.FirstOrDefault(n => n.Id == adminId);
            string pass = hash.Hash(admin.Password);
            if (_admin != null)
            {             
                _admin.Password = pass;
                _admin.FirstName = admin.FirstName;
                _admin.LastName = admin.LastName;
                _admin.Email = admin.Email;
                _admin.ImageUrl = admin.ImageUrl;
                _admin.PhoneNumber = admin.PhoneNumber;
                _admin.DateOfBirth = DateTime.Now;
                _context.SaveChanges();
            };
            return _admin;
        }
        public void DeleteAdminById(int adminId)
        {
            var admin = _context.Admin.FirstOrDefault(n => n.Id == adminId);
            _context.Admin.Remove(admin=default!);
            _context.SaveChanges();
        }
    }
}
