using Produtos.Api.Business.Entities;

namespace Produtos.Api.Business.Repositories
{
    public interface IEmpresaRepository
    {
        void Adicionar(Empresa empresa);
        IList<Empresa> Obter();
        Empresa? ObterEmpresa(int empresaId);
    }
}
