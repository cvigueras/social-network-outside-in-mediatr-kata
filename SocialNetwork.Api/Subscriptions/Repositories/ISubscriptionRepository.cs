using SocialNetwork.Api.Subscriptions.Models;

namespace SocialNetwork.Api.Subscriptions.Repositories;

public interface ISubscriptionRepository
{
    Task Add(Subscription subscription);
}