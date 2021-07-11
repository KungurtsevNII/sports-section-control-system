using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sscs.Application.Companies.Commands.RegisterCompany;

namespace Sscs.Api.Controllers
{
    [Route("company")]
    [ApiController]
    public class CompanyController : SscsBaseController
    {
        public CompanyController(IMediator mediator) : base(mediator) { }

        [HttpPost]
        public async Task<IActionResult> RegisterCompany(
            [FromBody] RegisterCompanyCommand command,
            CancellationToken ct = default)
        {
           await Mediator.Send(command, ct);
           return NoContent();
        }
    }
}