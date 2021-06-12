using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Sscs.Api.Controllers
{
    public class SscsBaseController : ControllerBase
    {
        protected readonly IMediator Mediator;

        public SscsBaseController(IMediator mediator)
        {
            Mediator = mediator;
        } 
    }
}