using MediatR;

namespace AzureStorage.Application.Core.Customers.Commands
{
    public class CustomerRemoveCommand : IRequest<ResponseCommand>
    {
        public int Id { get; set; }
    }
}
