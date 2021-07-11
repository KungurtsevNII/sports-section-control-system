using MediatR;

namespace Sscs.Application.Companies.Commands.RegisterCompany
{
    public class RegisterCompanyCommand : IRequest
    {
        /// <summary>
        /// Email владельца компании.
        /// </summary>
        public string CompanyOwnerEmail { get; set; }

        /// <summary>
        /// Пароль владельца компании.
        /// </summary>
        public string Password { get; set; }
        
        /// <summary>
        /// Полное название компании.
        /// </summary>
        public string CompanyName { get; set; }
    }
}