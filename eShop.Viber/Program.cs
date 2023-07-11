using eShop.Bots.Common.Extensions;
using eShop.Viber.DbContexts;
using eShop.Viber.MessageHandlers;
using eShop.Viber.Repositories;
using eShop.ViberBot;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using eShop.RabbitMq.Extensions;
using eShop.Messaging.Extensions;
using eShop.Viber.Services;
using eShop.Common.Extensions;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Newtonsoft.Json.Converters;

namespace eShop.Viber
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers()
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                    options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                    options.SerializerSettings.Converters.Add(new StringEnumConverter());
                });

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<ViberDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.Configure<ViberBotConfiguration>(builder.Configuration.GetSection("ViberBot"));

            builder.Services.AddHttpClient("Viber")
                .AddTypedClient<IViberBotClient>((httpClient, serviceProvider) =>
                {
                    var configuration = serviceProvider.GetRequiredService<IOptions<ViberBotConfiguration>>();
                    var options = new ViberBotClientOptions(configuration.Value.Token);
                    return new ViberBotClient(options, httpClient);
                });

            builder.Services.AddHostedService<ViberBotConfigurationService>();

            builder.Services.AddBotContextConverter();

            builder.Services.AddScoped<IViberUserRepository, ViberUserRepository>();

            builder.Services.AddRabbitMqProducer();
            builder.Services.AddRabbitMqMessageHandler();

            builder.Services.AddScoped<ViberUserCreateAccountUpdateMessageHandler>();
            builder.Services.AddScoped<BroadcastCompositionToViberMessageHandler>();

            builder.Services.AddPublicUriBuilder(options => builder.Configuration.Bind("PublicUri", options));

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
                {
                    options.Authority = "https://localhost:7000";
                    options.Audience = "api";
                });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}