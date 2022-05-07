namespace ComputerStoreWebApi.Data.Model
{
    public class UserOrder
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public User User { get; set; } = default!;

        public int OrderId { get; set; }
        public Orders Order { get; set; } = default!;    
    }
}
