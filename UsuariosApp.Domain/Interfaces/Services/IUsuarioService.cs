using UsuariosApp.Domain.Dtos;

namespace UsuariosApp.Domain.Interfaces.Services
{
    public interface IUsuarioService
    {
        CriarUsuarioResponse CriarUsuario(CriarUsuarioRequest dto);
        AutenticarUsuarioResponse AutenticarUsuario(AutenticarUsuarioRequest dto);
    }
}