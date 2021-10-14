using AzureStorage.Application.Core.CustomerDocuments.Commands;
using AzureStorage.Application.Notifications;
using AzureStorage.Domain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AzureStorage.Application.Core.CustomerDocuments.Handlers.Commands
{
    public class CustomerDocumentRemoveCommandHandler : IRequestHandler<CustomerDocumentRemoveCommand, BaseResponse>
    {
        private readonly ICustomerDocumentRepository _repository;
        private readonly NotificationContext _notification;

        public CustomerDocumentRemoveCommandHandler(ICustomerDocumentRepository repository, NotificationContext notification)
        {
            _repository = repository;
            _notification = notification;
        }

        public async Task<BaseResponse> Handle(CustomerDocumentRemoveCommand request, CancellationToken cancellationToken)
        {
            var document = await _repository.GetByIdAsync(request.Id);
            if (document == null)
                return new BaseResponse
                {
                    Notifications = _notification.AddNotification("Error", $"Document with id {request.Id} not found!"),
                };

            await _repository.RemoveAsync(request.Id);
            return new BaseResponse
            {
                Notifications = _notification.AddNotification("Success", "Document deleted succesfull!"),
            };
        }
    }
}
