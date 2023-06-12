using FluentAssertions;
using NSubstitute;
using SocialNetwork.Api.Messages.Models;
using SocialNetwork.Api.Messages.Queries;
using SocialNetwork.Api.Messages.Repositories;
using SocialNetwork.Api.Time;

namespace SocialNetwork.Test.Messages
{
    public class GetWallByAuthorQueryHandlerShould
    {
        private IMessagesRepository _messagesRepository;
        private GetWallByAuthorQueryHandler _getWallByAuthorQueryHandler;
        private ITime _time;


        [SetUp]
        public void SetUp()
        {
            _messagesRepository = Substitute.For<IMessagesRepository>();
            _getWallByAuthorQueryHandler = new GetWallByAuthorQueryHandler(_messagesRepository);
            _time = Substitute.For<ITime>();
        }

        [Test]
        public async Task ReturnEmptyMessages()
        {
            var givenMessage = Enumerable.Empty<Message>();
            _messagesRepository.GetByAuthorAndSubscriptions("Alice").Returns(givenMessage);

            var getWallByAuthorQuery = new GetWallByAuthorQuery("Alice");
            var result = await _getWallByAuthorQueryHandler.Handle(getWallByAuthorQuery, default);

            result.Should().BeEmpty();
        }

        [Test]
        public async Task GetOneMessageFromOwnAndSubscription()
        {
            var givenMessage = new List<Message>
            {
                new()
                {
                    Post = "Hello everyone.",
                    Author = "Alice",
                    Timestamp = _time.Timestamp(),
                }
            };

            _messagesRepository.GetByAuthorAndSubscriptions("Alice").Returns(givenMessage);
            var getWallByAuthorQuery = new GetWallByAuthorQuery("Alice");
            var result = await _getWallByAuthorQueryHandler.Handle(getWallByAuthorQuery, default);

            result.Should().BeEquivalentTo(givenMessage);
        }
    }
}