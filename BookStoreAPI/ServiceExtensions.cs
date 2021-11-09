using BookStoreAPI.Configurations;
using BookStoreAPI.Orchestrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreAPI
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddOrchestrators(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped(typeof(BookOrchestrator));
            return serviceCollection;
        }

        public static IServiceCollection AddConfigurations(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.Configure<OrderConfiguration>(configuration.GetSection(nameof(OrderConfiguration)));
            serviceCollection.Configure<StoreConfiguration>(configuration.GetSection(nameof(StoreConfiguration)));
            return serviceCollection;
        }
    }
}
