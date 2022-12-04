using Produtos.Api.Business.Entities;
using Produtos.Api.Models;

namespace Produtos.Api.Business.Repositories
{
    public interface IUsuarioRepository
    {
        void Adicionar(Usuario usuario);
        void Atualizar(Usuario usuario);
        Usuario? ObterUsuario(string login);
        bool ValidaSenha(LoginViewModel loginViewModel);
    }
}
