using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebAPI.Data;

namespace WebAPI.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private protected DbSet<TEntity> _context;

        public Repository(DataContext dataContext)
        {
            _context = dataContext.Set<TEntity>();
        }
        
        public async Task<ICollection<TEntity>> Query()
        {
            return await _context.AsQueryable().ToListAsync();
        }

        public async Task<ICollection<TEntity>> Query(Expression<Func<TEntity, bool>> expression)
        {
            return await _context.Where(expression).ToListAsync();
        }
    }
}
