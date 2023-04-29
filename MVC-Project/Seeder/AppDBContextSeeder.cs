using Bogus;
using shopping.Models;

namespace MVC_Project.Seeder
{
    public static class AppDBContextSeeder
    {
        public static void SeedData(AppDBContext db, bool isDynamicSeeding = false)
        {
            if (isDynamicSeeding)
            {
                if (!db.Categories.Any())
                {
                    var faker = new Faker<Category>()
                        .RuleFor(c => c.CategoryName, f => f.Lorem.Word());

                    db.Categories.AddRange(faker.Generate(10));
                    db.SaveChanges();
                }

                if (!db.Subcategories.Any())
                {
                    var counter = 1;
                    var faker = new Faker<Subcategory>()
                        .RuleFor(s => s.SubCategoryName, f => f.Lorem.Word())
                        .RuleFor(s => s.CategoryId, f => ((counter++ - 1) % 10) + 1);

                    var subcategories = faker.Generate(20);

                    db.Subcategories.AddRange(subcategories);
                    db.SaveChanges();
                }

                if (!db.Brands.Any())
                {
                    var faker = new Faker<Brand>()
                        .RuleFor(b => b.Name, f => f.Lorem.Word());

                    db.Brands.AddRange(faker.Generate(20));
                    db.SaveChanges();
                }

                if (!db.Products.Any())
                {
                    var brandsCounter = 1;
                    var subCategoryCounter = 1;
                    var faker = new Faker<Product>()
                        .RuleFor(p => p.ProductName, f => f.Lorem.Word())
                        .RuleFor(p => p.Description, f => f.Lorem.Paragraph())
                        .RuleFor(p => p.Price, f => f.Random.Number(50, 10_000))
                        .RuleFor(p => p.Quantity, f => f.Random.Number(1, 99))
                        .RuleFor(p => p.IsAvailable, f => true)
                        .RuleFor(p => p.BrandID, f => ((brandsCounter++ - 1) % 20) + 1)
                        .RuleFor(p => p.SubCategoryId, f => ((subCategoryCounter++ - 1) % 20) + 1);

                    var products = faker.Generate(100);

                    db.Products.AddRange(products);
                    db.SaveChanges();
                }

                if (!db.Images.Any())
                {
                    var counter = 1;
                    var faker = new Faker<Image>()
                        .RuleFor(i => i.Title, f => f.Lorem.Word())
                        .RuleFor(i => i.ImageData, GenerateRandomImage)
                        .RuleFor(i => i.ProductId, f => ((counter++ - 1) % 100) + 1);

                    var images = faker.Generate(200);

                    db.Images.AddRange(images);
                    db.SaveChanges();
                }
            }
            else
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

        public static byte[] GenerateRandomImage(Faker faker)
        {
            var imageUrl = faker.Image.LoremFlickrUrl(width: 640, height: 480);

            byte[] imageData;
            using (var httpClient = new HttpClient())
            {
                imageData = httpClient.GetByteArrayAsync(imageUrl).Result;
            }

            return imageData;
        }
    }
}
