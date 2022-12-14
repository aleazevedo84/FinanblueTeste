using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Produtos.Api.Business.Entities;
using Produtos.Api.Business.Enum;

namespace Produtos.Api.Infraestruture.Mappings
{
    public class EmpresaMapping : IEntityTypeConfiguration<Empresa>
    {
        public void Configure(EntityTypeBuilder<Empresa> builder)
        {
            builder.ToTable("Empresa");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Nome)
                .HasColumnType("varchar(50)")
                .IsRequired();
            builder.Property(p => p.CNPJ)
                .HasColumnType("varchar(14)")
                .IsRequired();
            builder.Property(p => p.DataAbertura)
                .IsRequired();
            builder.Property(p => p.NaturezaJuridica)
                .IsRequired();
            builder.Property(p => p.Situacao)
                .HasDefaultValue(Situacao.Ativo);
        }
    }
}
