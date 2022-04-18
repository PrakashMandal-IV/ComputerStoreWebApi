namespace ComputerStoreBackEnd.Data.Model
{
    public class Orders
    {
        public int Id { get; set; } 
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public int ModeOfPayment { get; set; }
        public int IsCompleted { get; set; }
        public int? IsReturned { get; set; }
        public int? IsRefunded { get; set; }
        public DateTime CreatedBy { get; set; }
        public int? CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime DeletedAt { get; set; }
        public int DeletedBy { get; set; }

    }
}
