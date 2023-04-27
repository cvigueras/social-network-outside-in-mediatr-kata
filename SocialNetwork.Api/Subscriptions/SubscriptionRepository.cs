using Dapper;
using System.Data.SQLite;

namespace SocialNetwork.Api.Subscriptions;

public class SubscriptionRepository : ISubscriptionRepository
{
    private readonly SQLiteConnection _connection;

    public SubscriptionRepository(SQLiteConnection connection)
    {
        _connection = connection;
    }

    public Task Add(Subscription subscription)
    {
        return _connection.ExecuteAsync($"INSERT INTO Subscriptions(Subscriber, User) VALUES('{subscription.Subscriber}', '{subscription.User}')");
    }
}