using SocialNetwork.Classes.Account;
using System.Linq.Expressions;
using WebAPI.Entities;
using WebAPI.Repositories;
using WebAPI.Specification;

namespace WebAPI.Infrastructure.Repositories
{
    public interface IFollowerRepository : IRepository<Follower>
    {
        Task FollowUser(FollowModel followModel);

    }
}
