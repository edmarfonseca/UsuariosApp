using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using UsuariosApp.Domain.Entities;
using UsuariosApp.Domain.Interfaces.Security;
using UsuariosApp.Infra.Security.Settings;

namespace UsuariosApp.Infra.Security.Services
{
    public class JwtTokenService : IJwtTokenService
    {
        public string GenerateToken(Usuario usuario)
        {
            //capturando a chave que será utilizada para assinar/criptografar o token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(JwtTokenSettings.SecretKey);

            //gerando o conteúdo do token
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                //identificação do usuário
                Subject = new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.Name, usuario.Email) }),
                //data de expiração do token
                Expires = GenerateExpirationDate(),
                //assinatura do token (chave antifalsificação)
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), 
                    SecurityAlgorithms.HmacSha256Signature)
            };

            //gerando e retornando o token
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public DateTime GenerateExpirationDate()
        {
            return DateTime.UtcNow.AddHours(JwtTokenSettings.ExpirationInHours);
        }
    }
}
