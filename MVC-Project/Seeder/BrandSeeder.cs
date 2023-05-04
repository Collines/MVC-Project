using shopping.Models;

namespace MVC_Project.Seeder
{
    public static class BrandSeeder
    {
        public static List<Brand> Seed()
        {
            var brands = new List<Brand>
            {
                //watches
                new Brand { Name = "Bulova" }, //1
                new Brand { Name = "Casio" },  //2
                new Brand { Name = "Timex" },  //3

                //Sunglasses
                new Brand { Name = "Gucci" },   //4
                new Brand { Name = "Tom Ford" },  //5
                new Brand { Name = "GHANEL" },  //6


                // Luggage and Travel Gear
                new Brand { Name = "Dejavu" },  //7
                new Brand { Name = "Adidas" },  //8
                new Brand { Name = "Delsey" },   //9
            };

            return brands;
        }
    }
}
