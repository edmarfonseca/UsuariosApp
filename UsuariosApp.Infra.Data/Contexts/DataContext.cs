using Microsoft.EntityFrameworkCore;
using UsuariosApp.Domain.Entities;
using UsuariosApp.Infra.Data.Mappings;

namespace UsuariosApp.Infra.Data.Contexts
{
    public class DataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "Server=localhost;Database=factousersdb;Uid=developer;Pwd='1234567'";
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 40));

            optionsBuilder.UseMySql(connectionString, serverVersion);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //adicionar cada classe de mapeamento do projeto
            modelBuilder.ApplyConfiguration(new PerfilMap());
            modelBuilder.ApplyConfiguration(new PerfilPermissaoMap());
            modelBuilder.ApplyConfiguration(new PermissaoMap());
            modelBuilder.ApplyConfiguration(new UsuarioMap());

            modelBuilder.Entity<Perfil>().HasData(
                new Perfil { Id = 1, Nome = "OPERADOR" },
                new Perfil { Id = 2, Nome = "ADMINISTRADOR" }
            );
        }
    }
}