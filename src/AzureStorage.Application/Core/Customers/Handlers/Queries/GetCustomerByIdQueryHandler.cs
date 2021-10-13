using AzureStorage.Application.Core.Customers.Queries;
using AzureStorage.Application.Notifications;
using AzureStorage.Domain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AzureStorage.Application.Core.Customers.Handlers.Queries
{
    public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, BaseResponse>
    {
        private readonly ICustomerRepository _repository;
        private readonly NotificationContext _notification;

        public GetCustomerByIdQueryHandler(ICustomerRepository repository, NotificationContext notification)
        {
            _repository = repository;
            _notification = notification;
        }

        public async Task<BaseResponse> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            var client = await _repository.GetByIdAsync(request.Id);
            if (client == null)
                return new BaseResponse
                {
                    Notifications = _notification.AddNotification("Error", $"Customer with id {request.Id} not found!"),
                };

            return new BaseResponse
            {
                Result = client,
            };
        }
    }
}
