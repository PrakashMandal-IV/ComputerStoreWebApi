namespace ComputerStoreWebApi.Data.Model
{
    public class ProductTag
    {
        public int Id { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; } = default!;
         
        public int TagId { get; set; }
        public Tag Tag { get; set; } =default!;
        
    }
}
