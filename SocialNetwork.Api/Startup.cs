using System.Data.SQLite;
using SocialNetwork.Api.Data;
using SocialNetwork.Api.Messages;
using SocialNetwork.Api.Subscriptions;
using SocialNetwork.Api.Time;

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
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            
            DataBase.Create();

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