using System.ComponentModel.DataAnnotations.Schema;

namespace AzureStorage.Domain.Entities
{
    [NotMapped]
    public class BlobResult
    {
        public string Container { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
    }
}
