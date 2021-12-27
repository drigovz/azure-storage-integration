using AzureStorage.Application.Core.CustomerDocuments.Commands;
using FluentValidation;

namespace AzureStorage.Application.Core.CustomerDocuments.Validators
{
    public class CustomerDocumentCreateCommandValidator : AbstractValidator<CustomerDocumentCreateCommand>
    {
        public CustomerDocumentCreateCommandValidator()
        {
            RuleFor(x => x.DocumentType).NotEmpty().IsInEnum();
            //RuleFor(x => x.Url).NotEmpty()
            //                   .WithMessage("Url is required")
            //                   .Must(x => x.StartsWith("http") || x.StartsWith("https"))
            //                   .WithMessage("Url format not valid");
            //RuleFor(x => x.FileName).NotEmpty();
            RuleFor(x => x.File).NotEmpty();
        }
    }
}
