using Microsoft.EntityFrameworkCore;
using UsuariosApp.Domain.Entities;
using UsuariosApp.Domain.Helpers;
using UsuariosApp.Infra.Data.Mappings;

namespace UsuariosApp.Infra.Data.Contexts
{
    public class DataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "Server=localhost;Database=centraladmindb;Uid=developer;Pwd='1234567'";
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 40));

            optionsBuilder.UseMySql(connectionString, serverVersion);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ApiMap());
            modelBuilder.ApplyConfiguration(new ClienteMap());
            modelBuilder.ApplyConfiguration(new ClienteSistemaMap());
            modelBuilder.ApplyConfiguration(new PerfilApiMap());
            modelBuilder.ApplyConfiguration(new PerfilMap());
            modelBuilder.ApplyConfiguration(new SistemaMap());
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new UsuarioPerfilMap());

            var now = DateTime.Now;

            modelBuilder.Entity<Cliente>().HasData(
                new Cliente
                {
                    Id = 1,
                    Nome = "Facto Soluções em TI",
                    CpfCnpj = "26263267000165",
                    Logradouro = "Rua México",
                    Numero = 31,
                    Bairro = "Centro",
                    Cidade = "Rio de Janeiro",
                    Uf = "RJ",
                    Cep = "20031140",
                    DataInclusao = now,
                    DataAlteracao = now,
                    Ativo = true
                }
            );

            modelBuilder.Entity<Usuario>().HasData(
                new Usuario
                {
                    Id = 1,
                    Nome = "Facto Soluções",
                    Email = "factoti@factoti.com.br",
                    Senha = SHA256Helper.Encrypt("@Admin01"),
                    ClienteId = 1,
                    DataInclusao = now,
                    DataAlteracao = now,
                    Ativo = true
                },

                new Usuario
                {
                    Id = 2,
                    Nome = "Edmar Fonseca",
                    Email = "edmarfonseca12@gmail.com",
                    Senha = SHA256Helper.Encrypt("@Admin02"),
                    ClienteId = 1,
                    DataInclusao = now,
                    DataAlteracao = now,
                    Ativo = true
                }
            );

            modelBuilder.Entity<Sistema>().HasData(
                new Sistema
                {
                    Id = 1,
                    Nome = "Central Admin",
                    Codigo = "CA",
                    Url = "http://localhost:5232/",
                    DataInclusao = now,
                    DataAlteracao = now,
                    Ativo = true
                }
            );

            modelBuilder.Entity<ClienteSistema>().HasData(
                new ClienteSistema
                {
                    Id = 1,
                    ClienteId = 1,
                    SistemaId = 1,
                    DataInclusao = now,
                    DataAlteracao = now,
                    Ativo = true
                }
            );

            modelBuilder.Entity<Api>().HasData(
                new Api
                {
                    Id = 1,
                    Nome = "Criação de Usuário",
                    Uri = "api/usuarios/criar",
                    SistemaId = 1,
                    DataInclusao = now,
                    DataAlteracao = now,
                    Ativo = true
                }
            );

            modelBuilder.Entity<Perfil>().HasData(
                new Perfil
                {
                    Id = 1,
                    Nome = "ADMINISTRADOR",
                    SistemaId = 1,
                    DataInclusao = now,
                    DataAlteracao = now,
                    Ativo = true
                }
            );

            modelBuilder.Entity<PerfilApi>().HasData(
                new PerfilApi
                {
                    Id = 1,
                    PerfilId = 1,
                    ApiId = 1,
                    DataInclusao = now,
                    DataAlteracao = now,
                    Ativo = true
                }
            );

            modelBuilder.Entity<UsuarioPerfil>().HasData(
                new UsuarioPerfil
                {
                    Id = 1,
                    UsuarioId = 1,
                    ClienteSistemaId = 1,
                    PerfilId = 1,
                    DataInclusao = now,
                    DataAlteracao = now,
                    Ativo = true
                }
            );
        }
    }
}