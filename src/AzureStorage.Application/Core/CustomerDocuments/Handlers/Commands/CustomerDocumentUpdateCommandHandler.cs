using AzureStorage.Application.Core.CustomerDocuments.Commands;
using AzureStorage.Application.Notifications;
using AzureStorage.Domain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AzureStorage.Application.Core.CustomerDocuments.Handlers.Commands
{
    public class CustomerDocumentUpdateCommandHandler : IRequestHandler<CustomerDocumentUpdateCommand, BaseResponse>
    {
        private readonly ICustomerDocumentRepository _repository;
        private readonly NotificationContext _notification;

        public CustomerDocumentUpdateCommandHandler(ICustomerDocumentRepository repository, NotificationContext notification)
        {
            _repository = repository;
            _notification = notification;
        }

        public async Task<BaseResponse> Handle(CustomerDocumentUpdateCommand request, CancellationToken cancellationToken)
        {
            //var document = await _repository.GetByIdAsync(request.Id);
            //if (document == null)
            //    return new BaseResponse
            //    {
            //        Notifications = _notification.AddNotification("Error", $"Document with id {request.Id} not found!"),
            //    };

            //document.UpdateDocument(request.DocumentType, request.Url, request.File, request.FileName, request.CustomerId);
            //await _repository.UpdateAsync(document);

            return new BaseResponse
            {
                Result = "",
                //Notifications = _notification.AddNotification("Success", $"Document with id {request.Id} update succesfull!"),
            };
        }
    }
}
