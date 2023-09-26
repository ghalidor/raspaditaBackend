
using Domain;

namespace Application.IRepository
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<usuario>> GetUsuarios();
        Task<usuario> GetDetalleUsuario(Int64 id);
        Task<IEnumerable<usuarioLocal>> GetUsuarioLocal(Int64 local_id);
        Task<IEnumerable<usuarioCaja>> GetUsuarioCaja(Int64 caja_id);
        Task<Int64> CreateUsuario(usuario usuario);
        Task<bool> UpdateUsuario(usuario usuario);
        Task<bool> CreateUsuarioCaja(usuarioCaja caja);
        Task<bool> CreateUsuarioLocal(usuarioLocal caja);
        Task<bool> CreateUsuarioRol(usuarioRol usurol);
    }
}

