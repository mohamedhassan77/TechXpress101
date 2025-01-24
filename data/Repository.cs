using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TechXpress.Models;

namespace TechXpress.Data
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly TechXpressContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(TechXpressContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync(bool includeAllNavigationProperties = false)
        {
            IQueryable<T> query = _dbSet;

            if (includeAllNavigationProperties)
            {
                // Get all navigation properties for the entity type
                var navigationProperties = _context.Model.FindEntityType(typeof(T))
                    .GetNavigations()
                    .Select(n => n.Name);

                // Include all navigation properties dynamically
                foreach (var property in navigationProperties)
                {
                    query = query.Include(property);
                }
            }

            return await query.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public void Update(T entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }


        public async Task<Product> GetByIdWithCategoryAsync(int id)
        {
            return await _context.Products
                .Include(p => p.Category) 
                .FirstOrDefaultAsync(p => p.Id == id);
        }
        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }
    }
}