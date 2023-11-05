﻿using Microsoft.Extensions.DependencyInjection;

namespace eShop.ViberBot.Framework.Extensions
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddViberFramework<TContextStore>(this IServiceCollection services)
            where TContextStore : class, IContextStore
        {
            services.AddScoped<IPipeline, DefaultPipeline>();

            services.AddScoped<IContextStore, TContextStore>();
            //services.AddScoped<ITelegramViewRunner, TelegramViewRunner>();
            services.AddScoped<ICallbackHandler, DefaultCallbackHandler>();

            return services;
        }
    }
}