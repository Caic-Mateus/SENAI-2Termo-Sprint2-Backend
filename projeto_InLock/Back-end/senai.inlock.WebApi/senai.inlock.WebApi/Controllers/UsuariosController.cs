using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using senai.inlock.WebApi.Domains;
using senai.inlock.WebApi.Interfaces;
using senai.inlock.WebApi.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace senai.inlock.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }

        public UsuariosController()
        {
            _usuarioRepository = new UsuarioRepository();
        }


        [HttpPost("login")]
        public IActionResult Login(UsuarioDomain login)
        {
            UsuarioDomain usuarioBuscado = _usuarioRepository.BuscarEmailSenha(login.email, login.senha);

            if (usuarioBuscado != null)
            {
                var claims = new[]
                {                                   //Tipo da Claim,Valor da claim
                    new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.email),
                    new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.idUsuario.ToString()),
                    new Claim(ClaimTypes.Role, usuarioBuscado.tipoUsuario.permissao)
                    //Role é utilizado para permissão, Jti para id
                };
                                                         
                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("inlock-chave-autenticacao"));

                //Define Credenciais do token - Header
                var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                
                //Gera o token
                var token = new JwtSecurityToken(
                    issuer: "InLock.webAPI",       //emissor do token
                    audience: "InLock.webAPI",    // destinatatio do token
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


        [Authorize(Roles = "Administrador")]
        [HttpGet]
        public IActionResult Get()
        {
            List<UsuarioDomain> listaUsuarios = _usuarioRepository.Listar();

            return Ok(listaUsuarios);
        }

        [Authorize(Roles = "Administrador")]
        [HttpPut("{id}")]
        public IActionResult PutIdUrl(int id, UsuarioDomain usuarioAtualizado)
        {
            UsuarioDomain usuarioBuscado = _usuarioRepository.BuscarPorId(id);

            if (usuarioBuscado == null)
            {
                return NotFound(new { mensagem = "Usuário não encontrado!" });
            }

            try
            {
                _usuarioRepository.Atualizar(id, usuarioAtualizado);

                return NoContent();
            }

            catch (Exception codErro)
            {
                return BadRequest(codErro);
            }
        }

        [Authorize(Roles = "Administrador")]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            // cria um objeto "funcionarioBuscado" que irá receber o "funcionarioBuscado" no banco de dados
            UsuarioDomain usuarioBuscado = _usuarioRepository.BuscarPorId(id);
            // um "=" é atribuição, um "==" é uma comparação

            // verifica se nenhum funcionário foi encontrado
            if (usuarioBuscado == null)
            {
                // caso não seja encontrado, retorna um status code 404 - Not Found com uma mensagem personalizada
                return NotFound("Nenhum usuário encontrado!");
            }

            // caso seja encontrado, retorna o funcionário buscado com um status code 200 - Ok
            return Ok(usuarioBuscado);
        }


        [HttpPost]
        public IActionResult Post(UsuarioDomain novoUsuario)
        {
            try // tenta executar...
            {
                // se o conteúdo do nome e/ou do sobrenome do novo funcionário estar vazio ou com um espaço em branco...
                if (String.IsNullOrWhiteSpace(novoUsuario.email))
                {
                    // retorna um status code 404 - Not Found com uma mensagem personalizada
                    return NotFound("Campo 'email' obrigatório!");
                }

                if (String.IsNullOrWhiteSpace(novoUsuario.senha))
                {
                    // retorna um status code 404 - Not Found com uma mensagem personalizada
                    return NotFound("Campo 'senha' obrigatório!");
                }

                // se estiver tudo preenchido...
                else
                    // faz a chamada para o método Cadastrar
                    _usuarioRepository.Cadastrar(novoUsuario);

                // e retorna o status code 201 - Created
                return StatusCode(201);
            }

            // se não conseguiu executar...
            catch (Exception codErro)
            {
                // retorna um status code 400 - BadRequest e o código do erro
                return BadRequest(codErro);
            }
        }

        [Authorize(Roles = "Administrador")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // faz a chamada para o método .Deletar
            _usuarioRepository.Deletar(id);

            // retorna o status code 204 - No Content
            return StatusCode(204);
        }
    }
}

