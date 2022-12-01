using WebAPI.Entities;
using WebAPI.Infrastructure.Specification.Params;
using WebAPI.Specification;

namespace WebAPI.Infrastructure.Specification
{
    public class PostSpecification : BaseSpecification<Post> 
    { 
        public PostSpecification(PostParams postParams) : base(x =>
            (!string.IsNullOrEmpty(postParams.Username) ? x.Username.ToLower().Contains(postParams.Username) : true))
        {
            if (!string.IsNullOrEmpty(postParams.Sort))
            {
                switch (postParams.Sort)
                {
                    case "createdascending":
                        SortMethod(x => x.DateCreated);
                        break;

                    case "createddescending":
                        SortDescendingMethod(x => x.DateCreated);
                        break;
                }
            }
        }
    }
}
