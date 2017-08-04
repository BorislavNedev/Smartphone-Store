namespace SmartphoneStore.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System.Data.Entity;

    public class SmartphoneStoreDbContext : IdentityDbContext<User>
    {
        public SmartphoneStoreDbContext()
            : base("SmartphoneStoreConnection", throwIfV1Schema: false)
        {
        }

        public IDbSet<Manufacturer> Manufacturers { get; set; }

        public IDbSet<Smartphone> Smartphones { get; set; }

        public IDbSet<Comment> Comments { get; set; }

        public IDbSet<Vote> Votes { get; set; }
        
        public static SmartphoneStoreDbContext Create()
        {
            return new SmartphoneStoreDbContext();
        }
    }
}
