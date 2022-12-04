using SocialNetwork.Classes;
using SocialNetwork.Classes.Models;
using WebAPI.Entities;
using WebAPI.Infrastructure.Repositories;
using WebAPI.Repositories;

namespace WebAPI.Infrastructure.Services
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository _messageRepository;
        
        public MessageService(
            IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        public async Task<StatusCodeHandler> SendMessage(MessageModel messageModel)
        {
            var message = new Message
            {
                MessageId = Guid.NewGuid(),
                Sender = messageModel.Sender,
                Reciever = messageModel.Reciever,
                Content = messageModel.Content,
                DateSent = DateTime.Now
            };

            var result = await _messageRepository.SendMessage(message);

            return result;
        }

        public async Task<ICollection<Message>> GetMessagesByUsername(string username)
        {
            var messages = await _messageRepository.Query(x => x.Reciever == username);

            return messages;
        }
    }
}
