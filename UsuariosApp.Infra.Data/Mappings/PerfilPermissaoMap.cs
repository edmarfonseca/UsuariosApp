using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuariosApp.Domain.Entities;

namespace UsuariosApp.Infra.Data.Mappings
{
    public class PerfilPermissaoMap : IEntityTypeConfiguration<PerfilPermissao>
    {
        public void Configure(EntityTypeBuilder<PerfilPermissao> builder)
        {
            builder.ToTable("TB_PERFIL_PERMISSAO");

            //chave primária composta
            builder.HasKey(p => new { p.PerfilId, p.PermissaoId });

            builder.Property(p => p.PerfilId)
                .HasColumnName("PERFIL_ID");

            builder.Property(p => p.PermissaoId)
                .HasColumnName("PERMISSAO_ID");

            #region Chaves estrangeiras

            builder.HasOne(p => p.Perfil) //PerfilPermissao TEM 1 Perfil
                .WithMany(p => p.Permissoes) //Perfil TEM MUITOS PerfilPermissao
                .HasForeignKey(p => p.PerfilId) //Chave estrangeira
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.Permissao) //PerfilPermissao TEM 1 Permissao
                .WithMany(p => p.Perfis) //Permissao TEM MUITOS PerfilPermissao
                .HasForeignKey(p => p.PermissaoId) //Chave estrangeira
                .OnDelete(DeleteBehavior.Restrict);

            #endregion
        }
    }
}
