using MediatR;

namespace AzureStorage.Application.Core.CustomerDocuments.Commands
{
    public class CustomerDocumentRemoveCommand : IRequest<BaseResponse>
    {
        public int Id { get; set; }
    }
}
