using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Sscs.Domain.AggregatesModel.CompanyAggregate;

namespace Sscs.Application.Company.Commands.RegisterCompany
{
    public class RegisterCompanyCommandHandler : IRequestHandler<RegisterCompanyCommand>
    {
        private readonly IMediator _mediator;
        private readonly ICompanyRepository _companyRepository;

        public RegisterCompanyCommandHandler(
            IMediator mediator, 
            ICompanyRepository companyRepository)
        {
            _mediator = mediator;
            _companyRepository = companyRepository;
        }

        public async Task<Unit> Handle(RegisterCompanyCommand request, CancellationToken cancellationToken = default)
        {
            var registeredCompany = new Domain.AggregatesModel.CompanyAggregate.Company(request.CompanyName);
            registeredCompany.RegisterCompany(request.CompanyOwnerEmail);
            
            await _companyRepository.AddCompany(registeredCompany, cancellationToken);

            // todo требуется механизм dispatch.
            foreach (var domainEvent in registeredCompany.DomainEvents)
            {
                await _mediator.Publish(domainEvent, cancellationToken);
            }
            
            return Unit.Value;
        }
    }
}