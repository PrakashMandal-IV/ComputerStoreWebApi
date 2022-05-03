namespace ComputerStoreWebApi.Data.ViewModel
{
    public class TagVM
    {
        public string Name { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
    }
    public class TagProductVM
    {
        public string Name { get; set; } = string.Empty;
        public List<ListProductVM> Product { get; set; } = default!;
    }
}
