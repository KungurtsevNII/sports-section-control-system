using MediatR;

namespace Sscs.Application.Company.Commands.RegisterCompany
{
    public class RegisterCompanyCommand : IRequest
    {
        public string CompanyOwnerEmail { get; set; }

        public string CompanyName { get; set; }

        public string Password { get; set; }
    }
}