using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UsuariosApp.Domain.Entities;

namespace UsuariosApp.Infra.Data.Mappings
{
    public class ClienteSistemaMap : IEntityTypeConfiguration<ClienteSistema>
    {
        public void Configure(EntityTypeBuilder<ClienteSistema> builder)
        {
            builder.ToTable("TB_CLIENTE_SISTEMA");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id)
                .HasColumnName("ID");            

            builder.Property(t => t.ClienteId)
                .HasColumnName("CLIENTE_ID");

            builder.Property(t => t.SistemaId)
                .HasColumnName("SISTEMA_ID");


            builder.HasIndex(t => new { t.ClienteId, t.SistemaId })
                .IsUnique();

            builder.HasOne(t => t.Cliente) //ClienteSistema TEM 1 Cliente
                .WithMany(t => t.Sistemas) //Cliente TEM MUITOS ClienteSistema
                .HasForeignKey(t => t.ClienteId) //Chave estrangeira
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(t => t.Sistema) //ClienteSistema TEM 1 Sistema
                .WithMany(t => t.Clientes) //Sistema TEM MUITOS ClienteSistema
                .HasForeignKey(t => t.SistemaId) //Chave estrangeira
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}