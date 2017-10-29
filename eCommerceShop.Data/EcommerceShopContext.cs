using eCommerceShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceShop.Data
{
    public class EcommerceShopContext : DbContext,IEcommerceShopContext
    {
        public EcommerceShopContext(DbConnection dbConnection) : base(dbConnection, true) { }

        public EcommerceShopContext() { }

        public IDbSet<Customer> Customers { get; set; }
        public IDbSet<Product> Products { get; set; }
        public IDbSet<ProductType> ProductTypes { get; set; }
        public IDbSet<Order> Orders { get; set; }
        public IDbSet<OrderItem> OrderItems { get; set; }


        public void Add<T>(params T[] entities) where T : class
        {
            Set<T>().AddRange(entities);
        }

        public void ModelStateAdd<T>(params T[] entities) where T : class
        {
            Entry(entities).State = EntityState.Added;
        }

        public void Edit<T>(T entity) where T : class
        {
            Set<T>().AddOrUpdate(entity);
        }

        public void Delete<T>(params T[] entities) where T : class
        {
            Set<T>().RemoveRange(entities);
        }

        public System.Linq.IQueryable<T> GetAll<T>() where T : class
        {
            return Set<T>().AsQueryable();
        }

        public System.Linq.IQueryable<T> FindBy<T>(System.Linq.Expressions.Expression<System.Func<T, bool>> predicate) where T : class
        {
            return Set<T>().Where(predicate).AsQueryable();
        }

        public bool ExecusteSqlCommand(string sql)
        {
            return Database.ExecuteSqlCommand(sql) > 0;
        }

        public async Task<bool> ExecuteSqlCommandAsync(string sql)
        {
            return await Database.ExecuteSqlCommandAsync(sql) > 0;
        }

        public void Commit(string query)
        {
            Database.ExecuteSqlCommand(query);
        }

        public async Task<int> CommitAsync(string query)
        {
            return await Database.ExecuteSqlCommandAsync(query);
        }

        public void Commit()
        {
            SaveChanges();
        }

        public async Task<int> CommitSync()
        {
            return await SaveChangesAsync();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.AddFromAssembly(GetType().Assembly);

            base.OnModelCreating(modelBuilder);
        }

       
    }
}
