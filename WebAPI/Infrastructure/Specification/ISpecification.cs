using System.Linq.Expressions;

namespace WebAPI.Specification
{
    public interface ISpecification<T>
    {
        Expression<Func<T, bool>>? Criteria { get; }

        List<Expression<Func<T, object>>>? Includings { get; }

        Expression<Func<T, object>>? Sort { get; }

        Expression<Func<T, object>>? SortDescending { get; }

        int? Skip { get; }

        int? Take { get; }
    }
}
