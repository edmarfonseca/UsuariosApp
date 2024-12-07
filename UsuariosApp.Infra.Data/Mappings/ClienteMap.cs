using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UsuariosApp.Domain.Entities;

namespace UsuariosApp.Infra.Data.Mappings
{
    public class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("TB_CLIENTE");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id)
                .HasColumnName("ID");

            builder.Property(t => t.Nome)
                .HasColumnName("NOME")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(t => t.CpfCnpj)
                .HasColumnName("CPF_CNPJ")
                .HasMaxLength(14)
                .IsRequired();

            builder.Property(t => t.Logradouro)
                .HasColumnName("LOGRADOURO")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(t => t.Numero)
                .HasColumnName("NUMERO")
                .IsRequired();

            builder.Property(t => t.Bairro)
                .HasColumnName("BAIRRO")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(t => t.Cidade)
                .HasColumnName("CIDADE")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(t => t.Uf)
                .HasColumnName("UF")
                .HasMaxLength(2)
                .IsRequired();

            builder.Property(t => t.Cep)
                .HasColumnName("CEP")
                .HasMaxLength(8)
                .IsRequired();


            builder.HasIndex(t => t.CpfCnpj)
                .IsUnique();
        }
    }
}