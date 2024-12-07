using UsuariosApp.Domain.Entities;

namespace UsuariosApp.Domain.Interfaces.Repositories
{
    public interface IUsuarioPerfilRepository : IRepositoryBase<UsuarioPerfil>
    {
        List<UsuarioPerfil> Get(Usuario usuario);
    }
}