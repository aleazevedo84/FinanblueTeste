using Produtos.Api.Business.Enum;

namespace Produtos.Api.Models
{
    public class ProdutoViewModel
    {
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public int Empresa { get; set; }
        public Situacao Situacao { get; set; }
    }
}
