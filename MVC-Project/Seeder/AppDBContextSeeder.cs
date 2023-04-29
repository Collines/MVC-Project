namespace MVC_Project.Seeder
{
    public static class AppDBContextSeeder
    {
        public static void SeedData(AppDBContext db)
        {
            if (!db.Categories.Any())
            {
                db.Categories.AddRange(CategorySeeder.Seed());
                db.SaveChanges();
            }

            if (!db.Subcategories.Any())
            {
                db.Subcategories.AddRange(SubCategorySeeder.Seed());
                db.SaveChanges();
            }

            if (!db.Brands.Any())
            {
                db.Brands.AddRange(BrandSeeder.Seed());
                db.SaveChanges();
            }

            if (!db.Products.Any())
            {
                db.Products.AddRange(ProductSeeder.Seed());
                db.SaveChanges();
            }

            if (!db.Images.Any())
            {
                db.Images.AddRange(ImageSeeder.Seed());
                db.SaveChanges();
            }
        }
    }
}
