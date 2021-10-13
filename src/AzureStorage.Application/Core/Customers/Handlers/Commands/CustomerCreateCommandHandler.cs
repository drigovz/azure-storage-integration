using AzureStorage.Application.Core.Customers.Commands;
using AzureStorage.Application.Notifications;
using AzureStorage.Domain.Entities;
using AzureStorage.Domain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AzureStorage.Application.Core.Customers.Handlers.Commands
{
    public class CustomerCreateCommandHandler : IRequestHandler<CustomerCreateCommand, ResponseCommand>
    {
        private readonly ICustomerRepository _repository;
        private readonly NotificationContext _notification;

        public CustomerCreateCommandHandler(ICustomerRepository repository, NotificationContext notification)
        {
            _repository = repository;
            _notification = notification;
        }

        public async Task<ResponseCommand> Handle(CustomerCreateCommand request, CancellationToken cancellationToken)
        {
            var client = new Customer(request.FirstName, request.LastName, request.Email, request.Identity);
            if (!client.Valid)
            {
                _notification.AddNotifications(client.ValidationResult);

                return new ResponseCommand
                {
                    Notifications = _notification.Notifications,
                };
            }

            var result = await _repository.AddAsync(client);
            if (result == null)
            {
                _notification.AddNotification("Error", "Error When try to add new client!");

                return new ResponseCommand { Notifications = _notification.Notifications, };
            }

            await _repository.Rollback();

            return new ResponseCommand { Result = result, };
        }
    }
}
