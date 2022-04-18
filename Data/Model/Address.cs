namespace ComputerStoreBackEnd.Data.Model
{
    public class Address
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AddressType { get; set; }
        public string street { get; set; }
        public string city { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string LandMark { get; set; }
        public int PostalCode { get; set; }
        public int PhoneNumber { get; set; }

    }
}
