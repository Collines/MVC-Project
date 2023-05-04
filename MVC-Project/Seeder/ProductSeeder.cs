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
                },
                new Product {
                    ProductName = "Amazfit GTS 4 Mini Smart Watch - Midnight Black",
                    Description = "Dimensions41.8x36.66x9.1mmWeight (with strap)31.2gBody MaterialAluminum alloy + plasticButtons1Water-resistance Grade5 ATM, Battery Capacity270 mAh",
                    Price = 3349,
                    Quantity = 10,
                    IsAvailable = true,
                    BrandID = 14, // Amazfit
                    SubCategoryId = 9 // Smart Watches
                },
                new Product {
                    ProductName = "Amazfit GTS 2 Smart Watch - Pink - New Version",
                    Description = "Size (square): 42.8 * 35.6 * 9.7mmWeight: 24.7g (without strap)Body: Aluminum alloyBottom Shell: Plastic1 buttonWaterproofing Grade: 5 ATM, Material: AMOLEDSize",
                    Price = 4229,
                    Quantity = 10,
                    IsAvailable = true,
                    BrandID = 14, // Amazfit
                    SubCategoryId = 9 // Smart Watches
                },
                new Product {
                    ProductName = "Amazfit Bip 3 Smart Watch 1.69 Large Display, 14-Day Battery Life, 60+ Sports Modes, 5 ATM Water-Resistant - Black",
                    Description = "【Big on Screen, Big on Style】Immerse yourself in the 1.69\" super-large and colorful HD display, and see all your incoming text and calls in awesome, expansive quality. Express more of yourself with 50+ watch faces and editable watch faces & widgets - or customize with your own photos.",
                    Price = 1928,
                    Quantity = 10,
                    IsAvailable = true,
                    BrandID = 14, // Amazfit
                    SubCategoryId = 9 // Smart Watches
                },
                new Product {
                    ProductName = "Amazfit T.Rex Pro Smartwatch - BLUE",
                    Description = "Screen : 1.3HD inches, AMOLED, 2.5D, Gorilla Glass 3 Protection- Size: 47.7*47.7*13.5 mm- Body Material: Polycarbonate- Weight: 60g- Resolution 360 X 360 - Battery capacity: 390mAh - Charging time: Up to 1.5hours- Typical use battery life: 18 days- Heavy use battery life: 9 days",
                    Price = 7000,
                    Quantity = 10,
                    IsAvailable = true,
                    BrandID = 14, // Amazfit
                    SubCategoryId = 9 // Smart Watches
                },
                new Product {
                    ProductName = "Bml W7 - 41MM - SMART WATCH- 1.57 INCH HD DISPLAY - WIRELESS CHARGING",
                    Description = "BLUETOOTH CALL CHECK THE INFORMATION FULL SCREEN TOUCH MORE THAN THE DIAL WEATHER HEART RATE MONITOR MOTOR FUNCTION LOCATION FUNCTION VOICE FUNCTION 1.57 INCH HD DISPLAY Zinc alloy+ML built on both sides BRAND NEW INTERFACE DESIGN HONEYCOMB DESIGN REBOUNDS IN ONE SECOND MULTIPLE Ul MODES RAISE YOUR WRIST TO BRIGHTEN THE SCREEN WIRELESS CHARGING.",
                    Price = 1200,
                    Quantity = 10,
                    IsAvailable = true,
                    BrandID = 15, // bml
                    SubCategoryId = 9 // Smart Watches
                },
                new Product {
                    ProductName = "Apple Watch ULTRA 49mm (SlM) Titanium Case - Blue/Gray Trail Loop",
                    Description = "The aerospace-grade titanium case strikes the perfect balance of weight, durability, and corrosion resistance. The rugged Alpine Loop is made from two textile layers woven together into one continuous piece without stitching, with a titanium G-hook to ensure a secure fit.",
                    Price = 34000,
                    Quantity = 10,
                    IsAvailable = true,
                    BrandID = 13, // apple
                    SubCategoryId = 9 // Smart Watches
                },
                new Product {
                    ProductName = "Apple Watch SE (2nd Gen) 40mm Midnight Alu Mid SP Band S/M GPS",
                    Description = "All the essentials to help you monitor your fitness, keep connected, track your health, and stay safe. Now up to 20 percent faster, with features like Crash Detection and enhanced workout metrics, it’s a better value than ever. EASILY CUSTOMIZABLE — Available in a range of sizes and colors, with dozens of bands to choose from and watch faces with complications tailored to whatever you’re into.",
                    Price = 12500,
                    Quantity = 10,
                    IsAvailable = true,
                    BrandID = 13, // apple
                    SubCategoryId = 9 // Smart Watches
                },
                new Product {
                    ProductName = "Apple Watch Nike Series 7 41mm - Midnight Aluminum With Anthracite - Black Nike Sport Band - GPS",
                    Description = "The Apple Watch Series 7 has a bigger, brighter, and tougher display that extends to the edge of the device. There isn't any flashy new gimmick or headlining health feature in this model, but there are still a handful of changes worth exploring. New colors, faster charging, and exclusive edge-to-edge watch faces add up to an iterative yet desirable upgrade.",
                    Price = 15350,
                    Quantity = 10,
                    IsAvailable = true,
                    BrandID = 13, // apple
                    SubCategoryId = 9 // Smart Watches
                },
                new Product {
                    ProductName = "Apple Watch SE (2nd Gen) 44mm Silver Alu White SP Band S/M GPS",
                    Description = "Redesigned with the planet in mind, Crash Detection A safety feature we hope you’ll never need, Get a closer look at your shut-eye. Noise The Noise app lets you know when high noise levels around you can possibly affect your hearing, Do almost everything on Apple Watch — ask for directions, get a weather report or play a song — just by talking to Siri",
                    Price = 14000,
                    Quantity = 10,
                    IsAvailable = true,
                    BrandID = 13, // apple
                    SubCategoryId = 9 // Smart Watches
                },
                new Product {
                    ProductName = "Apple Watch Series 7 45mm Green Alu Clover Sp Band GPS MKN73",
                    Description = "Apple Watch Series 7 (GPS + Cellular) and Apple Watch SE (GPS + Cellular) can use a cellular connection for Emergency SOS. To use Emergency SOS on an Apple Watch without cellular, your iPhone needs to be nearby. If your iPhone isn’t nearby, your Apple Watch needs to be connected to a known Wi-Fi network and you must set up Wi-Fi Calling.",
                    Price = 16000,
                    Quantity = 10,
                    IsAvailable = true,
                    BrandID = 13, // apple
                    SubCategoryId = 9 // Smart Watches
                },
                new Product {
                    ProductName = "Apple Watch Series 7 45mm - Blue - Aluminum - Abyss Blue Sport Band - GPS",
                    Description = "The Apple Watch Series 7 will most likely be unveiled alongside the new iPhone 13 generation. From what we’ve seen so far",
                    Price = 16000,
                    Quantity = 10,
                    IsAvailable = true,
                    BrandID = 13, // apple
                    SubCategoryId = 9 // Smart Watches
                },
                new Product {
                    ProductName = "T500 Smart Watch For Android & Ios",
                    Description = "T500 Smart Watch Size 44 MM Full Touch Screen Bluetooth Call Push Notifications With Detachable Silicone Band For IOS & Android",
                    Price = 1400,
                    Quantity = 10,
                    IsAvailable = true,
                    BrandID = 13, // apple
                    SubCategoryId = 9 // Smart Watches
                },
                new Product {
                    ProductName = "Huawei MatePad T8 - 8.0-inch 32GB/2GB Single SIM 4G Tablet - Deepsea Blue",
                    Description = "This device uses Huawei Mobile Services (HMS) instead of Google Mobile Services (GMS). 8.0-inch HD IPS LCD Screen, 32GB Storage, 2 GB RAM, 5 MP Back Camera, 2 MP Front Camera, Octa-core CPU: 4x2.0 GHz + 4x1.5 GHz, Li-Po 5100 mAh Battery, Single SIM, OS: Android 10, EMUI 10, no Google Play Services",
                    Price = 4798,
                    Quantity = 10,
                    IsAvailable = true,
                    BrandID = 11, // Huawei
                    SubCategoryId = 8 // Tablets
                },
                new Product {
                    ProductName = "Huawei MatePad T 8 - 32GB/2GB - 8 Inch - Deepsea Blue",
                    Description = "Display: 8 inch IPS LCD capacitive touchscreen, 16M colors, Camera: 5MP rear camera, 2MP front camera, Memory: 32GB internal storage, 2GB RAM, Processor: Mediatek MT8768 octa core processor, Battery Capacity: 5100mAh, Number of Sim Card: Single Sim, Operating System: Android 10, EMUI 10.1 without Google Play Services, Connectivity: Wi-Fi, GPS, Bluetooth 5.0, microUSB 2.0, USB On-The-Go",
                    Price = 4900,
                    Quantity = 10,
                    IsAvailable = true,
                    BrandID = 11, // Huawei
                    SubCategoryId = 8 // Tablets
                },
                new Product {
                    ProductName = "Huawei Matepad T8 - 2gb Ram - 32gb - Deepsea Blue",
                    Description = "Huawei MatePad T8 Tablet, 8 Inch, 32GB, 2GB RAM, Wi-Fi - Deepsea Blue, Display. 8-inch IPS LCD capacitive touchscreen (1280 x 800) , Key Features. - Eye comfort",
                    Price = 5150,
                    Quantity = 10,
                    IsAvailable = true,
                    BrandID = 11, // Huawei
                    SubCategoryId = 8 // Tablets
                },
                new Product {
                    ProductName = "Lenovo Tab M7 7305X 2GB RAM 32GB",
                    Description = "Lenovo Tab M7 TB-7305X - 2GB RAM - 32GB - 7 inch - Black , SIM Card: Nano-SIM , Screen: 7.0 inches 600 x 1024 pixels , RAM: 2 GB , Internal memory: 32 GB ",
                    Price = 2880,
                    Quantity = 10,
                    IsAvailable = true,
                    BrandID = 10, // Lenovo
                    SubCategoryId = 8 // Tablets
                },
                new Product {
                    ProductName = "Lenovo Tab P11 Plus - 4GB RAM - 128GB - Gray",
                    Description = "Great for work, tooThis tablet can also tackle laptop-level work, thanks to the optional ultrathin keyboard with built-in trackpad and shortcut keys.Sketch, paint, or take notes whenever inspiration strikes with the optional Lenovo Precision Pen 2—featuring 4,096 pressure levels, tilt detection, and 200 hours of usage time on one charge.",
                    Price = 17200,
                    Quantity = 10,
                    IsAvailable = true,
                    BrandID = 10, // Lenovo
                    SubCategoryId = 8 // Tablets
                },
                new Product {
                    ProductName = "Lenovo Tab M7 - 2GB/32GB - 7 Inch - Onyx Black",
                    Description = "Brand: Lenovo,Model: Tab M7, Type: Tablet, Processor: Mediatek MT8321, Ram: 2 GB, Storage: 32 GB, Network: 3G, Case Material: Metal, Front Camera: 2 MP, Rear Camera: 2 MP, Battery capacity: 3500 mAh, Operating System: Android, Microphone: Yes, Bluetooth: Yes, Wireless: Yes, Supports Single Nano SIM Card",
                    Price = 2900,
                    Quantity = 10,
                    IsAvailable = true,
                    BrandID = 10, // Lenovo
                    SubCategoryId = 8 // Tablets
                },
                new Product {
                    ProductName = "Lenovo Tab Yoga 11 -J706 - 4GB RAM - 128GB",
                    Description = "The world filtered through cinema lenses,Your own private screening awaits with Dolby Vision™ on a stunning 2K display, whether you're at home or on the go.Binge-watch without worry, thanks to TÜV-certified eye care.",
                    Price = 14249,
                    Quantity = 10,
                    IsAvailable = true,
                    BrandID = 10, // Lenovo
                    SubCategoryId = 8 // Tablets
                },
                new Product {
                    ProductName = "Lenovo Original 10.1 inch TABLET Tab 2 A10-70F MT8165 Quad Core 64-Bit 2GB 16GB Android 6.0 Tablet PC, 7000mAh 1920x1200 8MP Camera",
                    Description = "( USED / RE-NEWED ) 10.1 inch TABLET  Lenovo Tab 2 A10-70F MT8165 Quad Core 64-Bit 2GB 16GB Android 6.0 Tablet PC, 7000mAh 1920x1200 8MP Camera,This device is only designed to work with the current Android OS installed on it. Any changes such as updates or flashing a newer version will void the warranty.",
                    Price = 2112,
                    Quantity = 10,
                    IsAvailable = true,
                    BrandID = 10, // Lenovo
                    SubCategoryId = 8 // Tablets
                },
                new Product {
                    ProductName = "Lenovo Tab M10 HD - 10.1-inch 3GB/32GB Nano-SIM - Slate Black",
                    Description = "Qualcomm® Snapdragon™ 429, Quad-Core, 2GHz, 10.1, HD (1280 x 800) IPS with capacitive 10-point multitouch, 4850mAh 18.7Wh",
                    Price = 55555,
                    Quantity = 10,
                    IsAvailable = true,
                    BrandID = 10, // Lenovo
                    SubCategoryId = 8 // Tablets
                },
                new Product {
                    ProductName = "Lenovo Tab M7 - 2GB/32GB-7 Inch-platinum Grey",
                    Description = "Brand: Lenovo-Model: Tab M7 - Type: Tablet-Processor: Mediatek MT8321 - Ram: 2 GB - Storage: 32 GB- Network: 3G",
                    Price = 2900,
                    Quantity = 10,
                    IsAvailable = true,
                    BrandID = 10, // Lenovo
                    SubCategoryId = 8 // Tablets
                },
                new Product {
                    ProductName = "Nokia Tap T20 4GB Ram, 64GB - Ocean Blue",
                    Description = "Nokia T20 Tablet, 10.4 Inch, 64GB, 4GB RAM, 4G LTE - Ocean Blue ; Processor. Unisoc T610 octa-core ; Battery Capacity. 8200mAh with 15W fast charging.",
                    Price = 6200,
                    Quantity = 10,
                    IsAvailable = true,
                    BrandID = 12, // Nokia
                    SubCategoryId = 8 // Tablets
                },
                new Product {
                    ProductName = "Nokia T20 – 10.4 Inch – 64GB/4GB – Android 4G LTE Tablet – Deep Ocean",
                    Description = "Nokia T20 brings the classic Nokia quality to the big screen, and helps you find better work-life balance. Its crystal clear 2K screen lets you see both work presentations and movie marathons in stunning detail, and enhanced speakers and dual microphones help you hear and be heard better. Take part in up to 7 hours of conference calls, enjoy a season of your favourite show on one go, or work and play throughout the day with its long-lasting battery",
                    Price = 5675,
                    Quantity = 10,
                    IsAvailable = true,
                    BrandID = 12, // Nokia
                    SubCategoryId = 8 // Tablets
                },
                new Product {
                    ProductName = "OPPO A77 6.56 Inches, Dual SIM, 128GB, 4GB RAM, 4G LTE,Sky Blue",
                    Description = "leather backSIM Dual SIM (Nano-SIM, dual stand-by) IP54, dust and water resistant, DisplayType IPS LCD, 90Hz, 480 nits (typ), 600 nits (HBM)Size 6.56 inches, 103.4 cm2 (~84.2% screen-to-body ratio)Resolution 720 x 1612 pixels, 20:9 ratio (~269 ppi density), PlatformOS Android 12, ColorOS 12.1Chipset MediaTek MT6765G Helio G35 (12 nm)CPU Octa-core (4x2.3 GHz Cortex-A53 & 4x1.8 GHz Cortex-A53)GPU PowerVR GE8320, MemoryCard slot microSDXCInternal 128GB 4GB RAMUFS 2.2",
                    Price = 6250,
                    Quantity = 10,
                    IsAvailable = true,
                    BrandID = 7, // OPPO
                    SubCategoryId = 7 // Smart Phones
                },
                 new Product {
                    ProductName = "OPPO A16k - 6.52-inch 64GB/4GB Dual SIM Mobile Phone -Blue",
                    Description = "OPPO A16K (4GB RAM + 64GB) has larger screen size of 6.52 inches in comparison to Tecno Spark 6 Go's 6.52 inch screen. Tecno Spark 6 Go has TFT Screen type where as OPPO A16K (4GB RAM + 64GB) has IPS LCD Screen type",
                    Price = 4440,
                    Quantity = 10,
                    IsAvailable = true,
                    BrandID = 7, // OPPO
                    SubCategoryId = 7 // Smart Phones
                },
                 new Product {
                    ProductName = "OPPO A96, 256 GB, 8GB Ram, Screen Size 6.59 Inches, GB Starry Black",
                    Description = "OS Version : 11, 1- Screen Size : 6.59 Inches- CPU : 8 cores, up to 2.4 GHz- Internal Memory : 256 GB- RAM : 8 GB- Rear / Front Camera : 50 + 2 MP / 16 MP- Battery Capacity : 5000 mAh",
                    Price = 9450,
                    Quantity = 10,
                    IsAvailable = true,
                    BrandID = 7, // OPPO
                    SubCategoryId = 7 // Smart Phones
                },
                 new Product {
                    ProductName = "OPPO Reno 7, 6.43 Inch, 256GB 8GB, 4G - Sunset Orange",
                    Description = "Display size (6.43 inches, 99.8 cm2 (~85.3% screen-to-body ratio)- Platform: OS (Android 12, ColorOS 12.1), Chipset (Qualcomm SM6225 Snapdragon 680 4G (6 nm), CPU (Octa-core (4x2.4 GHz Kryo 265 Gold & 4x1.9 GHz Kryo 265 Silver), GPU (Adreno 610), Memory:Card slot (microSDXC (dedicated slot), Internal (256GB 8GB RAM)- Main Camera:Dual (64 MP, f/1.7, 26mm (wide), 1/2.0, 0.7µm, PDAF / 2 MP, f/3.3, (microscope) / 2 MP, f/2.4, (depth), Selfie camera (32 MP, f/2.4, 24mm (wide), 1/2.74, 0.8µm)",
                    Price = 11300,
                    Quantity = 10,
                    IsAvailable = true,
                    BrandID = 7, // OPPO
                    SubCategoryId = 7 // Smart Phones
                },
                 new Product {
                    ProductName = "OPPO A54 - 6.51-inch 128GB/4GB Dual SIM 4G Mobile Phone - Negro",
                    Description = "Oppo A54 Dual SIM Mobile Phone - 6.51 Inch, 128 GB, 4 GB RAM, 4G LTE - Negro ... OPPO A55 - 6.51-inch 128GB/4GB Dual SIM 4G Mobile Phone - Starry Black. Main Camera Triple: 13 MP, f/2.2, 25mm (wide), 1/3.06, 1.12µm, PDAF 2 MP, f/2.4, (macro) 2 MP, f/2.4, (depth) Features LED flash, HDR, panorama Video 1080p@30fps",
                    Price = 6700,
                    Quantity = 10,
                    IsAvailable = true,
                    BrandID = 7, // OPPO
                    SubCategoryId = 7 // Smart Phones
                },
                 new Product {
                    ProductName = "OPPO A55 - 6.51-inch 128GB/4GB Dual SIM 4G Mobile Phone - Rainbow Blue",
                    Description = "Display: 6.51 inches (720 x 1600) IPS LCD, 480 nits touchscreen. Connectivity: Bluetooth 5.0, Wi-Fi, GPS, Type-C USB 2.0, fingerprint sensor. Battery Capacity:5000 mAh",
                    Price = 5950,
                    Quantity = 10,
                    IsAvailable = true,
                    BrandID = 7, // OPPO
                    SubCategoryId = 7 // Smart Phones
                },
                 new Product {
                    ProductName = "OPPO A57 6.56 Inches ,4G - Dual Sim Mobile Phone, 4GB RAM 64GB ROM - Glowing Green",
                    Description = "Oppo A57 4G Android smartphone. Announced May 2022. Features 6.56″ display, MT6765G Helio G35 chipset, 5000 mAh battery, 128 GB storage, 4 ",
                    Price = 5600,
                    Quantity = 10,
                    IsAvailable = true,
                    BrandID = 7, // OPPO
                    SubCategoryId = 7 // Smart Phones
                },
                 new Product {
                    ProductName = "Infinix Hot 20 - 6.82 Inch 128GB/6GB(UpTo 11GB)Ram Gaming Dual Sim 4G Mobile Phone- Fantasy Purple",
                    Description = "Infinix Hot 20 Android smartphone. Announced Oct 2022. Features 6.82″ display, MT6769Z Helio G85 chipset, 5000 mAh battery, 128 GB storage, 8 GB RAM.",
                    Price = 5960,
                    Quantity = 10,
                    IsAvailable = true,
                    BrandID = 9, // Infinix
                    SubCategoryId = 7 // Smart Phones
                },
                 new Product {
                    ProductName = "Infinix Hot 20i - 6.6-inch 128GB/4GB(UpTo 7GB)Ram Dual Sim 4G Mobile Phone - Sunset Gold",
                    Description = "allowing you to cache up to 11 background apps and switch seamlessly. Your apps are always on call.Fast & Fun GamingHelio G25 Octa-Core ProcessorThe Helio G25 powerful processor provides fast and fun gaming experiences from its combination of octa-core Arm Cortex-A53 CPU operating up to 2.0GHz.LinkPlus 1.0 Game Network Auto-AdjustorGet tired of stutter while gaming? LinkPlus 1.0 can switch to mobile data automatically to prevent latency, overheating and power consumption from weak wifi network.",
                    Price = 4474,
                    Quantity = 10,
                    IsAvailable = true,
                    BrandID = 9, // Infinix
                    SubCategoryId = 7 // Smart Phones
                },
                 new Product {
                    ProductName = "Infinix Hot 20S - 6.78 Inch 128GB/8GB(UpTo 13GB)Ram Gaming Dual Sim 4G Mobile Phone- Sonic Black",
                    Description = "A Smartphone that can (Breathe)-HOT 20S adopts a three-dimensional structure called Bionic (Breathing) Cooling System that simulated the nature of breath, cooling off the phone by improving the thermal conductivity. Up to 13GB RAM 8+5GB Extended RAM- Smooth like never before. Extended RAM Tech kicks in and enables 8GB RAM to add up to 13GB RAM in use, allowing you to cache up to 20 background apps and switch seamlessly. Your apps are always on call.",
                    Price = 6300,
                    Quantity = 10,
                    IsAvailable = true,
                    BrandID = 9, // Infinix
                    SubCategoryId = 7 // Smart Phones
                },
                 new Product {
                    ProductName = "Infinix Smart 6 - 6.6-inch 64GB/3GB Dual SIM Mobile Phone-Quetzal Cyan",
                    Description = "Infinix Smart 6 comes equipped with an excellent 32GB internal storage which is further expandable up to 512GB. -6000mah battery who goes longer. Do endless calls and watch back-to-back videos. Even more power. Boost your battery level by 25% with power marathon tech.",
                    Price = 3680,
                    Quantity = 10,
                    IsAvailable = true,
                    BrandID = 9, // Infinix
                    SubCategoryId = 7 // Smart Phones
                },
                 new Product {
                    ProductName = "Infinix Smart 6 HD - 6.6 Inch 32GB/2GB Ram Dual Sim 4G Mobile Phone - Aqua Sky",
                    Description = "Infinix Smart 6 HD (Aqua Sky, 32 GB) (2 GB RAM) · 2 GB RAM | 32 GB ROM | Expandable Upto 512 GB · 16.76 cm (6.6 inch) HD+ Display · 8MP Rear Camera  - 6.6” HD+ 500nits Waterdrop Sunlight Display. Mega 5000mAh Battery + Power Marathon. 2GB RAM+32GB ROM with AppSquezz. 8MP AI Rear Camera & Dual Flash.",
                    Price = 3000,
                    Quantity = 10,
                    IsAvailable = true,
                    BrandID = 9, // Infinix
                    SubCategoryId = 7 // Smart Phones
                },
                 new Product {
                    ProductName = "Infinix Hot 20S Up To 13GB/128GB, 120Hz FHD+ / FREE FIRE Special Limited Edition - Tempo Blue",
                    Description = "Infinix Hot 20S Android smartphone. Announced Oct 2022. Features 6.78″ display, MT6781 Helio G96 chipset, 5000 mAh battery, 128 GB storage, 8 GB RAM, Extended RAM Tech kicks in and enables 8GB RAM to add up to 13GB RAM in use, allowing you to cache up to 20 background apps and switch seamlessly.",
                    Price = 6900,
                    Quantity = 10,
                    IsAvailable = true,
                    BrandID = 9, // Infinix
                    SubCategoryId = 7 // Smart Phones
                },
                 new Product {
                    ProductName = "Infinix Smart 6 - 6.6-inch 64GB/3GB Dual SIM Mobile Phone-Midnight Black",
                    Description = "Infinix ; Model. Smart 6 ; Display. 6.6-inch 64GB/3GB Dual SIM Mobile Phone-Midnight Black.  HD+ Waterdrop Sunlight (720 x 1600) display ; Rear Camera. - 8 MP, AF. - 0.8 MP, (depth) ; Front Camera. 5MP",
                    Price = 3700,
                    Quantity = 10,
                    IsAvailable = true,
                    BrandID = 9, // Infinix
                    SubCategoryId = 7 // Smart Phones
                },
                 new Product {
                    ProductName = "Infinix Smart 6 PLus - 6.82 - Inch 64GB/2GB(UpTo 4GB)Ram Dual Sim4G Mobile Phone - Crystal Violet",
                    Description = "Infinix Smart 6 PLus, Display: 6.82 inches, Cpu, Processor: Octa-core. Ram: 2 GB, Storge, Storage: 64 GB. Back Camera: 8 + 0.3 MP, Rear Camera, Front Camera Dual 8 MP, f/2.0, AF",
                    Price = 3460,
                    Quantity = 10,
                    IsAvailable = true,
                    BrandID = 9, // Infinix
                    SubCategoryId = 7 // Smart Phones
                },
                 new Product {
                    ProductName = "Samsung Galaxy A03 - 6.5-inch 128GB/4GB Dual Sim 4G Mobile Phone - Black",
                    Description = "Galaxy A03 features a 48MP Main Camera for amazing everyday photos. You can even adjust the background and foreground focus with the 2MP Depth Camera's Live Focus effects. One UI Core helps you focus on what matters to you. Hardware and software work together, with content and features at your fingertips so you can get to them faster. Seamlessly switch apps and get information for multiple apps at once—the convenient UI design lets you multitask on a single screen.",
                    Price = 4650,
                    Quantity = 10,
                    IsAvailable = true,
                    BrandID = 8, // Samsung
                    SubCategoryId = 7 // Smart Phones
                },
                 new Product {
                    ProductName = "Samsung Galaxy A04 – 6.5 Inch 64GB/4GB Dual SIM Mobile Phone – White",
                    Description = "Expand your view to the 6.5-inch Infinity-V Display of Galaxy A04 and see what you've been missing. Minimal look, quality design This is elegant symmetry with polish. The new Ambient Edge design matches an alluring curved edge with a glossy back that looks and feels great. Available in Black, White, Green, and Copper.Awesome 50MP Camera, capture every detail",
                    Price = 4660,
                    Quantity = 10,
                    IsAvailable = true,
                    BrandID = 8, // Samsung
                    SubCategoryId = 7 // Smart Phones
                },
                 new Product {
                    ProductName = "Samsung Galaxy A04e-LTE – 6.5 Inch – 32GB/3GB Dual SIM Mobile Phone – Copper",
                    Description = "Galaxy A04e-Immerse yourself in a truly immersive experience, Enjoy a view without limits With the Galaxy A04e's 6.5-inch Infinity-V Display, see everything you love without interr",
                    Price = 4100,
                    Quantity = 10,
                    IsAvailable = true,
                    BrandID = 8, // Samsung
                    SubCategoryId = 7 // Smart Phones
                },
                 new Product {
                    ProductName = "Samsung Galaxy A32 - 6.4-inch 128GB/6GB Dual SIM Mobile Phone - Awesome Black",
                    Description = "Samsung Galaxy A32 - 6GB RAM - 128GB - Black ; SIM Card: Dual SIM (Nano-SIM, dual stand-by) ; Screen: 6.4 inches 1080 x 2400 pixels ; RAM: 6 GB, Awesome screen, real smooth scrolling. Feast your eyes on vibrant details with the FHD+ Super AMOLED display, reaching 800 nits¹ for clarity even in bright",
                    Price = 9100,
                    Quantity = 10,
                    IsAvailable = true,
                    BrandID = 8, // Samsung
                    SubCategoryId = 7 // Smart Phones
                },
                 new Product {
                    ProductName = "Samsung Galaxy A13 6.6-inch 64GB/4GB Dual SIM 4G Mobile Phone - Black",
                    Description = "With the Galaxy A13's 8MP Front Camera and bokeh effect, it's easy to snap stunning selfies that feature more you and less background.The Galaxy A13 combines Octa-core processing power with up to 3GB/4GB/6GB of RAM for fast and efficient performance for the task at hand. Enjoy 32GB/64GB/128GB of internal storage and add up to 1TB more with MicroSD card. Expand your view to the 6.6-inch Infinity-V Display of Galaxy A13 and get the bigger picture on what you've been missing. With FHD+ technology, your everyday content also looks sharp, crisp and clear.",
                    Price = 4670,
                    Quantity = 10,
                    IsAvailable = true,
                    BrandID = 8, // Samsung
                    SubCategoryId = 7 // Smart Phones
                },
                 new Product {
                    ProductName = "Samsung Galaxy A34 - 6.6 inches - 8GB Ram - 128GB Internal Memory – 5G – Double Sim Mobile – Awesome Lime",
                    Description = "Samsung Galaxy A34 5G 128 GB ROM + 8GB RAM Awesome Lime Dual-Sim Mobile 48+8+5MP Rear Camera + 13MP Front Camera 5000 mAhGalaxy-A34-CONF · 6.6 Inch Super AMOLED, he phone features a modern and sleek design with a vibrant and large 6.6-inch Super AMOLED display. The display provides clear and vivid visuals",
                    Price = 13500,
                    Quantity = 10,
                    IsAvailable = true,
                    BrandID = 8, // Samsung
                    SubCategoryId = 7 // Smart Phones
                },
                 new Product {
                    ProductName = "Samsung Galaxy A33 8GB Ram, 128GB - Awesome Blue",
                    Description = "Iconically Simple-Do more with less. Samsung Galaxy A33 5G is now slimmer and more sophisticated with a matte finish, quality bezels and seamless camera housing with the Ambient Edge. Awesome screen, spectacularly vivid color-Expand your view to the 6.4-inch Infinity-U Display on Galaxy A33 5G and see what you've been missing. Even in the bright outdoors, you can experience everything you love in vivid high-definition and true-to-life color with FHD+ Super AMOLED display technology.",
                    Price = 12000,
                    Quantity = 10,
                    IsAvailable = true,
                    BrandID = 8, // Samsung
                    SubCategoryId = 7 // Smart Phones
                },
                 new Product {
                    ProductName = "Samsung Galaxy A53 5g - 6.5 - Inch 256GB-8GB Dual Sim Mobile Phone - Awesome Blue",
                    Description = "Samsung A53 5G-Our most awesome Galaxy A Series yet, with a multi-lens camera for brilliant photos and video, smooth scrolling 120Hz display, and a fast-charging battery that just keeps going. Get crisper, clearer shots with the 64MP OIS Camera, expand your viewing angle with the Ultra Wide Camera, customize focus with the Depth Camera and get closer to details with the Macro Camera. With bokeh effects and dual lenses, capture the detailed attributes that make every face unique. Blur backgrounds and focus on the details that bring your photos to life.",
                    Price = 16000,
                    Quantity = 10,
                    IsAvailable = true,
                    BrandID = 8, // Samsung
                    SubCategoryId = 7 // Smart Phones
                },
                 new Product {
                    ProductName = "Samsung Galaxy A23- 6.6-inch 128GB/4GB Dual Sim 4G Mobile Phone - Blue",
                    Description = "Samsung Galaxy A23 Dual SIM, 128GB, 6GB RAM, 4G LTE - Blue , Connectivity, Wifi, Cellular , Resolution, 1080x2400 , Display Size, 6.6 Inch , Display Type, PLS LCD",
                    Price = 5900,
                    Quantity = 10,
                    IsAvailable = true,
                    BrandID = 8, // Samsung
                    SubCategoryId = 7 // Smart Phones
                },
                 new Product {
                    ProductName = "Samsung Galaxy A14 - 6.6 Inches - 4GB Ram - 64GB Internal Memory – 4G – Double Sim Mobile – Silver",
                    Description = "Samsung Galaxy A14 5G Android smartphone. Announced Jan 2023. Features 6.6″ display, Exynos 1330 chipset, 5000 mAh battery, 128 GB storage, 8 GB RAM. Network, 4G , Expandable Memory Type, MicroSD , Fast Charging, Yes , Flash, LED , Internal Memory, 64 GB",
                    Price = 6370,
                    Quantity = 10,
                    IsAvailable = true,
                    BrandID = 8, // Samsung
                    SubCategoryId = 7 // Smart Phones
                },
                 new Product {
                    ProductName = "Samsung Galaxy M52 - 6.7-inch 128GB/8GB Dual SIM 5G Mobile Phone -Black",
                    Description = "Samsung Galaxy M52 it offers class-leading battery life. The M52-5G is like a cheaper alternative to the A52s – it's a similar phone but without the ingress protection, OIS for the main camera, and stereo speakers. Wrap your hands around the elegantly slim design of the new Galaxy M52 5G. At just 7.4mm thick, the comfortable grip and smooth curves provide easy screen",
                    Price = 11777,
                    Quantity = 10,
                    IsAvailable = true,
                    BrandID = 8, // Samsung
                    SubCategoryId = 7 // Smart Phones
                }

            };

            return products;
        }
    }
}
