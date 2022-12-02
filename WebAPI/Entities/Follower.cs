using WebAPI.Models;

namespace WebAPI.Entities
{
    public class Follower :BaseEntity
    {
        public int FollowerId { get; set; }

        public User User { get; set; }
    }
}
