
using Domain;

namespace Application.IRepository
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<usuario>> GetUsuarios();      
        Task<IEnumerable<usuario>> GetUsuarioLocal(Int64 local_id);
        Task<IEnumerable<usuarioCaja>> GetUsuarioCaja(Int64 caja_id);
        Task<usuario> GetDetalleUsuario(Int64 id);
        Task<usuario> GetDetalleUsuarioxNombre(string nombre);
        Task<Int64> CreateUsuario(usuario usuario);
        Task<bool> UpdateUsuario(usuario usuario);
        Task<bool> UpdateUsuarioCaja(usuarioCaja usuario);
        Task<bool> CreateUsuarioCaja(usuarioCaja caja);
        Task<bool> UpdateUsuarioLocal(usuarioLocal usuario);
        Task<bool> CreateUsuarioLocal(usuarioLocal caja);
        Task<bool> UpdateUsuarioRol(usuarioRol usuario);
        Task<bool> CreateUsuarioRol(usuarioRol usurol);
    }
}

