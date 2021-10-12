using AzureStorage.Domain.Entities;
using AzureStorage.Domain.Interfaces;
using AzureStorage.Infra.Data.Context;

namespace AzureStorage.Infra.Data.Repository.CustomerDocuments
{
    public class CustomerDocumentRepository : BaseRepository<CustomerDocument, int>, ICustomerDocumentRepository
    {
        public CustomerDocumentRepository(AppDbContext context) : base(context)
        { }
    }
}
