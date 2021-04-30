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
    public class HabilidadesController : ControllerBase
    {
        /// <summary>
        /// Objeto _habilidadeRepository que irá receber todos os métodos definidos na interface IHabilidadeRepository
        /// </summary>
        private IHabilidadeRepository _habilidadeRepository { get; set; }

        /// <summary>
        /// Instancia o objeto _habilidadeRepository para que haja a referência aos métodos do repositório
        /// </summary>
        public HabilidadesController()
        {
            _habilidadeRepository = new HabilidadeRepository();
        }



        /// <summary>
        /// Lista todos as habilidades
        /// </summary>
        /// <returns>Uma lista de habilidades e um status code 200 - Ok</returns>
        [HttpGet]
        public IActionResult Get()
        {
            // Retorna a resposta da requisição fazendo a chamada para o método
            return Ok(_habilidadeRepository.ListarTodas());
        }


        /// <summary>
        /// Cadastra uma nova habilidade
        /// </summary>
        /// <param name="novaClasse">Objeto novaHabilidade que será cadastrado</param>
        /// <returns>Um status code 201 - Created</returns>
        [Authorize(Roles = "Administrador")]
        [HttpPost]
        public IActionResult Post(Habilidade novaHabilidade)
        {
            // Faz a chamada para o método
            _habilidadeRepository.Cadastrar(novaHabilidade);

            // Retorna um status code
            return StatusCode(201);
        }


        /// <summary>
        /// Deleta uma habilidade existente
        /// </summary>
        /// <param name="id">ID da habilidade que será deletada</param>
        /// <returns>Um status code 204 - No Content</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // Faz a chamada para o método
            _habilidadeRepository.Deletar(id);

            // Retorna um status code
            return StatusCode(204);
        }




        /// <summary>
        /// Atualiza uma habilidade existente
        /// </summary>
        /// <param name="id">ID da habilidade que será atualizada</param>
        /// <param name="estudioAtualizado">Objeto habilidadeAtualizada com as novas informações</param>
        /// <returns>Um status code 204 - No Content</returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, Habilidade habilidadeAtualizada)
        {
            // Faz a chamada para o método
            _habilidadeRepository.Atualizar(id, habilidadeAtualizada);

            // Retorna um status code
            return StatusCode(204);
        }




        /// <summary>
        /// Busca uma habilidade através do seu ID
        /// </summary>
        /// <param name="id">ID da habilidade que será buscada</param>
        /// <returns>Uma habilidade buscada e um status code 200 - Ok</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            // Retorna a resposta da requisição fazendo a chamada o método
            return Ok(_habilidadeRepository.BuscarPorId(id));
        }
    }
}
