using MediatR;

namespace Sscs.Application.Company.Commands.CreateCompany
{
    public class CreateCompanyCommand : IRequest
    {
        public string CompanyOwnerEmail { get; set; }

        public string CompanyName { get; set; }

        public string Password { get; set; }
    }
}