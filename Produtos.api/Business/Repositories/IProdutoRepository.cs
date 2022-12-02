using Produtos.Api.Business.Entities;

namespace Produtos.Api.Business.Repositories
{
    public interface IProdutoRepository
    {
        void Adicionar(Produto produto);
        void Commit();
        IList<Produto> Obter();
        Produto? ObterProduto(int produtoId);
    }
}
