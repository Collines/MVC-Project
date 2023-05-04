using shopping.Models;

namespace MVC_Project.Seeder
{
    public static class CategorySeeder
    {
        public static List<Category> Seed()
        {
            var categories = new List<Category>
            {
                new Category { CategoryName = "Fashion" },
            };

            return categories;
        }
    }

}
