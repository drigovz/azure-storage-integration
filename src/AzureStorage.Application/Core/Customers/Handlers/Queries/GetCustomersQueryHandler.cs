using AzureStorage.Application.Core.Customers.Queries;
using AzureStorage.Application.Notifications;
using AzureStorage.Domain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AzureStorage.Application.Core.Customers.Handlers.Queries
{
    public class GetCustomersQueryHandler : IRequestHandler<GetCustomersQuery, ResponseCommand>
    {
        private readonly ICustomerRepository _repository;
        private readonly NotificationContext _notification;

        public GetCustomersQueryHandler(ICustomerRepository repository, NotificationContext notification)
        {
            _repository = repository;
            _notification = notification;
        }

        public async Task<ResponseCommand> Handle(GetCustomersQuery request, CancellationToken cancellationToken) =>
            new ResponseCommand { Result = await _repository.GetAsync(), };
    }
}
