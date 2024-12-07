using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UsuariosApp.Domain.Entities;

namespace UsuariosApp.Infra.Data.Mappings
{
    public class UsuarioPerfilMap : IEntityTypeConfiguration<UsuarioPerfil>
    {
        public void Configure(EntityTypeBuilder<UsuarioPerfil> builder)
        {
            builder.ToTable("TB_USUARIO_PERFIL");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id)
                .HasColumnName("ID");

            builder.Property(t => t.UsuarioId)
                .HasColumnName("USUARIO_ID");

            builder.Property(t => t.ClienteSistemaId)
                .HasColumnName("CLIENTE_SISTEMA_ID");

            builder.Property(t => t.PerfilId)
                .HasColumnName("PERFIL_ID");


            builder.HasIndex(t => new { t.UsuarioId, t.ClienteSistemaId })
                .IsUnique();

            builder.HasOne(t => t.Usuario) //UsuarioPerfil TEM 1 Usuário
                .WithMany(t => t.Perfis) //Usuário TEM MUITOS UsuarioPerfil
                .HasForeignKey(t => t.UsuarioId) //Chave estrangeira
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(t => t.ClienteSistema) //UsuarioPerfil TEM 1 ClienteSistema
                .WithMany(t => t.UsuariosPerfis) //ClienteSistema TEM MUITOS UsuarioPerfil
                .HasForeignKey(t => t.ClienteSistemaId) //Chave estrangeira
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(t => t.Perfil) //UsuarioPerfil TEM 1 Perfil
                .WithMany(t => t.Usuarios) //Perfil TEM MUITOS UsuarioPerfil
                .HasForeignKey(t => t.PerfilId) //Chave estrangeira
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}