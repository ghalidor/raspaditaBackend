using Application.CommandsQueries.Usuario_CommandsQueries;
using MediatR;

namespace raspaditaAPi.seguridad
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;

        public JwtMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context, IMediator mediator, IJwtUtils jwtUtils)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var userId = jwtUtils.ValidateToken(token);
            if(userId != null)
            {
                if(userId < 0)
                {
                    context.Items["expired"] = true;
                }
                else
                {
                    context.Items["expired"] = false;
                    // attach user to context on successful jwt validation
                    context.Items["User"] = await mediator.Send(new GetDetalleUsuarioQuery() { id=userId.Value });
                }

            }
            else
            {

                context.Items["expired"] = false;
            }
            await _next(context);
        }
    }
}
