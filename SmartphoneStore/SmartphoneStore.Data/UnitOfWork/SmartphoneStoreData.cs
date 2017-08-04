using SmartphoneStore.Data.Repositories;
using SmartphoneStore.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace SmartphoneStore.Data.UnitOfWork
{
    public class SmartphoneStoreData : ISmartphoneStoreData
    {
        private readonly DbContext dbContext;

        private readonly IDictionary<Type, object> repositories;

        public SmartphoneStoreData()
            : this(new SmartphoneStoreDbContext())
        {
        }

        public SmartphoneStoreData(DbContext dbContext)
        {
            this.dbContext = dbContext;
            this.repositories = new Dictionary<Type, object>();
        }
        
        public IRepository<User> Users
        {
            get
            {
                return this.GetRepository<User>();
            }
        }

        public IRepository<Smartphone> Smartphones
        {
            get
            {
                return this.GetRepository<Smartphone>();
            }
        }

        public IRepository<Manufacturer> Manufacturers
        {
            get
            {
                return this.GetRepository<Manufacturer>();
            }
        }

        public IRepository<Comment> Comments
        {
            get
            {
                return this.GetRepository<Comment>();
            }
        }

        public IRepository<Vote> Votes
        {
            get
            {
                return this.GetRepository<Vote>();
            }
        }

        public int SaveChanges()
        {
            return this.dbContext.SaveChanges();
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            if (!this.repositories.ContainsKey(typeof(T)))
            {
                var type = typeof(EntityFrameworkRepository<T>);
                this.repositories.Add(
                    typeof(T),
                    Activator.CreateInstance(type, this.dbContext));
            }

            return (IRepository<T>)this.repositories[typeof(T)];
        }
    }
}
