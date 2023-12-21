using Ocelot.DependencyInjection;
using Ocelot.Middleware;

namespace eShop.Gateway
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Configuration.AddJsonFile("ocelot.json", false, true);
            builder.Configuration.AddJsonFile($"ocelot.{builder.Environment.EnvironmentName}.json", true, true);

            builder.Services.AddOcelot();
            builder.Services.AddSignalR();

            var app = builder.Build();

            app.UseHttpsRedirection();

            app.UseWebSockets();

            await app.UseOcelot();

            await app.RunAsync();
        }
    }
}