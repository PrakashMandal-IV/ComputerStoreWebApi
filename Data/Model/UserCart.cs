namespace ComputerStoreWebApi.Data.Model
{
    public class UserCart
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int CartId { get; set; }
        public Cart Cart { get; set; }


    }
}
