

using ComputerStoreWebApi.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace ComputerStoreWebApi.Data
{
    public class AppDbContext:DbContext
    {
       public AppDbContext(DbContextOptions options):base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductCategory>()
                .HasOne(p => p.Product)
                .WithMany(c => c.ProductCategory)
                .HasForeignKey(i => i.ProductId);
            modelBuilder.Entity<ProductCategory>()
                .HasOne(p => p.Category)
                .WithMany(c => c.productCategory)
                .HasForeignKey(i => i.CategoryId); 
            modelBuilder.Entity<ProductTag>()
                .HasOne(p => p.Tag)
                .WithMany(c => c.ProductTags)
                .HasForeignKey(i => i.TagId);
            modelBuilder.Entity<ProductTag>()
                .HasOne(p => p.Product)
                .WithMany(c => c.ProductTags)
                .HasForeignKey(i => i.ProductId);
        }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Tag> Tag { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductCategory> ProductCategory { get; set; }
        public DbSet<ProductTag>   ProductTags { get; set; }
    }
}
