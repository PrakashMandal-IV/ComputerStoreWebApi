namespace ComputerStoreWebApi.Data.ViewModel
{
    public class AdminVM
    {      
        public string Password { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public long PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
    public class AdminLoginVM
    {
        public string Email { get; set;} = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
