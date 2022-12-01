using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Entities;

namespace xUnitTests.Backend
{
    public class PostTests
    {

        private List<Post>  _posts = new List<Post>{
            new Post{
                PostId = Guid.NewGuid(),

                Username = "Rompa23",
                FirstName = "Roman",

                LastName = "Parker",

                Content = "My first post, the wheater is very nice today! Have a good day my followers!",

                DateCreated = DateTime.Now,
            },
            new Post{
                PostId = Guid.NewGuid(),

                Username = "masken1",
                FirstName = "Max",

                LastName = "Almroth",

                Content = "My first post, the wheater is very nice today! Have a good day my followers!",

                DateCreated = DateTime.Now,
            },
            new Post{
                PostId = Guid.NewGuid(),

                Username = "Kullen12",
                FirstName = "Oscar",

                LastName = "Kullman",

                Content = "My first post, the wheater is very nice today! Have a good day my followers!",

                DateCreated = DateTime.Now,
            },

        };
    }
}
