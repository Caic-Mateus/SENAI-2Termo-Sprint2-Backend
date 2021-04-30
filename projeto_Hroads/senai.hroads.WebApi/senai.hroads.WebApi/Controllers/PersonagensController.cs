using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.hroads.WebApi.Domains;
using senai_hroads_webApi.Interfaces;
using senai_hroads_webApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_hroads_webApi.Controllers
{
    // Define que o tipo de resposta da API será no formato JSON
    [Produces("application/json")]

    // Define que a rota de uma requisição será no formato dominio/api/nomeController
    // ex: http://localhost:5000/api/classes
    [Route("api/[controller]")]

    // Define que é um controlador de API
    [ApiController]
    public class PersonagensController : ControllerBase
    {

        /// <summary>
        /// Objeto _habilidadeRepository que irá receber todos os métodos definidos na interface IHabilidadeRepository
        /// </summary>
        private IPersonagemRepository _personagemRepository { get; set; }

        /// <summary>
        /// Instancia o objeto _habilidadeRepository para que haja a referência aos métodos do repositório
        /// </summary>
        public PersonagensController()
        {
            _personagemRepository = new PersonagemRepository();
        }

        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
          
            return Ok(_personagemRepository.ListarTodos());
        }


        [Authorize(Roles = "Jogador")]
        [HttpPost]
        public IActionResult Post(Personagem novoPersonagem)
        {
            
            _personagemRepository.Cadastrar(novoPersonagem);

            
            return StatusCode(201);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // Faz a chamada para o método
            _personagemRepository.Deletar(id);

            // Retorna um status code
            return StatusCode(204);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Personagem personagemAtualizado)
        {
            // Faz a chamada para o método
            _personagemRepository.Atualizar(id, personagemAtualizado);

            // Retorna um status code
            return StatusCode(204);
        }


        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            // Retorna a resposta da requisição fazendo a chamada o método
            return Ok(_personagemRepository.BuscarPorId(id));
        }
    }   



}
