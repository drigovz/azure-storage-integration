using AzureStorage.Domain.Entities.Enums;

namespace AzureStorage.Domain.Entities
{
    public sealed class Document : BaseEntity
    {
        public DocumentType DocumentType { get; private set; }
        public string Url { get; private set; }
        public byte[] File { get; private set; }
        public string FileName { get; private set; }

        public Document(DocumentType documentType, string url, byte[] file, string fileName)
        {
            DocumentType = documentType;
            Url = url;
            File = file;
            FileName = fileName;
        }
    }
}