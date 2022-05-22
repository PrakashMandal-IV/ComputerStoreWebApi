namespace ComputerStoreWebApi.Data.Model
{
    public class UserAddress
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public User User { get; set; } = default!;

        public int AddressId { get; set; }
        public Address Address { get; set; } = default!;
    }
}
