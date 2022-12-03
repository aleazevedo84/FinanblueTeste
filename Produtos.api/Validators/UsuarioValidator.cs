using FluentValidation;
using FluentValidation.AspNetCore;
using Produtos.Api.Business.Entities;
using Produtos.Api.Models;
using System.Text.RegularExpressions;

namespace Produtos.Api.Validators
{
    public class UsuarioValidator : AbstractValidator<RegistroViewModel>
    {
        public UsuarioValidator() {
            RuleFor(x => x.Login)
                .NotNull()
                .NotEmpty()
                .Length(5, 8);
            RuleFor(x => x.Email)
                .NotNull()
                .NotEmpty()
                .EmailAddress();
            RuleFor(x => x.Senha)
                .NotNull()
                .NotEmpty()
                .Must(pass => Regex.IsMatch(pass,@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-azA-Z]).{8,15}$"));
        }     
    }
}
