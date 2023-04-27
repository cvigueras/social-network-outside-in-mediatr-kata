using FluentAssertions;
using NSubstitute;
using SocialNetwork.Api.Messages;
using SocialNetwork.Api.Messages.Commands;
using SocialNetwork.Api.Messages.Queries;
using SocialNetwork.Api.Time;

namespace SocialNetwork.Test.Messages
{
    public class GetMessagesByAuthorQueryHandlerShould
    {
        private IMessagesRepository _messagesRepository;
        private GetMessagesByAuthorQueryHandler _getMessagesByAuthorQueryHandler;
        private CreateMessageCommandHandler _createMessageCommandHandler;
        private ITime _time;

        [SetUp]
        public void SetUp()
        {
            _time = Substitute.For<ITime>();
            _messagesRepository = Substitute.For<IMessagesRepository>();
            _getMessagesByAuthorQueryHandler = new GetMessagesByAuthorQueryHandler(_messagesRepository);
            _createMessageCommandHandler = new CreateMessageCommandHandler(_messagesRepository, _time);
        }

        [Test]
        public async Task GetEmptyWhenGetOwnMessages()
        {
            var getMessagesByAuthorQuery = new GetMessagesByAuthorQuery("Alice");
            _messagesRepository.GetByAuthor("Alice").Returns(Enumerable.Empty<Message>());

            var result = await _getMessagesByAuthorQueryHandler.Handle(getMessagesByAuthorQuery, default);

            result.Should().BeEmpty();
        }
    }
}