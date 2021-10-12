using AzureStorage.Domain.Entities;
using MediatR;

namespace AzureStorage.Application.Core.Customers.Commands
{
    public class CustomerCommand : IRequest<Customer>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Identity { get; set; }
    }
}
