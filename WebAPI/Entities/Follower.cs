using WebAPI.Models;

namespace WebAPI.Entities
{
    public class Follower :BaseEntity
    {
        public Guid FollowerId { get; set; }

        public User User { get; set; }
    }
}
