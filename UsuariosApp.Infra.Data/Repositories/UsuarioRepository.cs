using Microsoft.EntityFrameworkCore;
using UsuariosApp.Domain.Entities;
using UsuariosApp.Domain.Interfaces.Repositories;
using UsuariosApp.Infra.Data.Contexts;

namespace UsuariosApp.Infra.Data.Repositories
{
    public class UsuarioRepository : RepositoryBase<Usuario>, IUsuarioRepository
    {
        public bool Verify(string email)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext
                    .Set<Usuario>()
                    .Any(u => u.Email.Equals(email));
            }
        }

        public Usuario? Find(string email, string senha)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext
                    .Set<Usuario>()
                    .Where(u => u.Email.Equals(email)
                             && u.Senha.Equals(senha))
                    .FirstOrDefault();
            }
        }
    }
}