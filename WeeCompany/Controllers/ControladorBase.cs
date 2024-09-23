using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
namespace WeeCompany.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ControladorBase : ControllerBase
    {
        private IMediator _mediator;
        //mediator se va instanciar atraves de la interfaz IMediator
        protected IMediator Mediator => _mediator ?? (_mediator = HttpContext.RequestServices.GetService<IMediator>());


    }
}
