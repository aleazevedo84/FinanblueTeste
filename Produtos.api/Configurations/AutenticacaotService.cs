using Microsoft.IdentityModel.Tokens;
using Produtos.Api.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Produtos.Api.Configurations
{
    public class AutenticacaotService : IAutenticacaoService
    {
        private readonly IConfiguration _configuration;

        public AutenticacaotService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GerarToken(UsuarioViewModel usuarioViewModel)
        {
            var secret = Encoding.ASCII.GetBytes(_configuration.GetSection("JwtConfiguration:Secret").Value);
            var symmetricSecurityKey = new SymmetricSecurityKey(secret);
            var securityTokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, usuarioViewModel.Id.ToString()),
                    new Claim(ClaimTypes.Name, usuarioViewModel.Login.ToString()),
                    new Claim(ClaimTypes.Email, usuarioViewModel.Email.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature)
            };
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var tokenGenerated = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);
            var token = jwtSecurityTokenHandler.WriteToken(tokenGenerated);

            return token;
        }
    }
}
