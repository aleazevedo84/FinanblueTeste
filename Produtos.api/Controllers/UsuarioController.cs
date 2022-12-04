using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Produtos.Api.Business.Entities;
using Produtos.Api.Business.Repositories;
using Produtos.Api.Configurations;
using Produtos.Api.Models;

namespace Produtos.Api.Controllers
{
    [Route("api/usuario")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IAutenticacaoService _authenticationService;
        public UsuarioController(IUsuarioRepository usuarioRepository,
                                 IAutenticacaoService authenticationService)
        {
            _usuarioRepository = usuarioRepository;
            _authenticationService = authenticationService;
        }
        /// <summary>
        /// Este serviço permite autenticar um usuário cadastrado e ativo.
        /// </summary>
        /// <param name="loginViewModelInput">View model do login</param>
        /// <returns>Retorna status ok, dados do usuario e o token em caso de sucesso</returns>
        [HttpPost("logar")]
        public IActionResult Logar(LoginViewModel loginViewModel)
        {
            var valido = _usuarioRepository.ValidaSenha(loginViewModel);
            if (valido)
            {
                var usuario = _usuarioRepository.ObterUsuario(loginViewModel.Login);
                var usuarioViewModel = new UsuarioViewModel()
                {
                    Id = usuario.Id,
                    Login = loginViewModel.Login,
                    Email = usuario.Email
                };

                var token = _authenticationService.GerarToken(usuarioViewModel);

                return Ok(new
                {
                    Token = token,
                    Usuario = usuarioViewModel
                });
            }
            return Unauthorized();            
        } 

        /// <summary>
        /// Este serviço permite cadastrar um usuário não existente
        /// </summary>
        /// <param name="loginViewModel">View model do registro de login</param>
        /// <returns></returns>
        [HttpPost("registrar")]
        public IActionResult Registrar(RegistroViewModel registroViewModel)
        {
            var usuario = new Usuario();
            usuario.Login = registroViewModel.Login;
            usuario.Senha = registroViewModel.Senha;
            usuario.Email = registroViewModel.Email;
            _usuarioRepository.Adicionar(usuario);

            return Created("", registroViewModel);
        }
    }
}
