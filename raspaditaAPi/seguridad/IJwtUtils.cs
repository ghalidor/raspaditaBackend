
using Domain;

namespace raspaditaAPi.seguridad
{
    public interface IJwtUtils
    {
        public string GenerateToken(usuarioResponse user);
        public int? ValidateToken(string token);
    }
}
