using MediatR;

namespace AzureStorage.Application.Core.Customers.Queries
{
    public class GetCustomerByIdQuery : IRequest<BaseResponse>
    {
        public int Id { get; set; }
    }
}
