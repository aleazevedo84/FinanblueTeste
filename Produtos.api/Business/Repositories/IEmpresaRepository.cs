using Produtos.Api.Business.Entities;

namespace Produtos.Api.Business.Repositories
{
    public interface IEmpresaRepository
    {
        void Adicionar(Empresa empresa);
        void Commit();
        IList<Empresa> Obter();
        Empresa? ObterEmpresa(int empresaId);
    }
}
