using FluentValidation;

namespace Sscs.Application.Company.Commands.CreateCompany
{
    public class CreateCompanyCommandValidator : AbstractValidator<CreateCompanyCommand>
    {
        public CreateCompanyCommandValidator()
        {
            RuleFor(x => x.Password).NotEmpty();

            RuleFor(x => x.CompanyName).NotEmpty();

            RuleFor(x => x.CompanyOwnerEmail)
                .EmailAddress()
                .NotEmpty();
        }
    }
}