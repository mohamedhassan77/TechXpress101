using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TechXpress.Models;

namespace TechXpress.Data
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync(bool includeAllNavigationProperties = false);
        Task<T> GetByIdAsync(int id);
        Task AddAsync(T entity);
        void Update(T entity);
        void Remove(T entity);
        Task SaveAsync();
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
        Task<Product> GetByIdWithCategoryAsync(int id);
    }
}