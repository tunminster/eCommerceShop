using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceShop.Data
{
    public interface IEcommerceShopContext
    {
        void Add<T>(params T[] entities) where T : class;
        void Edit<T>(T entity) where T : class;
        void Delete<T>(params T[] entities) where T : class;
        IQueryable<T> GetAll<T>() where T : class;
        IQueryable<T> FindBy<T>(Expression<Func<T, bool>> predicate) where T : class;
        void ModelStateAdd<T>(params T[] entities) where T : class;
        void Commit();
        Task<int> CommitSync();
        void Commit(string query);
        Task<int> CommitAsync(string query);
        bool ExecusteSqlCommand(string sql);
    }
}
