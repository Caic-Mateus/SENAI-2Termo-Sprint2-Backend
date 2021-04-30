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
    public class ClassesController : ControllerBase
    {
        /// <summary>
        /// Objeto _classeRepository que irá receber todos os métodos definidos na interface IClasseRepository
        /// </summary>
        private IClasseRepository _classeRepository { get; set; }

        /// <summary>
        /// Instancia o objeto _classeRepository para que haja a referência aos métodos do repositório
        /// </summary>
        public ClassesController()
        {
            _classeRepository = new ClasseRepository();
        }

        /// <summary>
        /// Lista todos as classes
        /// </summary>
        /// <returns>Uma lista de classes e um status code 200 - Ok</returns>
        [HttpGet]
        public IActionResult Get()
        {
            // Retorna a resposta da requisição fazendo a chamada para o método
            return Ok(_classeRepository.ListarTodas());
        }

        /// <summary>
        /// Cadastra uma nova classe
        /// </summary>
        /// <param name="novaClasse">Objeto novaClasse que será cadastrado</param>
        /// <returns>Um status code 201 - Created</returns>
        [Authorize(Roles = "Administrador")]
        [HttpPost]
        public IActionResult Post(Classe novaClasse)
        {
            // Faz a chamada para o método
            _classeRepository.Cadastrar(novaClasse);

            // Retorna um status code
            return StatusCode(201);
        }


        /// <summary>
        /// Deleta uma classe existente
        /// </summary>
        /// <param name="id">ID da classe que será deletada</param>
        /// <returns>Um status code 204 - No Content</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // Faz a chamada para o método
            _classeRepository.Deletar(id);

            // Retorna um status code
            return StatusCode(204);
        }


        /// <summary>
        /// Atualiza uma classe existente
        /// </summary>
        /// <param name="id">ID da classe que será atualizada</param>
        /// <param name="estudioAtualizado">Objeto classeAtualizada com as novas informações</param>
        /// <returns>Um status code 204 - No Content</returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, Classe classeAtualizada)
        {
            // Faz a chamada para o método
            _classeRepository.Atualizar(id, classeAtualizada);

            // Retorna um status code
            return StatusCode(204);
        }




        /// <summary>
        /// Busca uma classe através do seu ID
        /// </summary>
        /// <param name="id">ID da classe que será buscada</param>
        /// <returns>Uma classe buscada e um status code 200 - Ok</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            // Retorna a resposta da requisição fazendo a chamada o método
            return Ok(_classeRepository.BuscarPorId(id));
        }
    }
}
