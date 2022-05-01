namespace ComputerStoreWebApi.Data.Model
{
    public class Address
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public int AddressType { get; set; }
        public string street { get; set; } = default!;
        public string city { get; set; } = default!;
        public string State { get; set; } = default!;
        public string Country { get; set; } = default!;
        public string LandMark { get; set; } = default!;
        public int PostalCode { get; set; }
        public int PhoneNumber { get; set; }

    }
}