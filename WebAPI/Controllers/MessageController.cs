using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Classes;
using SocialNetwork.Classes.Message;
using SocialNetwork.Classes.Models;
using WebAPI.Infrastructure.Services;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/message/")]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;
        private readonly IMapper _mapper;

        public MessageController(
            IMessageService messageService,
            IMapper mapper)
        {
            _messageService = messageService;
            _mapper = mapper;
        }

        [HttpPost("SendMessage")]
        public async Task<ActionResult<StatusCodeHandler>> SendMessage([FromBody]MessageModel messageModel)
        {
            var result = await _messageService.SendMessage(messageModel);

            return Ok(result);
        }

        [HttpGet("GetMessagesByUsername/{username}")]
        public async Task<ActionResult<ICollection<MessageDto>>> GetMessagesByUsername(string username)
        {
            var messages = await _messageService.GetMessagesByUsername(username);

            var mappedMessages = _mapper.Map<List<MessageDto>>(messages);

            return Ok(mappedMessages);
        }
    }
}
