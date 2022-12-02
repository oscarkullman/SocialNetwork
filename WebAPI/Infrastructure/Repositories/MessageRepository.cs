using SocialNetwork.Classes;
using WebAPI.Data;
using WebAPI.Entities;
using WebAPI.Repositories;

namespace WebAPI.Infrastructure.Repositories
{
    public class MessageRepository : Repository<Message>, IMessageRepository
    {
        private readonly IUnitOfWork _unitOfWork;
        
        public MessageRepository(
            DataContext context,
            IUnitOfWork unitOfWork) 
            : base(context) 
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<StatusCodeHandler> SendMessage(Message message)
        {
            await _context.AddAsync(message);
            await _unitOfWork.SaveChangesAsync();

            return new StatusCodeHandler(200, $"Message to {message.Reciever} was sent successfully.");
        }
    }
}
