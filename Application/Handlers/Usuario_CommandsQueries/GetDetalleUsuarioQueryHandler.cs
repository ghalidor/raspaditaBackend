
using Application.CommandsQueries.Usuario_CommandsQueries;
using Application.IRepository;
using Domain;
using MediatR;
using System.Globalization;

namespace Application.Handlers.Usuario_CommandsQueries
{
    public class GetDetalleUsuarioQueryHandler : IRequestHandler<GetDetalleUsuarioQuery, usuario>
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public GetDetalleUsuarioQueryHandler(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }
        public async Task<usuario> Handle(GetDetalleUsuarioQuery query, CancellationToken cancellationToken)
        {
            return await _usuarioRepository.GetDetalleUsuario(query.id); ;
        }
    }
}
