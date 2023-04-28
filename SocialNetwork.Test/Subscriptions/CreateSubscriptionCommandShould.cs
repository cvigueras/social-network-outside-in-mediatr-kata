using NSubstitute;
using SocialNetwork.Api.Subscriptions;
using SocialNetwork.Api.Subscriptions.Commands;

namespace SocialNetwork.Test.Subscriptions
{
    public class CreateSubscriptionCommandShould
    {
        private ISubscriptionRepository _subscriptionRepository;
        private CreateSubscriptionCommandHandler _commandHandler;

        [SetUp]
        public void SetUp()
        {
            _subscriptionRepository = Substitute.For<ISubscriptionRepository>();
            _commandHandler = new CreateSubscriptionCommandHandler(_subscriptionRepository);
        }

        [Test]
        public void SubscribeUserToOtherUser()
        {
            var givenSubscription = new SubscriptionDto
            {
                Subscriber = "Charlie",
            };

            var subscriptionMessageCommand = new CreateSubscriptionCommand("Alice", givenSubscription);
            _commandHandler.Handle(subscriptionMessageCommand, default);

            var expectedSubscription = new Subscription
            {
                User = "Alice",
                Subscriber = "Charlie",

            };
            _subscriptionRepository.Received().Add(expectedSubscription);
        }
    }
}