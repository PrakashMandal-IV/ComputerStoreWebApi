namespace ComputerStoreWebApi.Data.ViewModel
{
    public class OrderVM
    {   
        public int ProductId { get; set; }
        public bool Paid { get; set; }      
    }
    public class OrderStatus
    {
        public string Status { get; set; } =string.Empty;
    }
}
