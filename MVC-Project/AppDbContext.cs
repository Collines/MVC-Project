using Microsoft.EntityFrameworkCore;
using MVC_Project.Models.Cart;
using MVC_Project.Models.Identity;
using MVC_Project.Models.Wishlist;
using shopping.Models;

namespace MVC_Project
{
    public class AppDBContext : DbContext
    {
        public AppDBContext()
        {

        }
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=Shop-DB;Integrated Security=True;Pooling=False;Encrypt=True;TrustServerCertificate=True");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Account>().HasIndex(A => A.Email).IsUnique();
            modelBuilder
                            .Entity<Account>().HasIndex(A => A.Email).IsUnique();
            modelBuilder
                .Entity<Product>().HasMany(P => P.Images).WithOne(A => A.Product)
                .OnDelete(DeleteBehavior.ClientCascade);
            //modelBuilder
            //    .Entity<Product>().Property(P => P.SKU)
            //    .HasComputedColumnSql("CONCAT(ProductId,'-',Subcategoryid,'-',Brandid)", stored: true);
            modelBuilder.Entity<Wishlist>().HasQueryFilter(C => C.IsActive == true);
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Subcategory> Subcategories { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Wishlist> Wishlists { get; set; }
        public DbSet<Wishlistitem> Wishlistitems { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
    }
}
