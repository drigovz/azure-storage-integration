using AzureStorage.Application.Core.Customers.Commands;
using AzureStorage.Application.Notifications;
using AzureStorage.Domain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AzureStorage.Application.Core.Customers.Handlers.Commands
{
    public class CustomerRemoveCommandHandler : IRequestHandler<CustomerRemoveCommand, ResponseCommand>
    {
        private readonly ICustomerRepository _repository;
        private readonly NotificationContext _notification;

        public CustomerRemoveCommandHandler(ICustomerRepository repository, NotificationContext notification)
        {
            _repository = repository;
            _notification = notification;
        }

        public async Task<ResponseCommand> Handle(CustomerRemoveCommand request, CancellationToken cancellationToken)
        {
            var client = await _repository.GetByIdAsync(request.Id);
            if (client == null)
                return new ResponseCommand
                {
                    Notifications = _notification.AddNotification("Error", $"Customer with id {request.Id} not found!"),
                };

            await _repository.RemoveAsync(request.Id);
            return new ResponseCommand
            {
                Notifications = _notification.AddNotification("Success", "Customer deleted succesfull!"),
            };
        }
    }
}
