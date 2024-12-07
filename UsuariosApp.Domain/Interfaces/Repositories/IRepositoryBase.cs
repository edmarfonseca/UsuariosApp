namespace UsuariosApp.Domain.Interfaces.Repositories
{
    public interface IRepositoryBase<T> where T : class
    {
        T Add(T obj);
        T Update(T obj);
        T Delete(T obj);
        ICollection<T> Get();
        T Get(int id);
    }
}