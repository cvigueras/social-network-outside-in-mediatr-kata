using MediatR;
using SocialNetwork.Api.Messages.Commands;

namespace SocialNetwork.Api.Subscriptions.Commands;

public class CreateSubscriptionCommandHandler :IRequestHandler<CreateSubscriptionCommand>
{
    private readonly ISubscriptionRepository _subscriptionRepository;

    public CreateSubscriptionCommandHandler(ISubscriptionRepository subscriptionRepository)
    {
        _subscriptionRepository = subscriptionRepository;
    }

    public Task Handle(CreateSubscriptionCommand request, CancellationToken cancellationToken)
    {
        var subscription = new Subscription
        {
            User = request.User,
            Subscriber = request.SubscriptionDto!.Subscriber,
        };

        _subscriptionRepository.Add(subscription);
        return Task.CompletedTask;
    }
}