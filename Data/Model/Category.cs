namespace ComputerStoreWebApi.Data.Model
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int? CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedAt { get; set; }       
        public int? DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }
        [NotMapped]
        public List<ProductCategory> ProductCategory { get; set; } = default!;
    }
}
