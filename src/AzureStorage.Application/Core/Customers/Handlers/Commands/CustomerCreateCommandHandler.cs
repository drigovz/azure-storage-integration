using AzureStorage.Application.Core.Customers.Commands;
using AzureStorage.Application.Notifications;
using AzureStorage.Domain.Entities;
using AzureStorage.Domain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AzureStorage.Application.Core.Customers.Handlers.Commands
{
    public class CustomerCreateCommandHandler : IRequestHandler<CustomerCreateCommand, BaseResponse>
    {
        private readonly ICustomerRepository _repository;
        private readonly NotificationContext _notification;

        public CustomerCreateCommandHandler(ICustomerRepository repository, NotificationContext notification)
        {
            _repository = repository;
            _notification = notification;
        }

        public async Task<BaseResponse> Handle(CustomerCreateCommand request, CancellationToken cancellationToken)
        {
            var client = new Customer(request.FirstName, request.LastName, request.Email, request.Identity);
            if (!client.Valid)
            {
                _notification.AddNotifications(client.ValidationResult);

                return new BaseResponse
                {
                    Notifications = _notification.Notifications,
                };
            }

            var result = await _repository.AddAsync(client);
            if (result == null)
            {
                _notification.AddNotification("Error", "Error When try to add new customer!");

                return new BaseResponse { Notifications = _notification.Notifications, };
            }

            return new BaseResponse { Result = result, };
        }
    }
}
