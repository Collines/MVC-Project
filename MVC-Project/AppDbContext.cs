using Microsoft.EntityFrameworkCore;
using MVC_Project.Models.Identity;
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
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-VREBPAN\\MSSQLSERVER17;Initial Catalog=Shop-DB;Integrated Security=True;Pooling=False;Encrypt=True;TrustServerCertificate=True");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>().HasIndex(A => A.Email).IsUnique();
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Subcategory> Subcategories { get; set; }
        public DbSet<Product> Products { get; set; }

        public DbSet<Account> Accounts { get; set; }
    }
}
