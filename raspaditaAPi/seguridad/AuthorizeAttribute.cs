using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;

namespace raspaditaAPi.seguridad
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeAttribute : Attribute, IAsyncAuthorizationFilter
    {
        private readonly IMediator _mediator;
        public AuthorizeAttribute(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            //context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
            var descriptor = (ControllerActionDescriptor)context.ActionDescriptor;
            var user = context.HttpContext.Items["User"];
            var timeExpired = (bool)context.HttpContext.Items["expired"];
            Int64 id_usuario = 0;
            var allowAnonymous = context.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>().Any();
            return;
        }

        private void SetResultUnAuthorize(AuthorizationFilterContext context)
        {
            context.Result = (IActionResult)new UnauthorizedResult();
        }

    }
}
