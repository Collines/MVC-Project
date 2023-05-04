using shopping.Models;

namespace MVC_Project.Seeder
{
    public static class SubCategorySeeder
    {
        public static List<Subcategory> Seed()
        {
            var subcategories = new List<Subcategory>
            {
                // watches
                new Subcategory { SubCategoryName = "Watches", CategoryId = 1 },
                new Subcategory { SubCategoryName = "Sunglasses", CategoryId = 1 },
                new Subcategory { SubCategoryName = "Luggage and Travel Gear", CategoryId = 1 },
            };

            return subcategories;
        }
    }
}
