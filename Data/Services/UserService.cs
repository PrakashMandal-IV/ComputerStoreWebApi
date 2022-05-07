using ComputerStoreWebApi.Hash;

namespace ComputerStoreWebApi.Data.Services
{
    public class UserService
    {
        private readonly HashPass hash = new();
        private AppDbContext _context;
        public UserService(AppDbContext context)
        {
            _context = context;
        }

        public bool RegisterUser(UserVM user)
        {
            var existingUser = _context.User.FirstOrDefault(x => x.Email == user.Email);
            if (existingUser == null)
            {
                string pass = hash.Hash(user.Password);
                var _user = new User()
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    Password = pass,
                    PhoneNumber = user.PhoneNumber,
                    DateOfBirth = user.DateOfBirth,
                    Gender = user.Gender,
                };
                _context.User.Add(_user);
                 var currentuser =_context.User.FirstOrDefault(n => n.Email == user.Email);
                _user.CreatedBy = currentuser.Id;
                _user.CreatedAt = DateTime.Now;
                _context.SaveChanges();
                return true;             
            }
            else return false;
        }
    }
}
