using Moq;
using System.Linq.Expressions;
using WebAPI.Entities;
using WebAPI.Infrastructure.Repositories;
using WebAPI.Infrastructure.Services;

namespace xUnitTests.Backend
{
    public class MessageTests
    {
        private List<Message> _messages;

        public MessageTests()
        {
            _messages = new List<Message>()
            {
                new Message
                {
                    MessageId = Guid.NewGuid(),
                    Sender = "Kullen12",
                    Reciever = "Masken1",
                    Content = "Testmeddelande 2",
                    DateSent = DateTime.Now
                },
                new Message
                {
                    MessageId = Guid.NewGuid(),
                    Sender = "Rompa23",
                    Reciever = "Masken1",
                    Content = "Testmeddelande 2",
                    DateSent = DateTime.Now
                },
                new Message
                {
                    MessageId = Guid.NewGuid(),
                    Sender = "Masken1",
                    Reciever = "Kullen12",
                    Content = "Testmeddelande 1",
                    DateSent = DateTime.Now
                },
                new Message
                {
                    MessageId = Guid.NewGuid(),
                    Sender = "Rompa23",
                    Reciever = "Kullen12",
                    Content = "Testmeddelande 1",
                    DateSent = DateTime.Now
                },
                new Message
                {
                    MessageId = Guid.NewGuid(),
                    Sender = "Masken1",
                    Reciever = "Rompa23",
                    Content = "Testmeddelande 3",
                    DateSent = DateTime.Now
                },
                new Message
                {
                    MessageId = Guid.NewGuid(),
                    Sender = "Kullen12",
                    Reciever = "Rompa23",
                    Content = "Testmeddelande 3",
                    DateSent = DateTime.Now
                }
            };
        }

        [Theory]
        [InlineData("Masken1")]
        [InlineData("Kullen12")]
        [InlineData("Rompa23")]
        public void ShouldBeAbleToGetMessagesByUsername(string username)
        {
            // Setup
            var messageRepository = new Mock<IMessageRepository>();
            messageRepository.Setup(x => x.Query(It.IsAny<Expression<Func<Message, bool>>>()).Result)
                .Returns(_messages.Where(x => x.Reciever == username).ToList());

            // Act
            var messageService = new MessageService(messageRepository.Object);

            var getMessagesByUsername = messageService.GetMessagesByUsername(username).Result;

            // Assert
            Assert.True(getMessagesByUsername.All(x => x.Reciever == username));
        }
    }
}
