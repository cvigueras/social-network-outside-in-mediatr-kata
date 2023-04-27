namespace SocialNetwork.Api.Subscriptions;

public interface ISubscriptionRepository
{
    Task Add(Subscription subscription);
}