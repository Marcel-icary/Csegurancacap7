using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Csegurancacap7.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        // Método de login que gera um token JWT
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel model)
        {
            // Verifica se o nome de usuário e a senha são válidos
            if (model.Username == "user" && model.Password == "password")
            {
                // Cria um manipulador para o token JWT
                var tokenHandler = new JwtSecurityTokenHandler();
                // Define a chave secreta para assinar o token
                var key = Encoding.ASCII.GetBytes("s3cr3tK3yForJWTs1gn1ng12345678901234"); // Mesma chave secreta
                // Define o descritor do token com as informações de assinatura e validade
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[] { new Claim("id", "1") }), // Adiciona um claim de id
                    Expires = DateTime.UtcNow.AddHours(1), // Define a validade do token para 1 hora
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature) // Assina o token com a chave secreta
                };
                // Cria o token JWT
                var token = tokenHandler.CreateToken(tokenDescriptor);
                // Escreve o token JWT como uma string
                var tokenString = tokenHandler.WriteToken(token);

                // Retorna o token JWT gerado
                return Ok(new { Token = tokenString });
            }

            // Retorna Unauthorized se o login falhar
            return Unauthorized();
        }
    }

    // Modelo de dados para o login
    public class LoginModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
