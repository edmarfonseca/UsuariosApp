using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UsuariosApp.Domain.Entities;

namespace UsuariosApp.Infra.Data.Mappings
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("TB_USUARIO");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id)
                .HasColumnName("ID");

            builder.Property(t => t.Nome)
                .HasColumnName("NOME")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(t => t.Email)
                .HasColumnName("EMAIL")
                .HasMaxLength(100)
                .IsRequired();            

            builder.Property(t => t.Senha)
                .HasColumnName("SENHA")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(t => t.ClienteId)
                .HasColumnName("CLIENTE_ID")
                .IsRequired();


            builder.HasIndex(t => t.Email)
                .IsUnique();

            builder.HasOne(t => t.Cliente) //Usuário TEM 1 Cliente
                .WithMany(t => t.Usuarios) //Cliente TEM Muitos Usuários
                .HasForeignKey(t => t.ClienteId) //Chave estrangeira
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}