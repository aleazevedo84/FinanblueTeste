using Produtos.Api.Business.Enum;

namespace Produtos.Api.Business.Entities
{
    public class Empresa
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public string CNPJ { get; set; }

        public DateTime DataAbertura { get; set; }

        public int NaturezaJuridica { get; set; }

        public Situacao Situacao { get; set; }
    }
}
