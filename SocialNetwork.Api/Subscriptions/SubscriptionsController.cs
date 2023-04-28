using MediatR;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Api.Subscriptions.Commands;

namespace SocialNetwork.Api.Subscriptions;

[ApiController]
[Route("[controller]")]
public class SubscriptionsController : ControllerBase
{
    private readonly ISender _sender;

    public SubscriptionsController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost("{user}")]
    public Task Post(string user, SubscriptionDto subscriptionDto)
    {
        return _sender.Send(new CreateSubscriptionCommand(user,subscriptionDto));
    }
}