using System.ComponentModel.DataAnnotations.Schema;

namespace ComputerStoreWebApi.Data.Model
{
    public class Product
    {
       
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public Decimal? Price { get; set; }
        public decimal? NewPrice { get; set; }
        public int InStock { get; set; }
        public int tagId { get; set; }
        public int CategoryId { get; set; }        
        public DateTime CreatedBy { get; set; }
        public int? CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime DeletedAt { get; set; }
        public int DeletedBy { get; set; }
    }
}
