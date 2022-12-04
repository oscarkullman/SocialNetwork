using SocialNetwork.Classes;
using WebAPI.Entities;
using WebAPI.Repositories;

namespace WebAPI.Infrastructure.Repositories
{
    public interface IMessageRepository : IRepository<Message>
    {
        Task<StatusCodeHandler> SendMessage(Message message);
    }
}
