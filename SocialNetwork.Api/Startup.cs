using SocialNetwork.Api.Data;
using SocialNetwork.Api.Messages.Repositories;
using SocialNetwork.Api.Subscriptions.Repositories;
using SocialNetwork.Api.Time;
using System.Data.SQLite;

namespace SocialNetwork.Api
{
    public class Startup
    {
        public IConfiguration ConfigRoot
        {
            get;
        }

        public Startup(IConfiguration configuration)
        {
            ConfigRoot = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            DataBase.Create();
            services.AddMediatR(configuration => configuration.RegisterServicesFromAssembly(typeof(Program).Assembly));
            services.AddScoped(_ => new SQLiteConnection("Data Source=./SocialNetwork.db"));
            services.AddScoped<IMessagesRepository, MessageRepository>();
            services.AddScoped<ISubscriptionRepository, SubscriptionRepository>();
            services.AddSingleton<ITime, Time.Time>();
        }

        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}