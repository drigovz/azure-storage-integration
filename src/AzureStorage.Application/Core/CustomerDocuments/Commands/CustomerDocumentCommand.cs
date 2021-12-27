using AzureStorage.Domain.Entities.Enums;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace AzureStorage.Application.Core.CustomerDocuments.Commands
{
    public class CustomerDocumentCommand : IRequest<BaseResponse>
    {
        public DocumentType DocumentType { get; set; }
        public IFormFile File { get; set; }
        public int CustomerId { get; set; }
    }
}
