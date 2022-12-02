using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Produtos.Api.Business.Entities;

namespace Produtos.Api.Infraestruture.Mappings
{
    public class ProdutoMapping : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("Produto");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Nome)
                .HasColumnType("varchar(50)")
                .IsRequired();
            builder.Property(p => p.Valor)
                .HasColumnType("decimal(10,2)")
                .IsRequired();
            builder.HasOne(p => p.Empresa)
                .WithMany().HasForeignKey(fk => fk.EmpresaId);
        }
    }
}
