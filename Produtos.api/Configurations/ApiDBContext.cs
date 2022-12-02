using Microsoft.EntityFrameworkCore;
using Produtos.Api.Business.Entities;
using Produtos.Api.Infraestruture.Mappings;

namespace Produtos.Api.Configurations
{
    public class ApiDBContext : DbContext
    {
        public ApiDBContext(DbContextOptions<ApiDBContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Empresa>(new EmpresaMapping().Configure);
            modelBuilder.Entity<Produto>(new ProdutoMapping().Configure);
            modelBuilder.Entity<Compra>(new CompraMapping().Configure);
            modelBuilder.Entity<Usuario>(new UsuarioMapping().Configure);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Empresa> Empresa { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<Compra> Compra { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
    }
}
