using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.spmedicalgroup.webApi.Domains;
using senai.spmedicalgroup.webApi.Interfaces;
using senai.spmedicalgroup.webApi.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace senai.spmedicalgroup.webApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultasController : ControllerBase
    {
        private IConsultaRepository _consultaRepository { get; set; }

        /// <summary>
        /// Instancia o objeto _habilidadeRepository para que haja a referência aos métodos do repositório
        /// </summary>
        public ConsultasController()
        {
            _consultaRepository = new ConsultaRepository();
        }
        [HttpGet("paciente")]
        public IActionResult GetPac()
        {
            try
            {
                int id = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);
                return Ok(_consultaRepository.ListarMinhas(id));
            }
            catch (Exception ex)
            {

                return BadRequest(new
                {
                    mensagem = "",
                    ex
                });
            }

        }

        [HttpPost]
        public IActionResult Post(Consultum novaConsulta)
        {

            _consultaRepository.Cadastrar(novaConsulta);


            return StatusCode(201);
        }
    }
}
