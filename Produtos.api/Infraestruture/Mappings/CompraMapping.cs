using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Produtos.Api.Business.Entities;

namespace Produtos.Api.Infraestruture.Mappings
{
    public class CompraMapping : IEntityTypeConfiguration<Compra>
    {
        public void Configure(EntityTypeBuilder<Compra> builder)
        {
            builder.ToTable("Compra");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Quantidade)
                .IsRequired();
            builder.HasOne(p => p.Produto)
                .WithMany().HasForeignKey(fk => fk.ProdutoId);
        }
    }
}
