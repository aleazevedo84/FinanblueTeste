using Microsoft.AspNetCore.Identity;
using Produtos.Api.Business.Entities;
using Produtos.Api.Business.Repositories;
using Produtos.Api.Configurations;
using Produtos.Api.Models;

namespace Produtos.Api.Infraestruture.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ApiDBContext _contexto;

        public UsuarioRepository(ApiDBContext contexto)
        {
            _contexto = contexto;
        }

        public void Adicionar(Usuario usuario)
        {
            ConverteSenhaEmHash(usuario);
            _contexto.Usuario.Add(usuario);
            _contexto.SaveChanges();
        }

        public void Atualizar(Usuario usuario)
        {
            ConverteSenhaEmHash(usuario);
            _contexto.Usuario.Update(usuario);
            _contexto.SaveChanges();
        }

        public Usuario? ObterUsuario(string login)
        {
            return _contexto.Usuario.FirstOrDefault(u => u.Login == login);
        }
        private void ConverteSenhaEmHash(Usuario usuario)
        {
            var senhaHasher = new PasswordHasher<Usuario>();
            usuario.Senha = senhaHasher.HashPassword(usuario, usuario.Senha);
        }

        public bool ValidaSenha(LoginViewModel loginViewModel)
        {
            var usuarioConsulta = ObterUsuario(loginViewModel.Login);
            if (usuarioConsulta == null)
            {
                return false;
            }
            return ValidaEAtualizaHash(loginViewModel, usuarioConsulta.Senha);
        }

        private bool ValidaEAtualizaHash(LoginViewModel loginViewModel, string hash)
        {
            var senhaHasher = new PasswordHasher<LoginViewModel>();
            var status = senhaHasher.VerifyHashedPassword(loginViewModel, hash, loginViewModel.Senha);
            switch (status)
            {
                case PasswordVerificationResult.Failed:
                    return false;
                case PasswordVerificationResult.Success:
                    return true;
                //case PasswordVerificationResult.SuccessRehashNeeded:
                //    Atualizar(usuario);
                //    return true;
                default:
                    throw new InvalidOperationException();
            }
        }
    }
}
