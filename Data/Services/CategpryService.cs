using ComputerStoreWebApi.Data.Model;
using ComputerStoreWebApi.Data.ViewModel;

namespace ComputerStoreWebApi.Data.Services
{
    public class CategpryService
    {
        private readonly AppDbContext _context;
        public CategpryService(AppDbContext context)
        {
            _context = context;
        }
        public void AddCategory(CategoryVM category)
        {
            var _category = new Category()
            {
                Name = category.Name,
                CreatedAt = DateTime.Now,
            };
            _context.Category.Add(_category);
            _context.SaveChanges();
        }

        public List<Category> GetCategoryList() => _context.Category.ToList();
        public Category? GetCategoryById(int CategoryId) => _context.Category.FirstOrDefault(n => n.Id == CategoryId);
        public Category? UpdateCategory(int categoryId, CategoryVM category)
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
                _context.Category.Remove(_category=default!);
                _context.SaveChanges();                 
        }
        public CategoryWithBooksVM GetProductByCategory(int CategoryId)
        {
            var _category = _context.Category.Where(n => n.Id == CategoryId).Select(n => new CategoryWithBooksVM()
            {
                Name = n.Name,
                Books = n.ProductCategory.Select(c => new CategoryBooksVM()
                {              
                    Name = c.Product.Name,
                    Description = c.Product.Description,
                    ImageUrl = c.Product.ImageUrl,
                    Price = c.Product.Price,
                    NewPrice = c.Product.NewPrice,

                   
                }).ToList(),
            }).FirstOrDefault();
            return _category;
        }

    }
}
