namespace ComputerStoreWebApi.Data.ViewModel
{
    public class AddressVM
    {

        public string Name { get; set; } = string.Empty;
        public bool AddressType { get; set; }
        public string Street { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string LandMark { get; set; } = string.Empty;
        public int PostalCode { get; set; }
        public long PhoneNumber { get; set; }
    }

    public class AddressByUserVM
    {
        public List<ListAddress> AddressList { get; set; } = default!;
    }
    public class ListAddress
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
    }
}
