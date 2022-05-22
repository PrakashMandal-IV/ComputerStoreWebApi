namespace ComputerStoreWebApi.Data.ViewModel
{
    public class OrderVM
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public bool Paid { get; set; }
        public int AddressId { get; set; }
    }
    public class OrderStatus
    {
        public string Status { get; set; } = string.Empty;
    }
    public class OrderSubStatus
    {
        public string Substatus { get; set; } = string.Empty;
    }
    public class ShipmentNumber
    {
        public string ShipmentTrackingNumber { get; set; } = string.Empty;
    }
}
