using AzureStorage.Domain.Entities.Enums;
using MediatR;

namespace AzureStorage.Application.Core.CustomerDocuments.Commands
{
    public class CustomerDocumentCommand : IRequest<BaseResponse>
    {
        public DocumentType DocumentType { get; set; }
        public string Url { get; set; }
        public byte[] File { get; set; }
        public string FileName { get; set; }
        public int CustomerId { get; set; }
    }
}
