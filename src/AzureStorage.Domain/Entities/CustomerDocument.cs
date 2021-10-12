using AzureStorage.Domain.Entities.Enums;
using AzureStorage.Domain.Validations;

namespace AzureStorage.Domain.Entities
{
    public sealed class CustomerDocument : BaseEntity
    {
        public DocumentType DocumentType { get; private set; }
        public string Url { get; private set; }
        public byte[] File { get; private set; }
        public string FileName { get; private set; }

        public CustomerDocument(int id, DocumentType documentType, string url, byte[] file, string fileName)
        {
            Id = id;

            EntityValidation(this, new CustomerDocumentValidator());
        }

        public CustomerDocument(DocumentType documentType, string url, byte[] file, string fileName)
        {
            DocumentType = documentType;
            Url = url;
            File = file;
            FileName = fileName;

            EntityValidation(this, new CustomerDocumentValidator());
        }

        public CustomerDocument UpdateDocument(DocumentType documentType, string url, byte[] file, string fileName)
        {
            EntityValidation(this, new CustomerDocumentValidator());

            return this;
        }
    }
}