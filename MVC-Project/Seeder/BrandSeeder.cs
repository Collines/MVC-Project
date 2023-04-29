using shopping.Models;

namespace MVC_Project.Seeder
{
    public static class BrandSeeder
    {
        public static List<Brand> Seed()
        {
            var brands = new List<Brand>
            {
                // Electronics

                // Car & Vehicle Electronics
                new Brand { Name = "YZHIDIANF"},
                new Brand { Name = "Oxbot"},
                new Brand { Name = "REDTIGER"},

                // Headphones
                new Brand { Name = "Anker"},
                new Brand { Name = "JBL"},
                new Brand { Name = "Skullcandy"},

            };

            return brands;
        }
    }
}
