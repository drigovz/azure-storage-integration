using AzureStorage.Domain.Entities;
using AzureStorage.Domain.Interfaces.Repository;

namespace AzureStorage.Domain.Interfaces
{
    public interface ICustomerRepository : IBaseRepository<Customer, int>
    { }
}
