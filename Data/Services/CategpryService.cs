using ComputerStoreWebApi.Data.Model;
using ComputerStoreWebApi.Data.ViewModel;

namespace ComputerStoreWebApi.Data.Services
{
    public class CategpryService
    {
        private AppDbContext _context;
        public CategpryService(AppDbContext context)
        {
            _context = context;
        }
        public void AddCategory(CategoryVM categpry)
        {
            var _category = new Category()
            {
                Name = categpry.Name,
                CreatedAt = DateTime.Now,
            };
            _context.Category.Add(_category);
            _context.SaveChanges();
        }

        public List<Category> GetCategoryList() => _context.Category.ToList();
        public Category GetCategoryById(int CategoryId) => _context.Category.FirstOrDefault(n => n.Id == CategoryId);
        
    }
}
