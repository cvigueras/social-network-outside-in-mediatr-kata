using FluentAssertions;
using NSubstitute;
using SocialNetwork.Api.Messages;
using SocialNetwork.Api.Messages.Queries;
using SocialNetwork.Api.Time;

namespace SocialNetwork.Test.Messages
{
    public class GetMessagesByAuthorQueryHandlerShould
    {
        private MessagesController _timelineController;
        private IMessagesRepository _messagesRepository;
        private GetMessagesByAuthorQueryHandler _getMessagesByAuthorQueryHandlerShould;
        private ITime _time;

        [SetUp]
        public void SetUp()
        {
            _messagesRepository = Substitute.For<IMessagesRepository>();
            _getMessagesByAuthorQueryHandlerShould = new GetMessagesByAuthorQueryHandler(_messagesRepository);
            _time = Substitute.For<ITime>();
            _timelineController = new MessagesController(_messagesRepository, _time);
        }

        [Test]
        public async Task GetEmptyWhenGetOwnMessages()
        {
            var getMessagesByAuthorQuery = new GetMessagesByAuthorQuery("Alice");
            _messagesRepository.GetByAuthor("Alice").Returns(Enumerable.Empty<Message>());

            var result = await _getMessagesByAuthorQueryHandlerShould.Handle(getMessagesByAuthorQuery, default);

            result.Should().BeEmpty();
        }

        [Test]
        public void PostMessage()
        {
            _time.Timestamp().Returns(new DateTime(2023, 4, 18, 14, 35, 0));
            var givenMessage = new MessageDto
            {
                Post = "Hello everyone",
            };

            _timelineController.Post("Alice", givenMessage);

            var expectedMessage = new Message
            {
                Timestamp = _time.Timestamp(),
                Post = "Hello everyone",
                Author = "Alice",
            };
            _messagesRepository.Received().Add(expectedMessage);
        }
    }
}