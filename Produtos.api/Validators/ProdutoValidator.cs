using FluentValidation;
using Produtos.Api.Models;

namespace Produtos.Api.Validators
{
    public class ProdutoValidator : AbstractValidator<ProdutoViewModel>
    {
        public ProdutoValidator()
        {
            RuleFor(x => x.Nome)
                .NotNull()
                .NotEmpty()
                .Length(5, 50);
            RuleFor(x => x.Valor)
                .NotNull()
                .GreaterThan(0);
            RuleFor(x => x.Empresa)
                .NotNull();
            RuleFor(x => x.Situacao)
                .IsInEnum();
        }
    }
}
