using ComputerStoreWebApi.Data.Model;
using ComputerStoreWebApi.Data.ViewModel;

namespace ComputerStoreWebApi.Data.Services
{
    public class TagService
    {
        public AppDbContext _context { get; set; }
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
        public Tag GetTagByName(string name) => _context.Tag.FirstOrDefault(t => t.Name == name);

    }
}
