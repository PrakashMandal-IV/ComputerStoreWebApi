namespace ComputerStoreWebApi.Data.ViewModel
{
    public class ProductVM
    {       
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public int Price { get; set; }
        public int NewPrice { get; set; }
        public int InStock { get; set; }
        public int? CreatorId { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<int> CategoryId { get; set; } = default!;
        public List<string> TagName { get; set; } = default!;
    }
    public class ProductVMbyName
    {
        public string Name { get; set; } = string.Empty;      
    }
    public class ProductVMbyDescription
    {
        public string Discription { get; set; } = string.Empty;        
    }
    public class ProductVMImage
    {
        public string ImageUrl { get; set; } = string.Empty;
    }
    public class ProductVMPrice
    {
        public int NewPrice { get; set; }
    }
    public class ProductVMStock
    {
        public int Instock { get; set; }
    }
    public class ListProductVM
    {      
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public int Price { get; set; }  
        public int NewPrice { get; set; }
       
    }
}
