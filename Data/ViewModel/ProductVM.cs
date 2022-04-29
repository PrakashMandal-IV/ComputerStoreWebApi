namespace ComputerStoreWebApi.Data.ViewModel
{
    public class ProductVM
    {       
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
        public decimal NewPrice { get; set; }
        public int InStock { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<int> CategoryId { get; set; }
    }
}
