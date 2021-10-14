using AzureStorage.Application.Core.CustomerDocuments.Commands;
using FluentValidation;

namespace AzureStorage.Application.Core.CustomerDocuments.Validators
{
    public class CustomerDocumentUpdateCommandValidator : AbstractValidator<CustomerDocumentUpdateCommand>
    {
        public CustomerDocumentUpdateCommandValidator()
        {
            RuleFor(x => x.Id).NotNull().NotEmpty();
        }
    }
}
