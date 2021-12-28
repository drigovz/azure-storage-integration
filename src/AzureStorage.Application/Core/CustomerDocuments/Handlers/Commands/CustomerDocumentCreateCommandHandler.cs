using AzureStorage.Application.Core.CustomerDocuments.Commands;
using AzureStorage.Application.Core.Customers.Queries;
using AzureStorage.Application.Notifications;
using AzureStorage.Domain.Interfaces.Services;
using AzureStorage.Domain.Entities;
using AzureStorage.Domain.Interfaces;
using MediatR;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace AzureStorage.Application.Core.CustomerDocuments.Handlers.Commands
{
    public class CustomerDocumentCreateCommandHandler : IRequestHandler<CustomerDocumentCreateCommand, BaseResponse>
    {
        private readonly IMediator _mediator;
        private readonly ICustomerDocumentRepository _repository;
        private readonly IStorageService _service;
        private readonly NotificationContext _notification;

        public CustomerDocumentCreateCommandHandler(ICustomerDocumentRepository repository, NotificationContext notification, IStorageService service, IMediator mediator)
        {
            _repository = repository;
            _notification = notification;
            _service = service;
            _mediator = mediator;
        }

        public async Task<BaseResponse> Handle(CustomerDocumentCreateCommand request, CancellationToken cancellationToken)
        {
            string containerName = await _service.CreateBlobContainer($"customer-{request.CustomerId}"),
                   fileName = Guid.NewGuid().ToString() + Path.GetExtension(request.File.FileName);

            var uploadResult = await _service.UploadFileBlob(fileName, request.File, containerName);
            if (uploadResult == null)
                _notification.AddNotification("Error", "Error When try to upload files on storage!");

            #region [+] Get Customer
            var customer = _mediator.Send(new GetCustomerByIdQuery { Id = request.CustomerId })?.Result?.Result;
            if (customer == null)
            {
                _notification.AddNotification("Error", "Error When try to get customer!");
                return new BaseResponse { Notifications = _notification.Notifications, };
            }
            #endregion

            var length = request.File.Length;
            var contentType = request.File.ContentType;
            //var file = request.File.ContentType; //byte[]

            var document = new CustomerDocument(request.DocumentType, uploadResult.Url, uploadResult.Name, customer);
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
