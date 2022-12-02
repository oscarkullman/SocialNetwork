using SocialNetwork.Classes;
using SocialNetwork.Classes.Models;
using WebAPI.Entities;

namespace WebAPI.Infrastructure.Services
{
    public interface IMessageService
    {
        Task<StatusCodeHandler> SendMessage(MessageModel messageModel);

        Task<ICollection<Message>> GetMessagesByUsername(string username);
    }
}
