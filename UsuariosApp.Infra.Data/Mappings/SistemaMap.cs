using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UsuariosApp.Domain.Entities;

namespace UsuariosApp.Infra.Data.Mappings
{
    public class SistemaMap : IEntityTypeConfiguration<Sistema>
    {
        public void Configure(EntityTypeBuilder<Sistema> builder)
        {
            builder.ToTable("TB_SISTEMA");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id)
                .HasColumnName("ID");

            builder.Property(t => t.Nome)
                .HasColumnName("NOME")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(t => t.Codigo)
                 .HasColumnName("CODIGO")
                 .HasMaxLength(10)
                 .IsRequired();

            builder.Property(t => t.Url)
               .HasColumnName("URL")
               .HasMaxLength(250)
               .IsRequired();


            builder.HasIndex(t => t.Url)
                .IsUnique();
        }
    }
}