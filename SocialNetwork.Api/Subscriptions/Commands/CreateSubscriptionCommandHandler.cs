namespace SocialNetwork.Api.Subscriptions.Commands;

public class CreateSubscriptionCommandHandler
{
    private readonly ISubscriptionRepository _subscriptionRepository;

    public CreateSubscriptionCommandHandler(ISubscriptionRepository subscriptionRepository)
    {
        _subscriptionRepository = subscriptionRepository;
    }

    public Task Handle(string user, SubscriptionDto subscriptionDto)
    {
        var subscription = new Subscription
        {
            User = user,
            Subscriber = subscriptionDto.Subscriber,
        };

        _subscriptionRepository.Add(subscription);
        return Task.CompletedTask;
    }
}