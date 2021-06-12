using FluentValidation;

namespace Sscs.Application.Company.Commands.RegisterCompany
{
    public class RegisterCompanyCommandValidator : AbstractValidator<RegisterCompanyCommand>
    {
        public RegisterCompanyCommandValidator()
        {
            RuleFor(x => x.Password).NotEmpty();

            RuleFor(x => x.CompanyName).NotEmpty();

            RuleFor(x => x.CompanyOwnerEmail)
                .EmailAddress()
                .NotEmpty();
        }
    }
}