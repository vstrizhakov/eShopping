﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace eShop.Database.Extensions
{
    public static class DependencyInjectionExtensions
    {
        public static IDatabaseDeploymentBuilder<TContext> AddDatabaseDeployment<TContext>(this IServiceCollection services)
            where TContext : DbContext
        {
            services.AddHostedService<DatabaseDeploymentService<TContext>>();

            return new DatabaseDeploymentBuilder<TContext>(services);
        }
    }
}
