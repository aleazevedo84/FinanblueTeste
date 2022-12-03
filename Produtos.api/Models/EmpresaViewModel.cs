using Produtos.Api.Business.Enum;

namespace Produtos.Api.Models
{
    public class EmpresaViewModel
    {
        public string Nome { get; set; }

        public string CNPJ { get; set; }

        public DateTime DataAbertura { get; set; }

        public int NaturezaJuridica { get; set; }

        public Situacao Situacao { get; set; }
    }

}
