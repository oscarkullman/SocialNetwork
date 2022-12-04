namespace WebAPI.Entities
{
    public class Message : BaseEntity
    {
        public Guid MessageId { get; set; }

        public string? Sender { get; set; }

        public string? Reciever { get; set; }

        public string? Content { get; set; }

        public DateTime? DateSent { get; set; }
    }
}
