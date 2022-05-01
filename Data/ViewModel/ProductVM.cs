namespace ComputerStoreWebApi.Data.ViewModel
{
    public class ProductVM
    {       
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public int Price { get; set; }
        public int NewPrice { get; set; }
        public int InStock { get; set; }
        public int? CreatorId { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<int> CategoryId { get; set; }
        public List<int> TagId { get; set; }
    }
}
