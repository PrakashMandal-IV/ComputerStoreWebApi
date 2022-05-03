using System.ComponentModel.DataAnnotations.Schema;

namespace ComputerStoreWebApi.Data.Model
{
    public class Product
    {
       
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public int Price { get; set; }
        public int NewPrice { get; set; }
        public int InStock { get; set; }            
        public int? CreatorId { get; set; }
        public Admin Creator { get; set; } = default!;
        public DateTime? CreatedAt { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }

        public List<ProductCategory> ProductCategory { get; set; } =default!;
        public List<ProductTag> ProductTags { get; set; } =default!;
    }
}
