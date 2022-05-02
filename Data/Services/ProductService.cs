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
                CreatorId = product.CreatorId,
                CreatedAt = DateTime.Now,              
            };
            _context.Product.Add(_product);
            _context.SaveChanges();
            foreach(var id in product.CategoryId)
            {
                var _productCategory = new ProductCategory()
                {
                    ProductId = _product.Id,
                    CategoryId = id,
                };
                _context.ProductCategory.Add(_productCategory);
                _context.SaveChanges();
            }
             foreach(var name in product.TagName)
            {
                var _tag = _context.Tag.FirstOrDefault(t => t.Name == name);
                if (_tag ==null)
                {
                    var newtag = new Tag()
                    {
                        Name = name,
                        CreatedAt = DateTime.Now,
                    };
                    _context.Tag.Add(newtag);
                    _context.SaveChanges();
                    var productTag = new ProductTag()
                    {
                        ProductId = _product.Id,
                        TagId = newtag.Id,
                    };
                    _context.ProductTags.Add(productTag);
                    _context.SaveChanges();
                }
                else
                {
                    var productTag = new ProductTag()
                    {
                        ProductId = _product.Id,
                        TagId = _tag.Id,
                    };
                    _context.ProductTags.Add(productTag);
                    _context.SaveChanges();
                }
            }



        }
    }
}
