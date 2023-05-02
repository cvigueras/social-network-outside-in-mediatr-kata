using NSubstitute;
using SocialNetwork.Api.Messages.Queries;
using SocialNetwork.Api.Messages;
using SocialNetwork.Api.Time;
using SocialNetwork.Api.Messages.Commands;

namespace SocialNetwork.Test.Messages
{
    public class CreateMessageCommandShould
    {
        private IMessagesRepository _messagesRepository;
        private CreateMessageCommandHandler _createMessageCommandHandler;
        private ITime _time;

        [SetUp]
        public void SetUp()
        {
            _time = Substitute.For<ITime>();
            _messagesRepository = Substitute.For<IMessagesRepository>();
            _createMessageCommandHandler = new CreateMessageCommandHandler(_messagesRepository, _time);
        }

        [Test]
        public async Task PostMessage()
        {
            _time.Timestamp().Returns(new DateTime(2023, 4, 18, 14, 35, 0));
            var givenMessage = new MessageDto
            {
                Post = "Hello everyone",
            };
            var createMessageCommand = new CreateMessageCommand(givenMessage, "Alice");

            await _createMessageCommandHandler.Handle(createMessageCommand, default);

            var expectedMessage = new Message
            {
                Timestamp = _time.Timestamp(),
                Post = "Hello everyone",
                Author = "Alice",
            };
            await _messagesRepository.Received().Add(expectedMessage);
        }
    }
}
