using Microsoft.EntityFrameworkCore;

namespace shopping.Models
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

        public DbSet<Category> Categories { get; set; }
        public DbSet<Subcategory> Subcategories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
