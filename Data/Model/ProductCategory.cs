namespace ComputerStoreWebApi.Data.Model
{
    public class ProductCategory
    {
        public int Id { get; set; }
        
        public int ProductId { get; set; }
        public Product Product { get; set; } = default!;

        public int CategoryId { get; set; }
        public Category Category { get; set; } = default!;
    }
}
