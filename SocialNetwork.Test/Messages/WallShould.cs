using FluentAssertions;
using NSubstitute;
using NSubstitute.ClearExtensions;
using SocialNetwork.Api.Messages;
using SocialNetwork.Api.Time;

namespace SocialNetwork.Test.Messages
{
    public class WallShould
    {
        private WallController _wallController;
        private IMessagesRepository _messagesRepository;
        private ITime _time;


        [SetUp]
        public void SetUp()
        {
            _messagesRepository = Substitute.For<IMessagesRepository>();
            _wallController = new WallController(_messagesRepository);
            _time = Substitute.For<ITime>();
        }

        [Test]
        public async Task ReturnEmptyMessages()
        {
            var givenMessage = Enumerable.Empty<Message>();
            _messagesRepository.GetByAuthorAndSubscriptions("Alice").Returns(givenMessage);

            var result = await _wallController.Get("Alice");

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

            var result = await _messagesRepository.GetByAuthorAndSubscriptions("Alice");
            result.Should().BeEquivalentTo(givenMessage);
        }
    }
}
