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
        public Category UpdateCategory(int categoryId, CategoryVM category)
        {
            var _category = _context.Category.FirstOrDefault(n => n.Id == categoryId);
            if (_category != null)
            {
                _category.Name = category.Name;
                _category.ModifiedAt = DateTime.Now;
                _context.SaveChanges();
            }
            return _category;
        }
        public void DeleteCategory(int Id)
        {
            var _category =  _context.Category.FirstOrDefault(n =>n.Id == Id);      
                _context.Category.Remove(_category);
                _context.SaveChanges();                 
        }
        
    }
}
