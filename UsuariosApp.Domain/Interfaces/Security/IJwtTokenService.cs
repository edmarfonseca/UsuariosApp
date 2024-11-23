using UsuariosApp.Domain.Entities;

namespace UsuariosApp.Domain.Interfaces.Security
{
    public interface IJwtTokenService
    {
        string GenerateToken(Usuario usuario);

        DateTime GenerateExpirationDate();
    }
}