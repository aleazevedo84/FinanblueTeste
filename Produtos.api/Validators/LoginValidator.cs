using FluentValidation;
using Produtos.Api.Models;

namespace Produtos.Api.Validators
{
    public class LoginValidator : AbstractValidator<LoginViewModel>
    {
        public LoginValidator()
        {
            RuleFor(x => x.Login)
                .NotNull()
                .NotEmpty();
            RuleFor(x => x.Senha)
                .NotNull()
                .NotEmpty();
        }
    }
}
