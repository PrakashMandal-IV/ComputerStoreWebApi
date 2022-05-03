namespace ComputerStoreWebApi.Data.ViewModel
{
    public class CategoryVM
    {
        public string  Name { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
    }
    public class CategoryWithBooksVM
    {
        public string Name { get; set; } = string.Empty;
        public List<CategoryBooksVM> Books { get; set; } = default!;
    }
}
