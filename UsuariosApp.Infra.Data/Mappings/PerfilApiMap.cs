using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UsuariosApp.Domain.Entities;

namespace UsuariosApp.Infra.Data.Mappings
{
    public class PerfilApiMap : IEntityTypeConfiguration<PerfilApi>
    {
        public void Configure(EntityTypeBuilder<PerfilApi> builder)
        {
            builder.ToTable("TB_PERFIL_API");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id)
                .HasColumnName("ID");

            builder.Property(t => t.PerfilId)
                .HasColumnName("PERFIL_ID");

            builder.Property(t => t.ApiId)
                .HasColumnName("API_ID");


            builder.HasIndex(t => new { t.PerfilId, t.ApiId })
                .IsUnique();

            builder.HasOne(t => t.Perfil) //PerfilApi TEM 1 Perfil
                .WithMany(t => t.Apis) //Perfil TEM MUITOS PerfilApi
                .HasForeignKey(t => t.PerfilId) //Chave estrangeira
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(t => t.Api) //PerfilApi TEM 1 Api
                .WithMany(t => t.Perfis) //Api TEM MUITOS PerfilApi
                .HasForeignKey(t => t.ApiId) //Chave estrangeira
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}