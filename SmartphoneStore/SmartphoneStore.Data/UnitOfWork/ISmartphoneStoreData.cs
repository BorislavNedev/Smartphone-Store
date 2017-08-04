namespace SmartphoneStore.Data.UnitOfWork
{
    using Models;
    using Repositories;

    public interface ISmartphoneStoreData
    {
        IRepository<User> Users { get; }

        IRepository<Smartphone> Smartphones { get; }

        IRepository<Manufacturer> Manufacturers { get; }
        
        IRepository<Comment> Comments { get; }
        
        IRepository<Vote> Votes { get; }

        int SaveChanges();
    }
}