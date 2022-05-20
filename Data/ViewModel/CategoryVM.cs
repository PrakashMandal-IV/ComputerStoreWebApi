namespace ComputerStoreWebApi.Data.ViewModel
{
    public class CategoryVM
    {
        public string  Name { get; set; } = string.Empty;       
    }
    public class CategoryWithProductVM
    {
        public string Name { get; set; } = string.Empty;
        public List<ListProductVM> Product { get; set; } = default!;
        public List<CategoryVM> Category { get; set; } = default!;
    }
}
