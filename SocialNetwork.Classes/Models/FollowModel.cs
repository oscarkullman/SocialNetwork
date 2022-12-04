using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Classes.Models
{
    public class FollowModel
    {
        public string? UserFollowing { get; set; }

        public string? UserToFollow { get; set; }
    }
}
