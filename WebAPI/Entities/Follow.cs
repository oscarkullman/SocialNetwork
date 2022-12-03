namespace WebAPI.Entities
{
    public class Follow : BaseEntity
    {
        public int? UserId { get; set; }

        public string? Username { get; set; }
    }
}
