namespace ComputerStoreWebApi.Data.Model
{
    public class Address
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int AddressType { get; set; }
        public string Street { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string LandMark { get; set; } = string.Empty;
        public int PostalCode { get; set; }
        public int PhoneNumber { get; set; }

        public List<UserAddress> UserAddresses { get; set; } = default!;
    }
}