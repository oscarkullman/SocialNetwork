using SocialNetwork.Classes.Account;
using WebAPI.Models;

namespace WebAPI.Entities
{
    public class UserConstants
    {
        public static List<LoginModel> Users = new List<LoginModel>()
        {
            new LoginModel() { Username = "jason_admin",    Password = "test"},
            new LoginModel() { Username = "elyse_seller", Password = "test" },
        };
        
    }
}
