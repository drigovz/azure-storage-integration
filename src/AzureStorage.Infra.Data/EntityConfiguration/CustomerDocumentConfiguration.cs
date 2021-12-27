using AzureStorage.Domain.Entities;
using AzureStorage.Domain.Entities.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AzureStorage.Infra.Data.EntityConfiguration
{
    public class CustomerDocumentConfiguration : IEntityTypeConfiguration<CustomerDocument>
    {
        public void Configure(EntityTypeBuilder<CustomerDocument> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(d => d.DocumentType)
                   .HasConversion(new EnumToStringConverter<DocumentType>());
        }
    }
}
