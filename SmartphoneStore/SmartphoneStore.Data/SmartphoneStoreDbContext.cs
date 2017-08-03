namespace SmartphoneStore.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;

    public class SmartphoneStoreDbContext : IdentityDbContext<User>
    {
        public SmartphoneStoreDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static SmartphoneStoreDbContext Create()
        {
            return new SmartphoneStoreDbContext();
        }
    }
}
