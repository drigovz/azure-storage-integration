using MediatR;

namespace AzureStorage.Application.Core.Customers.Queries
{
    public class GetCustomerByIdQuery : IRequest<ResponseCommand>
    {
        public int Id { get; set; }
    }
}
