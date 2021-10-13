using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace AzureStorage.Infra.IoC.DependencyInjection
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            var handlers = AppDomain.CurrentDomain.Load("AzureStorage.Application");
            services.AddMediatR(handlers);

            return services;
        }
    }
}
