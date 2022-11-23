using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebAPI.Data;
using WebAPI.Specification;

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

        public async Task<ICollection<TEntity>> QueryWithSpec(ISpecification<TEntity> spec)
        {
            return await ApplySpec(spec).ToListAsync();
        }

        private IQueryable<TEntity> ApplySpec(ISpecification<TEntity> spec)
        {
            var query = _context.AsQueryable();

            if (spec.Criteria != null)
            {
                query = query.Where(spec.Criteria);
            }

            if (spec.Skip.HasValue && spec.Take.HasValue)
            {
                query = query.Skip(spec.Skip.Value).Take(spec.Take.Value);
            }

            return query;
        }
    }
}
