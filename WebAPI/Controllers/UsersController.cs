using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/users/")]
    public class UsersController 
    {


        public UsersController()
        {

        }

        [HttpGet("Test")]
        public async Task<string> TestEndpoint()
        {
            return "I work! Yay!";
        }
    }
}
