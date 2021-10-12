using AzureStorage.Application.Core.Customers.Commands;
using FluentValidation;

namespace AzureStorage.Application.Core.Customers.Validators
{
    public class CustomerRemoveCommandValidator : AbstractValidator<CustomerRemoveCommand>
    {
        public CustomerRemoveCommandValidator()
        {
            RuleFor(x => x.Id).NotNull().NotEmpty();
        }
    }
}
