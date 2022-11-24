using SocialNetwork.Classes.Account;
using WebAPI.Models;

namespace WebAPI.Entities
{
    public class UserConstants
    {
        public static List<User> Users = new List<User>()
        {
            new User() { Username = "jason_admin",    Password = "test", Email="email@test.com"},
            new User() { Username = "elyse_seller", Password = "test" },
        };
        
    }
}
