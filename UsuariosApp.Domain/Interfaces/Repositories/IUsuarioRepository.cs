using UsuariosApp.Domain.Entities;

namespace UsuariosApp.Domain.Interfaces.Repositories
{
    public interface IUsuarioRepository
    {
        void Add(Usuario usuario);

        bool Verify(string email);

        Usuario Find(string email, string senha);
    }
}