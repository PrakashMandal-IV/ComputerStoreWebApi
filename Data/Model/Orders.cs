namespace ComputerStoreWebApi.Data.Model
{
    public class Orders
    {
        public int Id { get; set; } 
        public int? ProductId { get; set; }
        public Product? Product { get; set; }     
        public bool Paid { get; set; }
        public int? AddressId { get; set; }
        public Address? Address { get; set; } //refrence
        public string Status { get; set; } = "pending";
        public int CreatorId { get; set; } 
        public User? Creator { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? ModifiedId { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public int? DeletedBy { get; set; }

        
        public List<UserOrder> UserOrders { get; set; } = default!;

    }
}
