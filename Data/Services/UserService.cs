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
                _user.CreatedBy = _user.Id;
                _user.CreatedAt = DateTime.Now;
                _context.SaveChanges();
                return true;             
            }
            else return false;
        }
        public bool AddUserAddress(AddressVM address,string email)
        {
            var _user = _context.User.FirstOrDefault(x => x.Email == email);
            if(_user == null)
            {
                return false;
            }
            else
            {
                var _address = new Address()
                {
                    Name = address.Name,
                    AddressType = address.AddressType,
                    Street = address.Street,
                    City = address.City,
                    State = address.State,
                    Country = address.Country,
                    LandMark = address.LandMark,
                    PostalCode = address.PostalCode,
                    PhoneNumber = address.PhoneNumber,
                };
                _context.Address.Add(_address);
                _context.SaveChanges();
                var _userAddress = new UserAddress()
                {
                    UserId = _user.Id,
                    AddressId = _address.Id,
                };
                _context.UserAddresses.Add(_userAddress);
                _context.SaveChanges();
                return true;
            }   
        }

        public AddressByUserVM GetUserAddress(string email)
        {
            var _address = _context.User.Where(n => n.Email == email).Select(n => new AddressByUserVM
            {
                AddressList = n.UserAddresses.Select(c => new ListAddress
                {
                    Id = c.Address.Id,
                    Name = c.Address.Name,
                    Street = c.Address.Street,
                    State = c.Address.State,
                    City = c.Address.City,
                    PostalCode = c.Address.PostalCode,
                    PhoneNumber = c.Address.PhoneNumber,
                }).ToList(),
            }).FirstOrDefault();
            if(_address != null)
            {
                return _address;
            }
            return null;
            
        }

        public UserVM GetUserDetail(string email)
        {
            var _user = _context.User.FirstOrDefault(n => n.Email == email);
            if (_user != null)
            {
                var _newUser = new UserVM()
                {
                    FirstName = _user.FirstName,
                    LastName = _user.LastName,
                    Email = email,
                    PhoneNumber = _user.PhoneNumber,
                    Gender = _user.Gender,
                    DateOfBirth = _user.DateOfBirth,
                };
                return _newUser;
            }
            else return null;
        }
        public List<GetOrder> GetUserOrder(string email)
        {
            var _user = _context.User.FirstOrDefault(n => n.Email == email);
            var _userOrder = _context.UserOrder.Where(n => n.UserId == _user.Id).Select(n => new GetOrder()
            {
                Id = n.Order.Id,
                ProductId = n.Order.ProductId,
                Quantity = n.Order.Quantity,
                AddressId = n.Order.AddressId,
            }).ToList();
            return _userOrder;
            
          
        }
    }
}
