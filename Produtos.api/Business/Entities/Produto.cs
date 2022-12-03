using Produtos.Api.Business.Enum;

namespace Produtos.Api.Business.Entities
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public int EmpresaId { get; set; }
        public virtual Empresa Empresa { get; set; }
        public Situacao Situacao { get; set; }
    }
}
