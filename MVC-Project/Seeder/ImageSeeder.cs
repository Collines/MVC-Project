using shopping.Models;

namespace MVC_Project.Seeder
{
    public static class ImageSeeder
    {
        public static List<Image> Seed()
        {
            var images = new List<Image>
            {
                // Watches
                 new Image
                {
                    Title = "Image 1",
                    ImageData = File.ReadAllBytes("wwwroot/products_images/B1.jpg"),
                    ProductId = 1
                },
                 new Image
                {
                    Title = "Image 1",
                    ImageData = File.ReadAllBytes("wwwroot/products_images/B2.jpg"),
                    ProductId = 2
                },
                     new Image
                {
                    Title = "Image 1",
                    ImageData = File.ReadAllBytes("wwwroot/products_images/B3.jpg"),
                    ProductId = 3
                },
                  new Image
                {
                    Title = "Image 1",
                    ImageData = File.ReadAllBytes("wwwroot/products_images/B4.jpg"),
                    ProductId = 4
                },
                   new Image
                {
                    Title = "Image 1",
                    ImageData = File.ReadAllBytes("wwwroot/products_images/B5.jpg"),
                    ProductId = 5
                },
                    new Image
                {
                    Title = "Image 1",
                    ImageData = File.ReadAllBytes("wwwroot/products_images/B6.jpg"),
                    ProductId = 6
                },
                     new Image
                {
                    Title = "Image 1",
                    ImageData = File.ReadAllBytes("wwwroot/products_images/B7.png"),
                    ProductId = 7
                },
                      new Image
                {
                    Title = "Image 1",
                    ImageData = File.ReadAllBytes("wwwroot/products_images/B8.jpg"),
                    ProductId = 8
                },
                       new Image
                {
                    Title = "Image 1",
                    ImageData = File.ReadAllBytes("wwwroot/products_images/B9.jpg"),
                    ProductId = 9
                },


                // Sunglasses
                new Image
                {
                    Title = "Image 1",
                    ImageData = File.ReadAllBytes("wwwroot/products_images/S1.jpg"),
                    ProductId = 10
                },
                 new Image
                {
                    Title = "Image 1",
                    ImageData = File.ReadAllBytes("wwwroot/products_images/S2.jpg"),
                    ProductId = 11
                },
                     new Image
                {
                    Title = "Image 1",
                    ImageData = File.ReadAllBytes("wwwroot/products_images/S3.jpg"),
                    ProductId = 12
                },
                  new Image
                {
                    Title = "Image 1",
                    ImageData = File.ReadAllBytes("wwwroot/products_images/S4.png"),
                    ProductId = 13
                },
                   new Image
                {
                    Title = "Image 1",
                    ImageData = File.ReadAllBytes("wwwroot/products_images/S5.jpg"),
                    ProductId = 14
                },
                    new Image
                {
                    Title = "Image 1",
                    ImageData = File.ReadAllBytes("wwwroot/products_images/S6.jpg"),
                    ProductId = 15
                },
                     new Image
                {
                    Title = "Image 1",
                    ImageData = File.ReadAllBytes("wwwroot/products_images/S7.jpg"),
                    ProductId = 16
                },
                      new Image
                {
                    Title = "Image 1",
                    ImageData = File.ReadAllBytes("wwwroot/products_images/S8.png"),
                    ProductId = 17
                },
                       new Image
                {
                    Title = "Image 1",
                    ImageData = File.ReadAllBytes("wwwroot/products_images/S9.jpg"),
                    ProductId = 18
                },
                 
                       
                // Luggage and Travel Gear

                new Image
                {
                    Title = "Image 1",
                    ImageData = File.ReadAllBytes("wwwroot/products_images/BD1.jpg"),
                    ProductId = 19
                },
                 new Image
                {
                    Title = "Image 1",
                    ImageData = File.ReadAllBytes("wwwroot/products_images/BD2.jpg"),
                    ProductId = 20
                },
                     new Image
                {
                    Title = "Image 1",
                    ImageData = File.ReadAllBytes("wwwroot/products_images/BD3.jpg"),
                    ProductId = 21
                },
                  new Image
                {
                    Title = "Image 1",
                    ImageData = File.ReadAllBytes("wwwroot/products_images/BA4.jpg"),
                    ProductId = 22
                },
                   new Image
                {
                    Title = "Image 1",
                    ImageData = File.ReadAllBytes("wwwroot/products_images/BA5.jpg"),
                    ProductId = 23
                },
                    new Image
                {
                    Title = "Image 1",
                    ImageData = File.ReadAllBytes("wwwroot/products_images/BA6.jpg"),
                    ProductId = 24
                },
                     new Image
                {
                    Title = "Image 1",
                    ImageData = File.ReadAllBytes("wwwroot/products_images/BS7.jpg"),
                    ProductId = 25
                },
                      new Image
                {
                    Title = "Image 1",
                    ImageData = File.ReadAllBytes("wwwroot/products_images/BS8.jpg"),
                    ProductId = 26
                },
                       new Image
                {
                    Title = "Image 1",
                    ImageData = File.ReadAllBytes("wwwroot/products_images/BS9.jpg"),
                    ProductId = 27
                },

            };

            return images;
        }
    }
}
