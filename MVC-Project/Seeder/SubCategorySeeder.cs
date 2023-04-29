using shopping.Models;

namespace MVC_Project.Seeder
{
    public static class SubCategorySeeder
    {
        public static List<Subcategory> Seed()
        {
            var subcategories = new List<Subcategory>
            {
                // Electronics
                new Subcategory { SubCategoryName = "Car & Vehicle Electronics", CategoryId = 1 },
                new Subcategory { SubCategoryName = "Headphones", CategoryId = 1 },

                // Computers
                new Subcategory { SubCategoryName = "Computers & Tablets", CategoryId = 2 },
                new Subcategory { SubCategoryName = "Data Storage", CategoryId = 2 },

                // Home & Kitchen
                new Subcategory { SubCategoryName = "Kitchen & Dining", CategoryId = 3 },
                new Subcategory { SubCategoryName = "Furniture", CategoryId = 3 },
            };

            return subcategories;
        }
    }
}
