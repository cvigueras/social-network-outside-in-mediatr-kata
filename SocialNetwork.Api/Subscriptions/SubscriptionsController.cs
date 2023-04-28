using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Api.Subscriptions.Commands;

namespace SocialNetwork.Api.Subscriptions;

[ApiController]
[Route("[controller]")]
public class SubscriptionsController : ControllerBase
{
    private readonly ISubscriptionRepository _subscriptionRepository;
    private readonly CreateSubscriptionCommandHandler _createSubscriptionCommandHandler;

    public SubscriptionsController(ISubscriptionRepository subscriptionRepository)
    {
        _subscriptionRepository = subscriptionRepository;
        _createSubscriptionCommandHandler = new CreateSubscriptionCommandHandler(_subscriptionRepository);
    }

    [HttpPost("{user}")]
    public Task Post(string user, SubscriptionDto subscriptionDto)
    {
        return _createSubscriptionCommandHandler.Handle(new CreateSubscriptionCommand(user,subscriptionDto), default);
    }
}