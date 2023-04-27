using NSubstitute;
using SocialNetwork.Api.Subscriptions;

namespace SocialNetwork.Test.Subscriptions
{
    public class SubscriptionsControllerShould
    {
        private ISubscriptionRepository _subscriptionRepository;

        [SetUp]
        public void SetUp()
        {
            _subscriptionRepository = Substitute.For<ISubscriptionRepository>();
        }

        [Test]
        public void SubscribeUserToOtherUser()
        {
            var givenSubscription = new SubscriptionDto
            {
                Subscriber = "Charlie",
            };

            var subscriptionController = new SubscriptionsController(_subscriptionRepository);
            subscriptionController.Post("Alice", givenSubscription);

            var expectedSubscription = new Subscription
            {
                User = "Alice",
                Subscriber = "Charlie",

            };
            _subscriptionRepository.Received().Add(expectedSubscription);
        }
    }
}