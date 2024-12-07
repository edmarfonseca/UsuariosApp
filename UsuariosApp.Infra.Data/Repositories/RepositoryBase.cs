using UsuariosApp.Domain.Entities;
using UsuariosApp.Domain.Interfaces.Repositories;
using UsuariosApp.Infra.Data.Contexts;

namespace UsuariosApp.Infra.Data.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        public virtual T Add(T obj)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.Add(obj);
                dataContext.SaveChanges();
            }

            return obj;
        }

        public virtual T Update(T obj)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.Update(obj);
                dataContext.SaveChanges();
            }

            return obj;
        }

        public virtual T Delete(T obj)
        {
            return Update(obj);
        }

        public virtual ICollection<T> Get()
        {
            using (var dataContext = new DataContext())
            {
                return dataContext
                    .Set<T>()
                    .Where(t => (t as EntityBase).Ativo)
                    .ToList();
            }
        }

        public virtual T? Get(int id)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext
                    .Set<T>()
                    .Where(t => (t as EntityBase).Id == id && (t as EntityBase).Ativo)
                    .FirstOrDefault();
            }
        }
    }
}