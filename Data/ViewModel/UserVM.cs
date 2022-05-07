namespace ComputerStoreWebApi.Data.ViewModel
{
    public class UserVM
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public long PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; } = string.Empty;
    }
    public class UserLoginVM
    {
        public string Email { get; set; } = string.Empty ;
        public string Password { get; set; } = string.Empty ;
    }
}
