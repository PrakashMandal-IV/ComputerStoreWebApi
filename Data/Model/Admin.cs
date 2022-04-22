namespace ComputerStoreWebApi.Controllers
{
    public class Admin
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string Email { get; set; }
        public string? ImageUrl { get; set; }
        public int PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }    
    }
}
