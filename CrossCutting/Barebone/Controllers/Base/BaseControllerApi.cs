using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Barebone.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("api/[controller]/[action]")]
    public abstract class BaseControllerApi : ControllerBase
    {
        private IMediator _mediator;
        private IMapper _mapper;
        protected IMediator Mediator => _mediator ?? (_mediator = HttpContext.RequestServices.GetService<IMediator>());
        protected IMapper Mapper => _mapper ?? (_mapper = HttpContext.RequestServices.GetService<IMapper>());
    }
}
