using Dapper;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SocialNetwork.Api;
using SocialNetwork.Api.Messages;
using SocialNetwork.Api.Subscriptions;
using System.Data.SQLite;
using SocialNetwork.Api.Time;

namespace SocialNetwork.Test
{
    public class StartupTest: WebApplicationFactory<Program>
    {
        private readonly ITime _time;
        private readonly SQLiteConnection _sqLiteConnection;

        protected override IHost CreateHost(IHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                services.AddSingleton(_time);
                services.AddSingleton(_sqLiteConnection);
                services.AddSingleton<IMessagesRepository, MessageRepository>();
                services.AddSingleton<ISubscriptionRepository, SubscriptionRepository>();
            });

            return base.CreateHost(builder);
        }

        public StartupTest(ITime time)
        {
            _time = time;

            _sqLiteConnection = new SQLiteConnection("Data Source=:memory:");

            _sqLiteConnection.Open();

            _sqLiteConnection.Execute(@"Create Table if not exists Messages(
                Author VARCHAR(100) NOT NULL,
                Post VARCHAR(144) NOT NULL,
                Timestamp DATETIME NOT NULL)");

            _sqLiteConnection.Execute(@"Create Table if not exists Subscriptions(
                User VARCHAR(100) NOT NULL,
                Subscriber VARCHAR(100) NOT NULL)");
        }
    }
}