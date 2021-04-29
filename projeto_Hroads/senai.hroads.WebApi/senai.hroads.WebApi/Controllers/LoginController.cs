using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using senai.hroads.WebApi.Domains;
using senai.hroads.WebApi.Interfaces;
using senai.hroads.WebApi.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace senai.hroads.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }

        /// <summary>
        /// Instancia o objeto _habilidadeRepository para que haja a referência aos métodos do repositório
        /// </summary>
        public LoginController()
        {
            _usuarioRepository = new UsuarioRepository();
        }
        [HttpPost]
        public IActionResult Login(Usuario login)
        {
            Usuario usuarioBuscado = _usuarioRepository.Logar(login.Email, login.Senha);

            if (usuarioBuscado != null)
            {
                var claims = new[]
                {                                   //Tipo da Claim,Valor da claim
                    new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.IdUsuario.ToString()),
                    new Claim(ClaimTypes.Role, usuarioBuscado.TipoUsuario.Permissao)
                    //Role é utilizado para permissão, Jti para id
                };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("senha"));

                //Define Credenciais do token - Header
                var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                //Gera o token
                var token = new JwtSecurityToken(
                    issuer: "Hroads.webApi",       //emissor do token
                    audience: "Hroads.webAPI",    // destinatatio do token
                    claims: claims,               // dados definidos acima (linha 45)
                    expires: DateTime.Now.AddMinutes(5),   // tempo de expiração
                    signingCredentials: credentials    //credenciais do token
                );

                return Ok(
                    new
                    {
                        token = new JwtSecurityTokenHandler().WriteToken(token)
                    }
                );
            }

            return NotFound("Email ou senha inválidos!");
        }
    }
}
