namespace WebAPI.Entities
{
    public class Post : BaseEntity
    {
        public Guid? PostId { get; set; }
        
        public string? Username { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Content { get; set; }

        public DateTime? DateCreated { get; set; }
    }
}
