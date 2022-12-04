using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Classes.Message
{
    public class MessageDto
    {
        public string? Sender { get; set; }

        public string? Reciever { get; set; }

        public string? Content { get; set; }

        public DateTime? DateSent { get; set; }
    }
}
