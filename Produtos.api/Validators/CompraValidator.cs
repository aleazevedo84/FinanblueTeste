using DocumentValidator;
using FluentValidation;
using Produtos.Api.Models;

namespace Produtos.Api.Validators
{
    public class CompraValidator : AbstractValidator<CompraViewModel>
    {
        public CompraValidator()
        {
            RuleFor(x => x.Produto)
                .NotNull()
                .GreaterThan(0);  
            RuleFor(x => x.Quantidade)
                .NotNull()
                .GreaterThan(0);
        }
    }
}
