using Produtos.Api.Business.Entities;
using Produtos.Api.Business.Repositories;
using Produtos.Api.Configurations;

namespace Produtos.Api.Infraestruture.Repositories
{
    public class CompraRepository : ICompraRepository
    {
        private readonly ApiDBContext _contexto;

        public CompraRepository(ApiDBContext contexto)
        {
            _contexto = contexto;
        }

        public void Adicionar(Compra compra)
        {
            _contexto.Compra.Add(compra);
        }

        public void Commit()
        {
            _contexto.SaveChanges();
        }

        public IList<Compra> Obter()
        {
            return _contexto.Compra.ToList();
        }
    }
}
