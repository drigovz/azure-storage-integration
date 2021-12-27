using AzureStorage.Domain.Entities.Enums;
using AzureStorage.Domain.Validations;
using System.Text.Json.Serialization;

namespace AzureStorage.Domain.Entities
{
    public sealed class CustomerDocument : BaseEntity
    {
        public DocumentType DocumentType { get; private set; }
        public string Url { get; private set; }
        public string FileName { get; private set; }
        [JsonIgnore]
        public Customer Customer { get; private set; }

        public CustomerDocument(int id, DocumentType documentType, string url, string fileName)
        {
            Id = id;

            EntityValidation(this, new CustomerDocumentValidator());
        }

        public CustomerDocument(DocumentType documentType, string url, string fileName)
        {
            DocumentType = documentType;
            Url = url;
            FileName = fileName;

            EntityValidation(this, new CustomerDocumentValidator());
        }

        public CustomerDocument(DocumentType documentType, string url, string fileName, Customer customer)
        {
            DocumentType = documentType;
            Url = url;
            FileName = fileName;
            Customer = customer;

            EntityValidation(this, new CustomerDocumentValidator());
        }

        public CustomerDocument UpdateDocument(DocumentType documentType, string url, string fileName)
        {
            DocumentType = documentType;
            Url = url;
            FileName = fileName;

            EntityValidation(this, new CustomerDocumentValidator());
            return this;
        }
    }
}