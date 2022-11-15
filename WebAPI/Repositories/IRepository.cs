using System.Linq.Expressions;

namespace WebAPI.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<ICollection<TEntity>> Query();

        Task<ICollection<TEntity>> Query(Expression<Func<TEntity, bool>> expression);
    }
}
