namespace ComputerStoreWebApi.Data.Services
{
    public class ProductService
    {
        private readonly AppDbContext _context;
        public ProductService(AppDbContext context)
        {
            _context = context;
        }
        //Add product to the store
        public void AddProduct(ProductVM product,string email)
        {
            var _admin = _context.Admin.FirstOrDefault(n =>n.Email == email);
            var _product = new Product()
            {
                Name = product.Name,
                Description = product.Description,
                ImageUrl = product.ImageUrl,
                Price = product.Price,
                NewPrice = product.NewPrice,
                Creator = _admin = default!,
                InStock = product.InStock,                
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

        //update product
        public Product? UpdateProductName(int id ,ProductVMbyName product)
        {
            var _product = _context.Product.FirstOrDefault(t => t.Id == id);
            if(_product != null)
            {
                _product.Name = product.Name;
                _product.ModifiedAt = DateTime.Now;
                _context.SaveChanges();
            };
            return _product;           
        }
        public Product? UpdateProductDescription(int id, ProductVMbyDescription product)
        {
            var _product = _context.Product.FirstOrDefault(t => t.Id == id);
            if (_product != null)
            {
                _product.Description = product.Discription;
                _product.ModifiedAt = DateTime.Now; 
                _context.SaveChanges();
            };
            return _product;
        }
        public Product? UpdateProductImage(int id, ProductVMImage product)
        {
            var _product = _context.Product.FirstOrDefault(t => t.Id == id);
            if (_product != null)
            {
                _product.ImageUrl = product.ImageUrl;
                _product.ModifiedAt = DateTime.Now;
                _context.SaveChanges();
            };
            return _product;
        }
        public Product? UpdateProductPrice(int id, ProductVMPrice product)
        {
            var _product = _context.Product.FirstOrDefault(t => t.Id == id);
            if (_product != null)
            {
                _product.NewPrice = product.NewPrice;
                _product.ModifiedAt = DateTime.Now;
                _context.SaveChanges();
            };
            return _product;
        }
        public Product? UpdateProductStock(int id,ProductVMStock product)
        {
            var _product = _context.Product.FirstOrDefault(t => t.Id == id);
            if(_product != null)
            {
                _product.InStock = product.Instock;
                _product.ModifiedAt= DateTime.Now;
                _context.SaveChanges();                         
            }
            return _product;
        }
    }
}
