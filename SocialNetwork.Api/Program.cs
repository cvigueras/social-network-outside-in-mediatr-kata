using SocialNetwork.Api;

var builder = WebApplication.CreateBuilder(args);
var startup = new Startup(builder.Configuration);
startup.ConfigureServices(builder.Services);
var app = builder.Build();
startup.Configure(app, builder.Environment);

namespace SocialNetwork.Api
{
    public partial class Program
    {

    }
}
