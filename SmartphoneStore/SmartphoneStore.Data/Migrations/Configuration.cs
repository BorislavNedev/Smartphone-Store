namespace SmartphoneStore.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<SmartphoneStoreDbContext>
    {
        private UserManager<User> userManager;

        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
            ContextKey = "SmartphoneStore.Data.SmartphoneStoreDbContext";
        }

        protected override void Seed(SmartphoneStoreDbContext context)
        {
            this.userManager = new UserManager<User>(new UserStore<User>(context));
            this.SeedRoles(context);
            this.SeedAdmin(context);
            this.SeedManufacturesAndSmartphones(context);
        }

        private void SeedRoles(SmartphoneStoreDbContext context)
        {
            context.Roles.AddOrUpdate(x => x.Name, new IdentityRole("Admin"));
            context.SaveChanges();
        }

        private void SeedAdmin(SmartphoneStoreDbContext context)
        {
            if (context.Users.Any())
            {
                return;
            }

            var adminUser = new User
            {
                Email = "admin@mysite.com",
                UserName = "Administrator"
            };

            this.userManager.Create(adminUser, "admin123456");

            this.userManager.AddToRole(adminUser.Id, "Admin");
        }

        private void SeedManufacturesAndSmartphones(SmartphoneStoreDbContext context)
        {
            if (context.Manufacturers.Any())
            {
                return;
            }

            Manufacturer apple = new Manufacturer
            {
                Name = "Apple"
            };
            context.Manufacturers.Add(apple);

            Smartphone iPhone7 = new Smartphone
            {
                Manufacturer = apple,
                Model = "iPhone 7",
                MonitorSize = 4.7,
                RamMemorySize = 8,
                Price = 1380,
                ImageUrl = "https://www.o2.co.uk/shop/homepage/images/shop15/brand/apple/iphone7/apple-iphone-7-gallery-img-5.jpg"
            };
            context.Smartphones.Add(iPhone7);

            Smartphone iPhone7Plus = new Smartphone
            {
                Manufacturer = apple,
                Model = "iPhone 7 Plus",
                MonitorSize = 4.7,
                RamMemorySize = 8,
                Price = 1340,
                ImageUrl = "https://www.o2.co.uk/shop/homepage/images/shop15/brand/apple/iphone-7-plus/apple-iphone-7-plus-gallery-img-5.jpg"
            };
            context.Smartphones.Add(iPhone7Plus);

            Smartphone iPhone6s = new Smartphone
            {
                Manufacturer = apple,
                Model = "iPhone 6s",
                MonitorSize = 4.7,
                RamMemorySize = 8,
                Price = 1200,
                ImageUrl = "https://www.o2.co.uk/shop/homepage/images/shop15/brand/apple/iphone-6s/apple-iphone-6s-2016-ios-ios-10-gallery-img-3-101016.jpg"
            };
            context.Smartphones.Add(iPhone6s);

            Smartphone iPhone6sPlus = new Smartphone
            {
                Manufacturer = apple,
                Model = "iPhone 6s Plus",
                MonitorSize = 4.7,
                RamMemorySize = 8,
                Price = 1200,
                ImageUrl = "https://cdn2.macworld.co.uk/cmsdata/reviews/3628130/apple_iphone_6s_plus.jpg"
            };
            context.Smartphones.Add(iPhone6sPlus);

            Smartphone iPhone6 = new Smartphone
            {
                Manufacturer = apple,
                Model = "iPhone 6",
                MonitorSize = 4.7,
                RamMemorySize = 8,
                Price = 1150,
                ImageUrl = "https://www.o2.co.uk/shop/homepage/images/shop15/brand/apple/iphone-6/apple-iphone-6-2016-ios-10-gallery-img-1-101016.jpg"
            };
            context.Smartphones.Add(iPhone6);

            Manufacturer samsung = new Manufacturer
            {
                Name = "Samsung"
            };
            context.Manufacturers.Add(samsung);

            Smartphone galaxyNote = new Smartphone
            {
                Manufacturer = samsung,
                Model = "Galaxy Note",
                MonitorSize = 4.7,
                RamMemorySize = 8,
                Price = 1350,
                ImageUrl = "http://cdn.ndtv.com/tech/images/samsung_galaxy_note_4_website_product_listing.jpg?output-quality=80"
            };
            context.Smartphones.Add(galaxyNote);

            Smartphone galaxyGrand = new Smartphone
            {
                Manufacturer = samsung,
                Model = "Galaxy Grand",
                MonitorSize = 4.7,
                RamMemorySize = 8,
                Price = 1310,
                ImageUrl = "http://cdn2.gsmarena.com/vv/pics/samsung/samsung-galaxy-grand-prime-sm-g530h-1.jpg"
            };
            context.Smartphones.Add(galaxyGrand);

            Smartphone galaxyA = new Smartphone
            {
                Manufacturer = samsung,
                Model = "Galaxy A",
                MonitorSize = 4.7,
                RamMemorySize = 8,
                Price = 1330,
                ImageUrl = "http://cdn.ndtv.com/tech/images/gadgets/samsung_galaxy_a5_official.jpg"
            };
            context.Smartphones.Add(galaxyA);

            Smartphone galaxyS = new Smartphone
            {
                Manufacturer = samsung,
                Model = "Galaxy S",
                MonitorSize = 4.7,
                RamMemorySize = 8,
                Price = 1270,
                ImageUrl = "https://scdn.androidcommunity.com/wp-content/uploads/2015/12/samsung-galaxy-s-1.jpg"
            };
            context.Smartphones.Add(galaxyS);

            Smartphone galaxyJ = new Smartphone
            {
                Manufacturer = samsung,
                Model = "Galaxy J",
                MonitorSize = 4.7,
                RamMemorySize = 8,
                Price = 1150,
                ImageUrl = "http://cdn2.gsmarena.com/vv/pics/samsung/samsung-galaxy-j-SGH-N075T-white.jpg"
            };
            context.Smartphones.Add(galaxyJ);

            Manufacturer sony = new Manufacturer
            {
                Name = "Sony"
            };
            context.Manufacturers.Add(sony);

            Smartphone experiaXZ = new Smartphone
            {
                Manufacturer = sony,
                Model = "Experia XZ",
                MonitorSize = 4.7,
                RamMemorySize = 8,
                Price = 1220,
                ImageUrl = "https://d2giyh01gjb6fi.cloudfront.net/default/0001/61/thumb_60145_default_big.jpeg"
            };
            context.Smartphones.Add(experiaXZ);

            Smartphone experiaL1 = new Smartphone
            {
                Manufacturer = sony,
                Model = "Experia L1",
                MonitorSize = 4.7,
                RamMemorySize = 8,
                Price = 1150,
                ImageUrl = "http://uareviral.com/wp-content/uploads/2017/03/sony-xperia-l1-.jpg"
            };
            context.Smartphones.Add(experiaL1);
        }
    }
}
