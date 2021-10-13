using AzureStorage.Domain.Entities;
using AzureStorage.Domain.Interfaces;
using AzureStorage.Domain.Interfaces.Repository;
using AzureStorage.Infra.Data.Context;
using AzureStorage.Infra.Data.Repository;
using AzureStorage.Infra.Data.Repository.CustomerDocuments;
using AzureStorage.Infra.Data.Repository.Customers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AzureStorage.Infra.IoC.DependencyInjection
{
    public static class ConfigureRepository
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(
                options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                builder => builder.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName))
            );

            services.AddScoped(typeof(IBaseRepository<BaseEntity, int>), typeof(BaseRepository<BaseEntity, int>));
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ICustomerDocumentRepository, CustomerDocumentRepository>();

            return services;
        }
    }
}
