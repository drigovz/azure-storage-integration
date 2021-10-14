using AzureStorage.Application.Core.CustomerDocuments.Commands;
using FluentValidation;

namespace AzureStorage.Application.Core.CustomerDocuments.Validators
{
    public class CustomerDocumentRemoveCommandValidator : AbstractValidator<CustomerDocumentRemoveCommand>
    {
        public CustomerDocumentRemoveCommandValidator()
        {
            RuleFor(x => x.Id).NotNull().NotEmpty();
        }
    }
}
