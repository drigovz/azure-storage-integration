using Azure.Storage.Blobs;
using AzureStorage.Application.Services;
using AzureStorage.Domain.Interfaces.Services;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace AzureStorage.Infra.IoC.DependencyInjection
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            var handlers = AppDomain.CurrentDomain.Load("AzureStorage.Application");
            services.AddMediatR(handlers);

            var blobConnection = configuration.GetConnectionString("StorageConnection");
            services.AddSingleton(x => new BlobServiceClient(blobConnection));
            services.AddSingleton<IStorageService, StorageService>();

            return services;
        }
    }
}
