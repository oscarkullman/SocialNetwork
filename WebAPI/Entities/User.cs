using WebAPI.Entities;

namespace WebAPI.Models
{
    public class User : BaseEntity
    {
        public string? Username { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Email { get; set; }

        public DateTime? DateRegistered { get; set; }

        public Guid? UserId { get; set; }
        public virtual ICollection<Follower>? followers { get; set; }
    }
}
