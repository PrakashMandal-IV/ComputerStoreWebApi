using ComputerStoreWebApi.Data.Model;
using ComputerStoreWebApi.Data.ViewModel;

namespace ComputerStoreWebApi.Data.Services
{
    public class ProductService
    {
        private AppDbContext _context;
        public ProductService(AppDbContext context)
        {
            _context = context;
        }

        public void AddProduct(ProductVM product)
        {
            var _product = new Product()
            {
                Name = product.Name,
                Description = product.Description,
                ImageUrl = product.ImageUrl,
                Price = product.Price,
                NewPrice = product.NewPrice,
                InStock = product.InStock,
                CreatedBy = product.CreatedBy,
                CreatedAt = DateTime.Now,              
            };
            _context.Product.Add(_product);
            _context.SaveChanges();
            foreach(var id in product.CategoryId)
            {
                var _productCategory = new ProductCategory()
                {
                    ProductId = id, 
                    CategoryId = id,
                };
                _context.ProductCategory.Add(_productCategory);
                _context.SaveChanges();
            }
             foreach(var id in product.TagId)
            {
                var productTag = new ProductTag()
                {
                    ProductId = id,
                    TagId = id,
                };
                _context.ProductTags.Add(productTag);
                _context.SaveChanges();
            }



        }
    }
}
