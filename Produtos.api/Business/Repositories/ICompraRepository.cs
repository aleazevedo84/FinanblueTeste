using Produtos.Api.Business.Entities;

namespace Produtos.Api.Business.Repositories
{
    public interface ICompraRepository
    {
        void Adicionar(Compra empresa);
        IList<Compra> Obter();
    }
}
