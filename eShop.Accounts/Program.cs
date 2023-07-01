using eShop.Accounts.DbContexts;
using eShop.Accounts.MessageHandlers;
using eShop.Accounts.Repositories;
using eShop.Messaging.Extensions;
using eShop.RabbitMq.Extensions;
using Microsoft.EntityFrameworkCore;

namespace eShop.Accounts
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers()
                .AddNewtonsoftJson();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddRabbitMqProducer();
            builder.Services.AddRabbitMqMessageHandler();

            builder.Services.AddScoped<TelegramUserCreateAccountRequestMessageHandler>();
            builder.Services.AddScoped<ViberUserCreateAccountRequestMessageHandler>();

            builder.Services.AddDbContext<AccountsDbContext>(options
                => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddScoped<IAccountRepository, AccountRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
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