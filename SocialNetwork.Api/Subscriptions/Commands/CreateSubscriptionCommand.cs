using MediatR;

namespace SocialNetwork.Api.Subscriptions.Commands;

public class CreateSubscriptionCommand : IRequest
{
    public CreateSubscriptionCommand(string user, SubscriptionDto subscriptionDto)
    {
        User = user;
        SubscriptionDto = subscriptionDto;

    }
    public string? User { get; set; }
    public SubscriptionDto? SubscriptionDto { get; set; }
}