using shopping.Models;

namespace MVC_Project.Seeder
{
    public static class ProductSeeder
    {
        public static List<Product> Seed()
        {
            var products = new List<Product>
            {
                //Watches

                // brand 1

                 new Product {
                    ProductName = "1948 BULOVA “His Excellency LL” Wristwatch 21-Jewel Cal. 7AK U.S.A. Made Watch",
                    Description = "It is a manual wind watch powered by an original Bulova 21-jewel movement adjusts to heat and cold, caliber 7AK (based on ETA 735), sub-second hand, U.S.A. made.",
                    Price = 379.00,
                    Quantity = 10,
                    IsAvailable = true,
                    BrandID = 1,
                    SubCategoryId = 1,
                },
                 new Product {
                    ProductName = "Bulova 98A185 Curv Rose Gold Tone Case Chronograph Men's Watch - Black",
                    Description = "Casual, Diver, Dress/Formal, Pilot/Aviator , 12-Hour Dial, Chronograph, Date Indicator, Water-Resistant",
                    Price = 530.97,
                    Quantity = 10,
                    IsAvailable = true,
                    BrandID = 1,
                    SubCategoryId = 1
                },
                 new Product {
                    ProductName = "Bulova Men's Black Watch - 97D116",
                    Description = "Stainless Steel, Crystal , Water-Resistant, Mineral Crystal, Luminous Hands, Date Indicator, Diamond Accent, 12-Hour Dial, Push/Pull Crown, Scratch-Resistant, Chronograph",
                    Price = 213.91,
                    Quantity = 10,
                    IsAvailable = true,
                    BrandID = 1,
                    SubCategoryId = 1
                },

                // brand 2

                 new Product {
                    ProductName = "Casio Men's Quartz Chronograph Black Resin Band 51mm Watch MCW110H-2A2V",
                    Description = "Date Indicator, 12-Hour Dial, Chronograph , MCW-110H-2A2VCF , Band/Strap-Two-Piece Strap",
                    Price = 780.00,
                    Quantity = 10,
                    IsAvailable = true,
                    BrandID = 2,
                    SubCategoryId = 1,
                },
                 new Product {
                    ProductName = "Casio Edifice EFR-539BK-1A2V Standard Chronograph Full Black Men's Quartz watch",
                    Description = "Casual, Classic, Dress/Formal, Luxury , Bezel Type-3 Dimentional Bezel , Band Material-Stainless Steel",
                    Price = 870.00,
                    Quantity = 10,
                    IsAvailable = true,
                    BrandID = 2,
                    SubCategoryId = 1
                },
                 new Product {
                    ProductName = "Casio Edifice EFR-539SG-1AVU Chronograph Full Gold Plated Black Dial Men's Watch-",
                    Description = "Casual, Classic, Dress/Formal, Luxury , 12-Hour Dial, Chronograph, Date Indicator, Push/Pull Crown, Scratch-Resistant, Seconds Hand, Water-Resistant",
                    Price = 350.00,
                    Quantity = 10,
                    IsAvailable = true,
                    BrandID = 2,
                    SubCategoryId = 1
                },

                // brand 3

                 new Product {
                    ProductName = "Timex Men's TW4B20900 Solar Expedition Ranger 43MM Case Black Kvadrat Starp",
                    Description = "Timex Expedition , 12-Hour Dial, Date Indicator, Luminous Hands, Seconds Hand, Water-Resistant",
                    Price = 370.00,
                    Quantity = 10,
                    IsAvailable = true,
                    BrandID = 3,
                    SubCategoryId = 1,
                },
                 new Product {
                    ProductName = "Timex Legacy Day Date 36mm Stainless Steel Bracelet Watch- Tiffany Blue Dial",
                    Description = "Timex Legacy Day Date 36mm Stainless Steel Bracelet Watch- Tiffany Blue Dial.-Condition : Brand New. Unworn . Still in original packaging.---Tiffany Blue dial",
                    Price = 650.00,
                    Quantity = 10,
                    IsAvailable = true,
                    BrandID = 3,
                    SubCategoryId = 1
                },
                 new Product {
                    ProductName = "Timex Men’s TW4B12300 Expedition Field Chronograph Tan/Black Leather Strap Watch",
                    Description = "Round / Causal , Timex Expedition , 12-Hour Dial, Date Indicator, Luminous Hands, Seconds Hand, Water-Resistant",
                    Price = 450.00,
                    Quantity = 10,
                    IsAvailable = true,
                    BrandID = 3,
                    SubCategoryId = 1
                },


                // Sunglasses 
                // brand 1
                new Product {
                    ProductName = "NEW Gucci GG0053S Sunglasses 100% UV Women Oversized Sunglasses",
                    Description = "STYLE: Rectangular-FRAME MATERIAL: Acetate-LENS MATERIAL: Plastic-FIT: Standard-EYE SIZE: 54 mm-BRIDGE/TEMPLE SIZE: 25/140 mm--Comes with branded case, cloth, paperwork",
                    Price = 159.00,
                    Quantity = 10,
                    IsAvailable = true,
                    BrandID = 4,
                    SubCategoryId = 2 
                },
                new Product {
                    ProductName = "Gucci GG Pink Gold / Brown Grey Gradient Oversized Sunglasses GG0903SA",
                    Description = "GUCCI SUNGLASSES -GG 0903S 005-Comes in Plastic Bag with MFR Tags-NO ACCESSORIES INCLUDED -Frame color: Gold Pink-Lens color: Brown Grey-Lens size:60mm-Bridge Size:17mm-Arm size:145mm-Ships within one business day guaranteed ",
                    Price = 109.00,
                    Quantity = 10,
                    IsAvailable = true,
                    BrandID = 4,
                    SubCategoryId = 2
                },
                new Product {
                    ProductName = "Gucci GG 1090SA 001 XL Shiny Gold / Grey Gradient Sunglasses GG1090S 59MM",
                    Description = "GUCCI SUNGLASSES -GG 1090SA 001 -Comes in Plastic Bag with MFR Tags-NO ACCESSORIES INCLUDED -Frame color: Shiny Gold-Lens color: Grey-Lens size:59mm-Bridge Size:17mm-Arm size:145mm-Ships within one business day guaranteed ",
                    Price = 89.00,
                    Quantity = 10,
                    IsAvailable = true,
                    BrandID = 4,
                    SubCategoryId = 2
                },

                // brand 2

                new Product {
                    ProductName = "Tom Ford FT 0764 Sabrina 01B Shiny Black/Smoke Gradient Womens Sunglasses",
                    Description = "A brand-new, unused, and unworn item (including handmade items) that is not in original packaging or may be missing original packaging materials (such as the original box or bag). The original tags may not be attached.--",
                    Price = 250.00,
                    Quantity = 10,
                    IsAvailable = true,
                    BrandID = 5,
                    SubCategoryId = 2
                },
                new Product {
                    ProductName = "Tom Ford FT0842 28F Women's Butterfly Sunglasses - Gold Tone/Brown",
                    Description = "Made in Italy. Bridge Width: 09mm. Temple Length: 135mm. Lens Color: Brown/Light Brown/Sand. ",
                    Price = 89.99,
                    Quantity = 10,
                    IsAvailable = true,
                    BrandID = 5,
                    SubCategoryId = 2
                },
                new Product {
                    ProductName = "Tom Ford Oversized Black Sunglasses Gradient Smoke Rimless Gold TF 810-K 28B",
                    Description = "Brand: Tom Ford--Model Code: TF 810-K--Color Code: 28B--Frame Color: Shiny Gold with Black Temple Tips--Lenses Color: Black Grey Smoke Gradient--Temple Length: 145 mm--Lens Width: 62 mm--Bridge Width: 15 mm--Frame Height: 60 mm--Frame Width: 150 mm--Item Condition: Brand New.--Accessories: Storage Case. Microfibre Cloth. Manufacturers Information Papers. Authenticity Card.--SKU: 889214135438",
                    Price = 163.40,
                    Quantity = 10,
                    IsAvailable = true,
                    BrandID = 5,
                    SubCategoryId = 2
                },
                // brand 3
                new Product {
                    ProductName = "Chanel 4126 Wrap Around Visor Shield Oversized Sunglasses",
                    Description = "Vintage Y2K Authentic Chanel 4126 Wrap Around Visor Shield Oversized Sunglasses.---Frames are in excellent condition. Lenses show faint scratches which are only noticeable upon close inspection (pictured) optics are unaffected Great condition considering age.---Arms also loose but doesn’t effect functionality of sunglasses.---Includes original hard case",
                    Price = 95.00,
                    Quantity = 10,
                    IsAvailable = true,
                    BrandID = 6,
                    SubCategoryId = 2
                },
                new Product {
                    ProductName = "Chanel round sunglasses with chain Metal Gold Lenses Gray Gradient",
                    Description = "Chanel round sunglasses with chain Metal Gold Lenses Gray Gradient-perfect condition comes with original box, case and  napkin-bought in Chanel website",
                    Price = 490.00,
                    Quantity = 10,
                    IsAvailable = true,
                    BrandID = 6,
                    SubCategoryId = 2
                },
                new Product {
                    ProductName = "CHANEL Sunglasses New Black Beige Brown CH5414 C.534/3 54 20 140",
                    Description = "Model Number: CH5414 C.534/3 54 20 140-Frame: Black Beige Logo-Lens: Brown--Condition: 100% Authentic Sunglasses",
                    Price = 594.99,
                    Quantity = 10,
                    IsAvailable = true,
                    BrandID = 6,
                    SubCategoryId = 2
                },


                // Luggage and Travel Gear

                // Brand 1

                new Product {
                    ProductName = "Dejavu trendy multi colored trendy handbag, Acqua, One Size",
                    Description = "Package Dimensions : 27.9 x 25.6 x 11.2 cm; 480 Grams-Date First Available: 12 September 2022-Manufacturer: Dejavu-ASIN B0BF27FRTP",
                    Price = 849,
                    Quantity = 10,
                    IsAvailable = true,
                    BrandID = 7,
                    SubCategoryId = 3,
                },
                 new Product {
                    ProductName = "Dejavu,shoulder bag,One size",
                    Description = "Product Dimensions : 30 x 25 x 10 cm; 1 Kilograms - Item model number : LID-DJTH-024 , Item model number : LID-DJTH-024",
                    Price = 973,
                    Quantity = 10,
                    IsAvailable = true,
                    BrandID = 7,
                    SubCategoryId = 3
                },
                 new Product {
                    ProductName = "Dejavu Trendy Patterned Shoulder Bag, D.Gray, One size, LID/DVTH/051",
                    Description = "Package Dimensions: 47 x 32.2 x 9.2 cm; 760 Grams-Date First Available: 12 September 2022-Manufacturer : Dejavu-ASIN : B0BF1B881N",
                    Price = 858,
                    Quantity = 10,
                    IsAvailable = true,
                    BrandID = 7,
                    SubCategoryId = 3
                },

                // Brand 2

                 new Product {
                    ProductName = "Adidas CLSC BOS BP PREBLU",
                    Description = "Adidas CLSC BOS BP PREBLU/WHITE NOT SPORTS SPECIFIC BACKPACK HR9813 for Unisex preloved blue size NS",
                    Price = 789,
                    Quantity = 10,
                    IsAvailable = true,
                    BrandID = 8,
                    SubCategoryId = 3,
                },
                 new Product {
                    ProductName = "Adidas LINEAR DUF XS BLACK",
                    Description = "Adidas LINEAR DUF XS BLACK/WHITE NOT SPORTS SPECIFIC DUFFEL HT4744 for Unisex black size NS",
                    Price = 755,
                    Quantity = 10,
                    IsAvailable = true,
                    BrandID = 8,
                    SubCategoryId = 3
                },
                 new Product {
                    ProductName = "Adidas TIRO L BACKPACK TENABL",
                    Description = "Adidas TIRO L BACKPACK TENABL/BLACK/WHITE FOOTBALL/SOCCER BACKPACK IB8646 for Unisex team navy blue 2 size NS",
                    Price = 1049.00,
                    Quantity = 10,
                    IsAvailable = true,
                    BrandID = 8,
                    SubCategoryId = 3
                },

                // Brand 3

                 new Product {
                    ProductName = "Delsey Cuzco 55 cm 4-Wheel Cabin Trolley (black)",
                    Description = "Manufacturer:Delsey , Item model number:206813791 , Product Dimensions is 55 x 33 x 23 cm; 5 Kilograms , ASIN is B08NYSJDXM",
                    Price = 4267.00,
                    Quantity = 10,
                    IsAvailable = true,
                    BrandID = 9,
                    SubCategoryId = 3,
                },
                 new Product {
                    ProductName = "Delsey Ordener 55 Cm 4 D.W. Cabin Trolley",
                    Description = "Manufacturer:Delsey , Item model number:206813791 , Product Dimensions is 55 x 33 x 23 cm; 5 Kilograms , ASIN is B08NYSJDXM",
                    Price = 3792.00,
                    Quantity = 10,
                    IsAvailable = true,
                    BrandID = 9,
                    SubCategoryId = 3
                },
                 new Product {
                    ProductName = "Delsey Cuzco 78 cm 4-Wheel Trolley (black)",
                    Description = "Manufacturer:Delsey , Item model number:206813791 , Product Dimensions is 55 x 33 x 23 cm; 5 Kilograms , ASIN is B08NYSJDXM",
                    Price = 6450.00,
                    Quantity = 10,
                    IsAvailable = true,
                    BrandID = 9,
                    SubCategoryId = 3
                },
            };

            return products;
        }
    }
}
