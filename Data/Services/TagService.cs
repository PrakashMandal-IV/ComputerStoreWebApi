using ComputerStoreWebApi.Data.Model;
using ComputerStoreWebApi.Data.ViewModel;

namespace ComputerStoreWebApi.Data.Services
{
    public class TagService
    {
#pragma warning disable IDE1006 // Naming Styles
        public AppDbContext _context { get; set; }
#pragma warning restore IDE1006 // Naming Styles
        public TagService(AppDbContext context)
        {
            _context = context;
        }

        public void AddTag(TagVM tag)
        {
            var _tag = new Tag()
            {
                Name = tag.Name,
                CreatedAt = DateTime.Now,
            };
            _context.Tag.Add(_tag);
            _context.SaveChanges();
        }
        public Tag? GetTagByName(string name) => _context.Tag.FirstOrDefault(t => t.Name == name);
        public TagProductVM? GetProductVM(string name)
        {
            var _tag = _context.Tag.Where(t => t.Name == name).Select(n => new TagProductVM()
            {
                Name =n.Name,
                Product = n.ProductTags.Select(c => new ListProductVM()
                {
                    Name = c.Product.Name,
                    Description = c.Product.Description,
                    ImageUrl = c.Product.ImageUrl,
                    Price = c.Product.Price,
                    NewPrice = c.Product.NewPrice,
                }).ToList()
            }).FirstOrDefault();
            return _tag;
        }
    }
}
