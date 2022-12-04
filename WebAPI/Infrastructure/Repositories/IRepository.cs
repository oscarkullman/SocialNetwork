using System.Linq.Expressions;
using WebAPI.Specification;

namespace WebAPI.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<ICollection<TEntity>> Query();

        Task<ICollection<TEntity>> Query(Expression<Func<TEntity, bool>> expression);

        Task<ICollection<TEntity>> QueryWithSpec(ISpecification<TEntity> spec);

        Task<TEntity?> QueryFirst(Expression<Func<TEntity, bool>> expression);

        Task<TEntity?> QueryFirstWithSpec(ISpecification<TEntity> spec);
    }
}
