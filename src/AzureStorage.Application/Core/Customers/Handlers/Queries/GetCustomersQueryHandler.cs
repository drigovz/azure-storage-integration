using AzureStorage.Application.Core.Customers.Queries;
using AzureStorage.Application.Notifications;
using AzureStorage.Domain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AzureStorage.Application.Core.Customers.Handlers.Queries
{
    public class GetCustomersQueryHandler : IRequestHandler<GetCustomersQuery, BaseResponse>
    {
        private readonly ICustomerRepository _repository;
        private readonly NotificationContext _notification;

        public GetCustomersQueryHandler(ICustomerRepository repository, NotificationContext notification)
        {
            _repository = repository;
            _notification = notification;
        }

        public async Task<BaseResponse> Handle(GetCustomersQuery request, CancellationToken cancellationToken) =>
            new BaseResponse { Result = await _repository.GetAsync(), };
    }
}
