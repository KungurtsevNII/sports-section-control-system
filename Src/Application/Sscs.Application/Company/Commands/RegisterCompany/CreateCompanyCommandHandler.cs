using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Sscs.Domain.AggregatesModel.CompanyAggregate;

namespace Sscs.Application.Company.Commands.RegisterCompany
{
    public class RegisterCompanyCommandHandler : IRequestHandler<RegisterCompanyCommand>
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ICompanyRepository _companyRepository;

        public RegisterCompanyCommandHandler(UserManager<User> userManager, SignInManager<User> signInManager, ICompanyRepository companyRepository)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _companyRepository = companyRepository;
        }

        public async Task<Unit> Handle(RegisterCompanyCommand request, CancellationToken cancellationToken = default)
        {
            await _companyRepository.AddCompany(request.CompanyName, cancellationToken);
            Console.WriteLine("asdasd");
            return Unit.Value;
        }
    }
}