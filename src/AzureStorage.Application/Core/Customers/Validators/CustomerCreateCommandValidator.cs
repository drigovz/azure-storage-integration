using AzureStorage.Application.Core.Customers.Commands;
using AzureStorage.Domain.Validations;
using FluentValidation;

namespace AzureStorage.Application.Core.Customers.Validators
{
    public class CustomerCreateCommandValidator : AbstractValidator<CustomerCreateCommand>
    {
        public CustomerCreateCommandValidator()
        {
            RuleFor(x => x.FirstName).FirstName();
            RuleFor(x => x.LastName).LastName();
            RuleFor(x => x.Email).Email();
            RuleFor(x => x.Identity).Identity();
        }
    }
}
