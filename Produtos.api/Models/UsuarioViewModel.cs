using System.ComponentModel.DataAnnotations;

namespace Produtos.Api.Models
{
    public class LoginViewModel
    {
        public string Login { get; set; }
        public string Senha { get; set; }
    }
    public class UsuarioViewModel
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
    }

    public class RegistroViewModel
    {
        public string Login { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
