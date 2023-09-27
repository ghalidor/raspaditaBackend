
using Domain;

namespace Application.IRepository
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<usuario>> GetUsuarios();
        
        Task<IEnumerable<usuario>> GetUsuarioLocal(Int64 local_id);
        Task<IEnumerable<usuarioCaja>> GetUsuarioCaja(Int64 caja_id);
        Task<usuario> GetDetalleUsuario(Int64 id);
        Task<usuario> GetDetalleUsuarioNombre(string nombre);
        Task<usuario> GetDetalleUsuarioxNombre(string nombre);
        Task<usuario> GetDetalleUsuarioCaja(Int64 caja_id, Int64 usuario_id);
        Task<Int64> CreateUsuario(usuario usuario);
        Task<bool> UpdateUsuario(usuario usuario);
        Task<bool> UpdateUsuarioCaja(usuarioCaja usuario);
        Task<bool> DelteUsuarioCaja(Int64 id);
        Task<bool> CreateUsuarioCaja(usuarioCajaNuevo_ caja);
        Task<bool> UpdateUsuarioLocal(usuarioLocal usuario);
        Task<bool> CreateUsuarioLocal(usuarioLocal caja);
        Task<bool> UpdateUsuarioRol(usuarioRol usuario);
        Task<bool> CreateUsuarioRol(usuarioRol usurol);
    }
}

