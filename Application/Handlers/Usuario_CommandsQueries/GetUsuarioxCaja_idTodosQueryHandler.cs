
using Application.CommandsQueries.Usuario_CommandsQueries;
using Application.IRepository;
using Domain;
using MediatR;
using System.Globalization;

namespace Application.Handlers.Usuario_CommandsQueries;
public class GetUsuarioxCaja_idTodosQueryHandler : IRequestHandler<GetUsuarioxCaja_idTodosQuery, IEnumerable<usuarioCheck>>
{
    private readonly IUsuarioRepository _usuarioRepository;
    public GetUsuarioxCaja_idTodosQueryHandler(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }
    public async Task<IEnumerable<usuarioCheck>> Handle(GetUsuarioxCaja_idTodosQuery query, CancellationToken cancellationToken)
    {
        List<usuarioCheck> lista = new List<usuarioCheck>();
        var usuariocaja = await _usuarioRepository.GetUsuarioCaja(query.caja_id);
        var usuarios = await _usuarioRepository.GetUsuarioLocal(query.local_id);
        usuarioCheck registro = new usuarioCheck();
        foreach (var item in usuarios)
        {
            registro=new usuarioCheck();
            registro.id=item.id;
            registro.nombre =item.nombre;
            registro.usuariolocal_id = item.usuariolocal_id;
            registro.caja_id = item.caja_id;
            registro.caja_nombre = item.caja_nombre;
            registro.local_id = item.local_id;
            registro.local_nombre = item.local_nombre;
            registro.usuariorol_id = item.usuariorol_id;
            registro.rol_id = item.rol_id;
            registro.rol_nombre=item.rol_nombre;
            registro.fecharegistro_string = item.fecharegistro.ToString() != "01/01/0001 0:00:00" ? item.fecharegistro.ToString("dd-MM-yyyy hh:mm:ss tt", CultureInfo.InvariantCulture) : "----";
            registro.fechaupdated_string = item.fechaupdated.ToString() != "01/01/0001 0:00:00" ? item.fechaupdated.ToString("dd-MM-yyyy hh:mm:ss tt", CultureInfo.InvariantCulture) : "----";
            registro.estado=item.estado;
            registro.estado_string = item.estado ? "ACTIVO" : "INACTIVO";
            registro.clase = item.estado ? "success" : "danger";
            registro.check = usuariocaja.Where(x => x.usuario_id == item.id).Any()?"checked":"";
            lista.Add(registro);
        }
        return lista;
    }

}
