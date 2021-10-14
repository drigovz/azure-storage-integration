using AzureStorage.Application.Core.CustomerDocuments.Commands;
using AzureStorage.Application.Notifications;
using AzureStorage.Domain.Entities;
using AzureStorage.Domain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AzureStorage.Application.Core.CustomerDocuments.Handlers.Commands
{
    public class CustomerDocumentCreateCommandHandler : IRequestHandler<CustomerDocumentCreateCommand, BaseResponse>
    {
        private readonly ICustomerDocumentRepository _repository;
        private readonly NotificationContext _notification;

        public CustomerDocumentCreateCommandHandler(ICustomerDocumentRepository repository, NotificationContext notification)
        {
            _repository = repository;
            _notification = notification;
        }

        public async Task<BaseResponse> Handle(CustomerDocumentCreateCommand request, CancellationToken cancellationToken)
        {
            var document = new CustomerDocument(request.DocumentType, request.Url, request.File, request.FileName, request.CustomerId);
            if (!document.Valid)
            {
                _notification.AddNotifications(document.ValidationResult);

                return new BaseResponse
                {
                    Notifications = _notification.Notifications,
                };
            }

            var result = await _repository.AddAsync(document);
            if (result == null)
            {
                _notification.AddNotification("Error", "Error When try to add new document!");

                return new BaseResponse { Notifications = _notification.Notifications, };
            }

            return new BaseResponse { Result = result, };
        }
    }
}
