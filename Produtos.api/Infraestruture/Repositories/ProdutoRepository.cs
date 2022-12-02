using Produtos.Api.Business.Entities;
using Produtos.Api.Business.Repositories;
using Produtos.Api.Configurations;

namespace Produtos.Api.Infraestruture.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly ApiDBContext _contexto;

        public ProdutoRepository(ApiDBContext contexto)
        {
            _contexto = contexto;
        }
        public void Adicionar(Produto produto)
        {
            _contexto.Produto.Add(produto);
        }
        public void Commit()
        {
            _contexto.SaveChanges();
        }
        public IList<Produto> Obter()
        {
            return _contexto.Produto.ToList();
        }
        public Produto? ObterProduto(int produtoId)
        {
            return _contexto.Produto.FirstOrDefault(u => u.Id == produtoId);
        }
    }   
}
