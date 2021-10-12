using AzureStorage.Domain.Entities;
using FluentValidation;

namespace AzureStorage.Domain.Validations
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(x => x.FirstName).FirstName();
            RuleFor(x => x.LastName).LastName();
            RuleFor(x => x.Email).Email();
            RuleFor(x => x.Identity).Identity();
        }
    }
}
