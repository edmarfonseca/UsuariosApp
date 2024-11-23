using UsuariosApp.Domain.Dtos;

namespace UsuariosApp.Domain.Interfaces.Services
{
    public interface IUsuarioService
    {
        CriarUsuarioResponseDto CriarUsuario(CriarUsuarioRequestDto dto);
        AutenticarUsuarioResponseDto AutenticarUsuario(AutenticarUsuarioRequestDto dto);
    }
}