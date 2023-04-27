using Microsoft.AspNetCore.Mvc;

namespace SocialNetwork.Api.Subscriptions;

[ApiController]
[Route("[controller]")]
public class SubscriptionsController : ControllerBase
{
    private readonly ISubscriptionRepository _subscriptionRepository;

    public SubscriptionsController(ISubscriptionRepository subscriptionRepository)
    {
        _subscriptionRepository = subscriptionRepository;
    }

    [HttpPost("{user}")]
    public Task Post(string user, SubscriptionDto subscriptionDto)
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