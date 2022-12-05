using SocialNetwork.Classes.User;

namespace WebAPI.DTO
{
    public class UserDto
    {
        public int? Id { get; set; }
        
        public string? Username { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Email { get; set; }

        public ICollection<FollowDto>? Follows { get; set; } = new List<FollowDto>();

        public DateTime? DateRegistered { get; set; }
    }
}
