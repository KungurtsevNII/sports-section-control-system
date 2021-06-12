using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Sscs.Domain.AggregatesModel.CompanyAggregate;

namespace Sscs.Application.Company.Commands.CreateCompany
{
    public class CreateCompanyCommandHandler : IRequestHandler<CreateCompanyCommand>
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public CreateCompanyCommandHandler(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public Task<Unit> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
        {
            Console.WriteLine("asdasd");
            return Unit.Task;
        }
    }
}