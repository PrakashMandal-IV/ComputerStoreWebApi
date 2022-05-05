namespace ComputerStoreWebApi.Data.Model
{
    public class Admin
    {
        public int Id { get; set; }         
        public string Password { get; set; } = string.Empty;
        public string? FirstName { get; set; } 
        public string? LastName { get; set; }
        public string Email { get; set; } = string.Empty;
        public string? ImageUrl { get; set; }
        public long PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }

        [NotMapped]
        public List<Product> Products { get; set; } = default!;
    }
}
