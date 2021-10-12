using AzureStorage.Domain.Entities;
using FluentValidation;

namespace AzureStorage.Domain.Validations
{
    public class CustomerDocumentValidator : AbstractValidator<CustomerDocument>
    {
        public CustomerDocumentValidator()
        {
            RuleFor(x => x.DocumentType).NotEmpty().IsInEnum();
            RuleFor(x => x.Url).NotEmpty()
                               .WithMessage("Url is required")
                               .Must(x => x.StartsWith("http") || x.StartsWith("https"))
                               .WithMessage("Url format not valid");
            RuleFor(x => x.File).NotEmpty();
            RuleFor(x => x.FileName).NotEmpty();
        }
    }
}
