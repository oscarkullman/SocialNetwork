using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Classes.Post
{
    public class PostDto
    {
        public Guid? PostId { get; set; }

        public string? WallOwner { get; set; }

        public string? Username { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Content { get; set; }

        public DateTime? DateCreated { get; set; }
    }
}
