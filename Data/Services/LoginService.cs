using ComputerStoreWebApi.Hash;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ComputerStoreWebApi.Data.Services
{
    public class LoginService
    {
        private readonly HashPass hash = new();
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;
        public LoginService(AppDbContext context,IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
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
                return "Not Found";
            }
            else if(hash.Hash(_adminlogin.Password)==_admin.Password)
            {
                string token = CreateAdminToken(_admin);
                return token;
            }
            else return "Invalid Detail";
        }
        public string? UserLogin(UserLoginVM user)
        {
            var _userLogin = new UserLoginVM()
            {
                Email = user.Email,
                Password = user.Password,
            };
            var _user = _context.User?.FirstOrDefault(n => n.Email == _userLogin.Email);
            {
                if (_user == null)
                {
                    return "not found";
                }
                else if (hash.Hash(_userLogin.Password) == _user.Password)
                {
                    string token = CreateUserToken(_user);
                    return token;
                }
                else return "Invalid Detail";
            }
                
        }
        // create jwt token
        public string CreateAdminToken(Admin admin)
        {
            List<Claim> claims = new()
            {
                new Claim(ClaimTypes.Email ,admin.Email),
                new Claim(ClaimTypes.Role ,"Admin")
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            var token = new JwtSecurityToken(
                claims :claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);
            var jwt =  new JwtSecurityTokenHandler().WriteToken(token);
                
            return jwt;
        }
        public string CreateUserToken(User user)
        {
            List<Claim> claims = new()
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, "user")
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
    }
}
