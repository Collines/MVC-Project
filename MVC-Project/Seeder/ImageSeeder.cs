using shopping.Models;

namespace MVC_Project.Seeder
{
    public static class ImageSeeder
    {
        public static List<Image> Seed()
        {
            var images = new List<Image>
            {
                new Image
                {
                    Title = "Image 1",
                    ImageData = File.ReadAllBytes("wwwroot/products_images/1.jpg"),
                    ProductId = 1
                },
                new Image
                {
                    Title = "Image 2",
                    ImageData = File.ReadAllBytes("wwwroot/products_images/2.jpg"),
                    ProductId = 1
                },
                new Image
                {
                    Title = "Image 3",
                    ImageData = File.ReadAllBytes("wwwroot/products_images/3.jpg"),
                    ProductId = 2
                },
                new Image
                {
                    Title = "Image 4",
                    ImageData = File.ReadAllBytes("wwwroot/products_images/4.jpg"),
                    ProductId = 2
                },
                new Image
                {
                    Title = "Image 5",
                    ImageData = File.ReadAllBytes("wwwroot/products_images/5.jpg"),
                    ProductId = 3
                },
                new Image
                {
                    Title = "Image 6",
                    ImageData = File.ReadAllBytes("wwwroot/products_images/6.jpg"),
                    ProductId = 3
                },
                new Image
                {
                    Title = "Image 7",
                    ImageData = File.ReadAllBytes("wwwroot/products_images/7.jpg"),
                    ProductId = 4
                },
                new Image
                {
                    Title = "Image 8",
                    ImageData = File.ReadAllBytes("wwwroot/products_images/8.jpg"),
                    ProductId = 4
                },
                new Image
                {
                    Title = "Image 9",
                    ImageData = File.ReadAllBytes("wwwroot/products_images/9.jpg"),
                    ProductId = 5
                },
                new Image
                {
                    Title = "Image 10",
                    ImageData = File.ReadAllBytes("wwwroot/products_images/10.jpg"),
                    ProductId = 5
                },
                new Image
                {
                    Title = "Image 11",
                    ImageData = File.ReadAllBytes("wwwroot/products_images/11.jpg"),
                    ProductId = 6
                },
                new Image
                {
                    Title = "Image 12",
                    ImageData = File.ReadAllBytes("wwwroot/products_images/12.jpg"),
                    ProductId = 6
                }
            };

            return images;
        }
    }
}
