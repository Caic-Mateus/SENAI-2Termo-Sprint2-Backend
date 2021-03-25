using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai_filmes_webApi.Domains;
using senai_filmes_webApi.Interfaces;
using senai_filmes_webApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
/// Controller responsável pelos endpoints referentes aos gêneros
/// </summary>
namespace senai_filmes_webApi.Controllers
{
    // Define que o tipo de resposta da API será no formato json
    [Produces("application/json")]

    // Define que a rota de uma requisição será no formato dominio/api/nomeController
    // ex: http://localhost:5000/api/generos
    [Route("api/[controller]")]

    // Define que é um controlador de API
    [ApiController]

    public class GenerosController : ControllerBase
    {
        /// <summary>
        /// Objeto _generoRepository que irá receber todos os métodos definidos na interface IGeneroRepository
        /// </summary>
        private IGeneroRepository _generoRepository { get; set; }

        /// <summary>
        /// Instancia o objeto _generoRepository para que haja a referência aos métodos no repositório
        /// </summary>
        public GenerosController()
        {
            _generoRepository = new GeneroRepository();
        }

        /// <summary>
        /// Lista todos os gêneros
        /// </summary>
        /// <returns>Uma lista de gêneros e um status code</returns>
        /// http://localhost:5000/api/generos
        [HttpGet]
        public IActionResult Get()
        {
            // Cria uma lista nomeada listaGeneros para receber os dados
            List<GeneroDomain> listaGeneros = _generoRepository.ListarTodos();

            // Retorna o status code 200 (Ok) com a lista de gêneros no formato JSON
            return Ok(listaGeneros);
        }

        /// <summary>
        /// Busca um genero atraves do id
        /// </summary>
        /// <param name="id">id do genero que sera buscado</param>
        /// <returns>Um generp buscado ou NotFound caso não seja encontrado</returns>
        [HttpGet("{id}")]
        public IActionResult GetByld(int id)
        {
            // Cria um objeto generoBuscado que irá receber o genero buscado no banco de dados
            GeneroDomain generoBuscado = _generoRepository.BuscarPorId(id);

            // Verifica se nenhum genero foi encontrado
            if (generoBuscado == null)
            {
                // Caso nao seja encontrado retorna 404- not found
                return NotFound("Nenhum gênero encontrado!");
            }
            // Caso seja encontrado retorna o genero e o status 200 Ok
            return Ok(generoBuscado);
        }
        /// <summary>
        /// Cadastra um novo genero
        /// </summary>
        /// <returns>Um status code 201 - Created </returns>
        ///  // http://localhost:5000/api/generos
        [HttpPost]
        public IActionResult Post(GeneroDomain novoGenero)
        {
            // Faz a chamada para o método .Cadastrar()
            _generoRepository.Cadastrar(novoGenero);

            // Retorna um status code 201 - Created

            return StatusCode(201);
        }

        /// <summary>
        /// Atualiza um genero existente passando o seu id pela url da requisição
        /// </summary>
        /// <param name="id">id do genero que será atualizado</param>
        /// <param name="generoAtualizado">objeto genero atualizado com as novas informaçoes </param>
        /// <returns>status code</returns>
        /// ///  // http://localhost:5000/api/generos/1
        [HttpPut("{id}")]
        public IActionResult PutIdUrl(int id, GeneroDomain generoAtualizado)
        {
            // Cria o objeto que ira receber o genero buscado no banco de dados
            GeneroDomain generoBuscado = _generoRepository.BuscarPorId(id);

            // Caso não for encontrado retorna NotFound com uma mensagem personalizada
            // e um bool para apresentar que houve erro
            if (generoBuscado == null)
            {
                return NotFound
                    (
                    new
                    {
                        mensagem = "Gênero não encontrado!",
                        erro = true
                    }

                   );
            }
            // Tenta atualizar o registro
            try
            {
                // Faz a chamada para o metod .AtualizarIdUrl
                _generoRepository.AtualizarIdUrl(id, generoAtualizado);

                //Retorna um status code 204 - No Content
                return NoContent();
            }
            //Caso ocorra algum erro
            catch (Exception codErro)
            {
                // Retorna um status code 400 - CadRequest e o codigo do erro
                return BadRequest(codErro);
            }
        }
        /// <summary>
        /// Atualiza um genero passando seu id pelo corpo
        /// </summary>
        /// <param name="generoAtualizado"> Obejto com as novas informaçoes</param>
        /// <returns>status code</returns>
        [HttpPut]
        public IActionResult PutIdBody(GeneroDomain generoAtualizado)
        {
            GeneroDomain generoBuscado = _generoRepository.BuscarPorId(generoAtualizado.idGenero);
            if (generoBuscado != null)
            {
                //Tenta atualizar o registro
                try
                {
                    _generoRepository.AtualizarIdCorpo(generoAtualizado);

                    return NoContent();
                }
                catch (Exception codErro)
                {

                    return BadRequest(codErro);
                }
            }

            return NotFound
                (
                    new
                    {
                        mensegaem = " Genero nao encontrado"
                    }
                );
        }
    
	

	
        /// <summary>
        /// Deleta um genero existente 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Um status code 204 - No Content</returns>
        /// htpp://localhost:5000/api/generos/11
        [HttpDelete ("{id}")]
        public IActionResult Delete (int id)
        {
            // Faz a chamada para o metodo .Deletar()
            _generoRepository.Deletar(id);

            // Retorna um status code 204 - No Content
            return StatusCode(204);
        }
    }
}
