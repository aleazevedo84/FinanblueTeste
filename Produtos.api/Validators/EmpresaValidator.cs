using DocumentValidator;
using FluentValidation;
using Produtos.Api.Models;

namespace Produtos.Api.Validators
{
    public class EmpresaValidator : AbstractValidator<EmpresaViewModel>
    {
        public EmpresaValidator()
        {
            RuleFor(x => x.Nome)
                .NotNull()
                .Length(5, 50);
            RuleFor(x => x.CNPJ)
                .NotNull()
                .NotEmpty()
                .Must(CnpjValidation.Validate);
            RuleFor(x => x.DataAbertura)
                .NotNull()
                .NotEmpty()
                .LessThanOrEqualTo(DateTime.Now);
            RuleFor(x => x.NaturezaJuridica)
                 .NotNull()
                 .GreaterThan(0)
                 .LessThan(9999);
            RuleFor(x => x.Situacao)
                .IsInEnum();
        }
    }
}
