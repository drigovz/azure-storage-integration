using AzureStorage.Application.Core.Customers.Commands;
using AzureStorage.Application.Notifications;
using AzureStorage.Domain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AzureStorage.Application.Core.Customers.Handlers.Commands
{
    public class CustomerUpdateCommandHandler : IRequestHandler<CustomerUpdateCommand, ResponseCommand>
    {
        private readonly ICustomerRepository _repository;
        private readonly NotificationContext _notification;

        public CustomerUpdateCommandHandler(ICustomerRepository repository, NotificationContext notification)
        {
            _repository = repository;
            _notification = notification;
        }

        public async Task<ResponseCommand> Handle(CustomerUpdateCommand request, CancellationToken cancellationToken)
        {
            var client = await _repository.GetByIdAsync(request.Id);
            if (client == null)
                return new ResponseCommand
                {
                    Notifications = _notification.AddNotification("Error", $"Client with id {request.Id} not found!"),
                };

            client.UpdateCustomer(request.FirstName, request.LastName, request.Email, request.Identity);
            await _repository.UpdateAsync(client);

            return new ResponseCommand
            {
                Result = client,
                Notifications = _notification.AddNotification("Success", $"Client with id {request.Id} update succesfull!"),
            };
        }
    }
}
