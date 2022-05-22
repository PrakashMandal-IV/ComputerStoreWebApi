namespace ComputerStoreWebApi.Data.Model
{
    public class Address
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool AddressType { get; set; }
        public string Street { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string LandMark { get; set; } = string.Empty;
        public int PostalCode { get; set; }
        public long PhoneNumber { get; set; }

        [NotMapped]
        public List<UserAddress> UserAddresses { get; set; } = default!;
    }
}