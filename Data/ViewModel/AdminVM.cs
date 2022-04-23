namespace ComputerStoreWebApi.Data.ViewModel
{
    public class AdminVM
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string Email { get; set; }
        public string? ImageUrl { get; set; }
        public long PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
