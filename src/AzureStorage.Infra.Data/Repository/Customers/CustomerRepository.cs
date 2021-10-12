using AzureStorage.Domain.Entities;
using AzureStorage.Domain.Interfaces;
using AzureStorage.Infra.Data.Context;

namespace AzureStorage.Infra.Data.Repository.Customers
{
    public class CustomerRepository : BaseRepository<Customer, int>, ICustomerRepository
    {
        public CustomerRepository(AppDbContext context) : base(context)
        { }
    }
}
