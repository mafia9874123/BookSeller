using BookStore.Services.Interfaces;
using BookStore.Services.Services;
using BookStoreAPI.Configurations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
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
            serviceCollection.AddScoped(typeof(IBookService), typeof(BookService));
            return serviceCollection;
        }

        public static IServiceCollection AddConfigurations(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.Configure<OrderConfiguration>(configuration.GetSection(nameof(OrderConfiguration)));
            serviceCollection.Configure<StoreConfiguration>(configuration.GetSection(nameof(StoreConfiguration)));
            return serviceCollection;
        }
        public static void AddSwaggerExtension(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "BookStore.ApiApp",
                    Description = "This Api will be responsible for overall data distribution and authorization. <br /> This Application create use ASP.NET Core WebAPI Clean Architecture extension for Visual Studio "
                });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    Description = "Input your Bearer token in this format - Bearer {your token here} to access this API",
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer",
                            },
                            Scheme = "Bearer",
                            Name = "Bearer",
                            In = ParameterLocation.Header,
                        }, new List<string>()
                    },
                });
            });
        }
    }
}
