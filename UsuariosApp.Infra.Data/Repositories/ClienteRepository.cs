using UsuariosApp.Domain.Entities;
using UsuariosApp.Domain.Interfaces.Repositories;

namespace UsuariosApp.Infra.Data.Repositories
{
    public class ClienteRepository : RepositoryBase<Cliente>, IClienteRepository
    {
    }
}