using System.Linq.Expressions;

namespace WebAPI.Specification
{
    public interface ISpecification<T>
    {
        Expression<Func<T, bool>>? Criteria { get; }

        Expression<Func<T, object>>? Sort { get; }

        int? Skip { get; }

        int? Take { get; }
    }
}
