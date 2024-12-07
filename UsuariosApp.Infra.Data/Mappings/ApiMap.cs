using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UsuariosApp.Domain.Entities;

namespace UsuariosApp.Infra.Data.Mappings
{
    public class ApiMap : IEntityTypeConfiguration<Api>
    {
        public void Configure(EntityTypeBuilder<Api> builder)
        {
            builder.ToTable("TB_API");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id)
                .HasColumnName("ID");

            builder.Property(t => t.Nome)
                .HasColumnName("NOME")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(t => t.Uri)
               .HasColumnName("URI")
               .HasMaxLength(250)
               .IsRequired();

            builder.Property(t => t.SistemaId)
                .HasColumnName("SISTEMA_ID")
                .IsRequired();


            builder.HasIndex(t => t.Uri)
                .IsUnique();

            builder.HasOne(t => t.Sistema) //Api TEM 1 Sistema
                .WithMany(t => t.Apis) //Sistema TEM MUITOS Api
                .HasForeignKey(t => t.SistemaId) //Chave estrangeira
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}