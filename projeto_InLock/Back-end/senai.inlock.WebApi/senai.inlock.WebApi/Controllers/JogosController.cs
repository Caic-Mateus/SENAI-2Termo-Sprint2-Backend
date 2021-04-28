using Microsoft.AspNetCore.Mvc;
using senai.inlock.WebApi.Domains;
using senai.inlock.WebApi.Interfaces;
using senai.inlock.WebApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.WebApi.Controllers
{
    // Define que o tipo de resposta da API será no formato json
    [Produces("application/json")]

    // Define que a rota de uma requisição será no formato dominio/api/nomeController
    // ex: http://localhost:5000/api/generos
    [Route("api/[controller]")]

    // Define que é um controlador de API
    [ApiController]
    public class JogosController : ControllerBase 
    {
        /// <summary>
        /// Objeto _estudioRepository que irá receber todos os métodos definidos na interface 
        /// </summary>
        private IJogoRepository _jogoRepository { get; set; }

        /// <summary>
        /// Instancia o objeto _funcionarioRepository para que haja a referência aos métodos no repositório
        /// </summary>

        public JogosController()
        {
            _jogoRepository = new JogoRepository();
        }
        [HttpGet]
        public IActionResult Get()
        {
            // Cria uma lista nomeada listaJogos para receber os dados
            List<JogoDomain> listaJogos = _jogoRepository.ListarJogos();

            // Retorna o status code 200 (Ok) com a lista de gêneros no formato JSON
            return Ok(listaJogos);
        }
        [HttpPost]
        public IActionResult Post(JogoDomain novoJogo)
        {
            // Faz a chamada para o método .Cadastrar()
            _jogoRepository.Cadastrar(novoJogo);

            // Retorna um status code 201 - Created

            return StatusCode(201);
        }
    }
}
