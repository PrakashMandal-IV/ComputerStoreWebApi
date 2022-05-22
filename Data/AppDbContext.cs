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
                .WithMany(c => c.ProductCategory)
                .HasForeignKey(i => i.CategoryId);
            modelBuilder.Entity<ProductTag>()
                .HasOne(p => p.Tag)
                .WithMany(c => c.ProductTags)
                .HasForeignKey(i => i.TagId);
            modelBuilder.Entity<ProductTag>()
                .HasOne(p => p.Product)
                .WithMany(c => c.ProductTags)
                .HasForeignKey(i => i.ProductId);
           modelBuilder.Entity<UserOrder>()
                .HasOne(p => p.User)
                .WithMany(c => c.UserOrder)
                .OnDelete(DeleteBehavior.Cascade)
                .HasForeignKey(i => i.UserId);
                
            modelBuilder.Entity<UserOrder>()
                .HasOne(p => p.Order)
                .WithMany(c =>c.UserOrders)
                .OnDelete(DeleteBehavior.Cascade)
                .HasForeignKey(i => i.OrderId);
            modelBuilder.Entity<UserAddress>()
                .HasOne(p => p.User)
                .WithMany(c => c.UserAddresses)
                .HasForeignKey(i => i.UserId);
            modelBuilder.Entity<UserAddress>()
                .HasOne(p => p.Address)
                .WithMany(p => p.UserAddresses)
                .HasForeignKey(i => i.AddressId);
        }
        public DbSet<Admin> Admin { get; set; } = default!;
        public DbSet<Category> Category { get; set; } = default!;
        public DbSet<Tag> Tag { get; set; } = default!;
        public DbSet<Product> Product { get; set; } = default!;
        public DbSet<ProductCategory> ProductCategory { get; set; } = default!;
        public DbSet<ProductTag>   ProductTags { get; set; } = default!;

        public DbSet<User> User { get; set; } = default!;
        public DbSet<Orders> Orders { get; set; } = default!;
        public DbSet<UserOrder> UserOrder { get; set; } = default!;

        //address
        public DbSet<Address> Address { get; set; } = default!;
        public DbSet<UserAddress> UserAddresses { get; set; } = default!;
    }
}
