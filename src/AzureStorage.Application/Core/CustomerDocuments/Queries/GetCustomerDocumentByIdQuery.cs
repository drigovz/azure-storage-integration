using MediatR;

namespace AzureStorage.Application.Core.CustomerDocuments.Queries
{
    public class GetCustomerDocumentByIdQuery : IRequest<BaseResponse>
    {
        public int Id { get; set; }
    }
}
