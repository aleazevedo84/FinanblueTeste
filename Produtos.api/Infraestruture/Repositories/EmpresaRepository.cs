using Produtos.Api.Business.Entities;
using Produtos.Api.Business.Repositories;
using Produtos.Api.Configurations;

namespace Produtos.Api.Infraestruture.Repositories
{
    public class EmpresaRepository : IEmpresaRepository
    {
        private readonly ApiDBContext _contexto;

        public EmpresaRepository(ApiDBContext contexto)
        {
            _contexto = contexto;
        }

        public void Adicionar(Empresa empresa)
        {
            _contexto.Empresa.Add(empresa);
        }

        public void Commit()
        {
            _contexto.SaveChanges();
        }

        public IList<Empresa> Obter()
        {
            return _contexto.Empresa.ToList();
        }
        public Empresa? ObterEmpresa(int empresaId)
        {
            return _contexto.Empresa.FirstOrDefault(u => u.Id == empresaId);
        }
    }
}
