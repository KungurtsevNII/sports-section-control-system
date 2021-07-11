using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Sscs.Domain.AggregatesModel.CompanyAggregate;

namespace Sscs.Application.Companies.Commands.RegisterCompany
{
    public class RegisterCompanyCommandHandler : IRequestHandler<RegisterCompanyCommand>
    {
        private readonly IMediator _mediator;
        private readonly ICompanyRepository _companyRepository;
        private readonly UserManager<User> _userManager;

        public RegisterCompanyCommandHandler(
            IMediator mediator, 
            ICompanyRepository companyRepository, UserManager<User> userManager)
        {
            _mediator = mediator;
            _companyRepository = companyRepository;
            _userManager = userManager;
        }

        public async Task<Unit> Handle(RegisterCompanyCommand request, CancellationToken cancellationToken = default)
        {
            var companyOwner = new User
            {
                Email = request.CompanyOwnerEmail,
            };
            companyOwner.PasswordHash = _userManager.PasswordHasher.HashPassword(companyOwner, request.Password); 
            
            var companyForRegistration = new Company(request.CompanyName);
            
            companyForRegistration.RegisterCompany(companyOwner);
            
            
            await _companyRepository.AddCompany(companyForRegistration, cancellationToken);

            // todo требуется механизм dispatch.
            foreach (var domainEvent in companyForRegistration.DomainEvents)
            {
                await _mediator.Publish(domainEvent, cancellationToken);
            }
            
            return Unit.Value;
        }
    }
}