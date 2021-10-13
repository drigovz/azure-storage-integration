using MediatR;

namespace AzureStorage.Application.Core.Customers.Commands
{
    public class CustomerRemoveCommand : IRequest<BaseResponse>
    {
        public int Id { get; set; }
    }
}
