using AzureStorage.Application.Core.Customers.Commands;
using AzureStorage.Application.Notifications;
using AzureStorage.Domain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AzureStorage.Application.Core.Customers.Handlers.Commands
{
    public class CustomerUpdateCommandHandler : IRequestHandler<CustomerUpdateCommand, BaseResponse>
    {
        private readonly ICustomerRepository _repository;
        private readonly NotificationContext _notification;

        public CustomerUpdateCommandHandler(ICustomerRepository repository, NotificationContext notification)
        {
            _repository = repository;
            _notification = notification;
        }

        public async Task<BaseResponse> Handle(CustomerUpdateCommand request, CancellationToken cancellationToken)
        {
            var client = await _repository.GetByIdAsync(request.Id);
            if (client == null)
                return new BaseResponse
                {
                    Notifications = _notification.AddNotification("Error", $"Customer with id {request.Id} not found!"),
                };

            client.UpdateCustomer(request.FirstName, request.LastName, request.Email, request.Identity);
            await _repository.UpdateAsync(client);

            return new BaseResponse
            {
                Result = client,
                Notifications = _notification.AddNotification("Success", $"Customer with id {request.Id} update succesfull!"),
            };
        }
    }
}
