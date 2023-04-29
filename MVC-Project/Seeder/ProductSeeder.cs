using shopping.Models;

namespace MVC_Project.Seeder
{
    public static class ProductSeeder
    {
        public static List<Product> Seed()
        {
            var products = new List<Product>
            {
                new Product {
                    ProductName = "Rear View Backup Camera Parking Assist",
                    Description = "【Safe and Reliable】All YZHIDIANF backup camera have undergone strict quality control not only before shipment but also during the entire production process. 15 quality control inspections have been carried out in each step of production to ensure 100% factory qualified",
                    Price = 2753,
                    Quantity = 10,
                    IsAvailable = true,
                    BrandID = 1, // YZHIDIANF
                    SubCategoryId = 1 // Car & Vehicle Electronics
                },
                new Product {
                    ProductName = "Dashboard Mount-2022 Magnetic Phone Mount for Car",
                    Description = "Magnetic suction and adsorption: 60 times N52 magnetic suction to hold your phone firmly (please be sure to use it together with the metal plate).3M high and low temperature resistant stickers, even at 40 degrees Celsius, will not fall off.",
                    Price = 581,
                    Quantity = 10,
                    IsAvailable = true,
                    BrandID = 2, // Oxbot
                    SubCategoryId = 1 // Car & Vehicle Electronics
                },
                new Product {
                    ProductName = "Dash Cam Front Rear, 4K/2.5K Full HD Dash Camera for Cars",
                    Description = "4K+1080P DUAL RECORDING- REDTIGER brings to you F7NP dual dash cam which records video of up to Ultra HD 4K(3840*2160P)+FHD 1080P resolutions. It helps you to read the key details like road signs, vehicle number plates etc. To reduce the blind areas it has the front wide angle of 170 degree and rear wide angle of 140 degree. This helps you during unexpected circumstances like collision to retain and present evidence.",
                    Price = 4589,
                    Quantity = 10,
                    IsAvailable = true,
                    BrandID = 3, // REDTIGER
                    SubCategoryId = 1 // Car & Vehicle Electronics
                },
                new Product {
                    ProductName = "Soundcore Anker Life Q20 Hybrid Active Noise Cancelling Headphones",
                    Description = "Hi-Res Audio: Custom oversized 40 mm dynamic drivers produce Hi-Res sound. Life Q20 active noise canceling headphones reproduce music with extended high frequencies that reach up to 40 kHz for extraordinary clarity and detail.",
                    Price = 1835,
                    Quantity = 10,
                    IsAvailable = true,
                    BrandID = 4, // Anker
                    SubCategoryId = 2 // Headphones
                },
                new Product {
                    ProductName = "JBL Tune 130NC TWS True Wireless In-Ear Noise Cancelling Headphones",
                    Description = "JBL Pure Bass Sound: Smartly designed 10mm drivers enhanced by the Dot form factor deliver JBL's Pure Bass Sound so you'll feel every pulsing beat.",
                    Price = 1835,
                    Quantity = 10,
                    IsAvailable = true,
                    BrandID = 5, // JBL
                    SubCategoryId = 2 // Headphones
                },
                new Product {
                    ProductName = "Skullcandy Crusher Evo Wireless Over-Ear Bluetooth Headphones",
                    Description = "Feel the bass tuned to you - Listen to songs the way they were made to be heard. With Audiodo customization the Crusher Evo analyzes your hearing and produces sound specifically for YOU. Adjust the bass with a slide to produce bass you can feel!",
                    Price = 4406,
                    Quantity = 10,
                    IsAvailable = true,
                    BrandID = 6, // Skullcandy
                    SubCategoryId = 2 // Headphones
                }
            };

            return products;
        }
    }
}
