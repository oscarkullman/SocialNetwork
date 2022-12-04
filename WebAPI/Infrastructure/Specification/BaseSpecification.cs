using System.Linq.Expressions;

namespace WebAPI.Specification
{
    public class BaseSpecification<T> : ISpecification<T> where T : class
    {
        public Expression<Func<T, bool>>? Criteria { get; private set; }

        public List<Expression<Func<T, object>>>? Includings { get; private set; } = new();

        public Expression<Func<T, object>>? Sort { get; private set; }

        public Expression<Func<T, object>>? SortDescending { get; private set; }

        public int? Skip { get; private set; }

        public int? Take { get; private set; }

        public BaseSpecification(Expression<Func<T, bool>> expression)
        {
            Criteria = expression;
        }

        public BaseSpecification() { }

        public void IncludeMethod(Expression<Func<T, object>> expression)
        {
            Includings.Add(expression);
        }

        public void SortMethod(Expression<Func<T, object>> expression)
        {
            Sort = expression;
        }

        public void SortDescendingMethod(Expression<Func<T, object>> expression)
        {
            SortDescending = expression;
        }

        public void ApplyPagination(int skip, int take)
        {
            Skip = skip;
            Take = take;
        }
    }
}
