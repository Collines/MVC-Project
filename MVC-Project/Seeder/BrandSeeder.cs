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

                //Smart Phones
                new Brand { Name = "OPPO"},
                new Brand { Name = "Samsung"},                
                new Brand { Name = "Infinix"},

                //Tablets
                new Brand { Name = "Lenovo"},
                new Brand { Name = "Huawei"},                
                new Brand { Name = "Nokia"},

                //Smart Watches
                new Brand { Name = "Apple"},                
                new Brand { Name = "Amazfit"},                
                new Brand { Name = "Bml"},




            };

            return brands;
        }
    }
}
