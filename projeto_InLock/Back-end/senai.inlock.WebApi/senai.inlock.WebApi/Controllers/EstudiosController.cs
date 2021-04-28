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

    public class EstudiosController : ControllerBase
    {
        /// <summary>
        /// Objeto _estudioRepository que irá receber todos os métodos definidos na interface 
        /// </summary>
        private IEstudioRepository _estudioRepository { get; set; }

        /// <summary>
        /// Instancia o objeto _funcionarioRepository para que haja a referência aos métodos no repositório
        /// </summary>

        public EstudiosController()
        {
            _estudioRepository = new EstudioRepository();
        }
        [HttpGet]
        public IActionResult Get()
        {
            // Cria uma lista nomeada listaFuncionarios para receber os dados
            List<EstudioDomain> listaEstudios = _estudioRepository.ListarEstudios();

            // Retorna o status code 200 (Ok) com a lista de gêneros no formato JSON
            return Ok(listaEstudios);
        }

        
        [HttpGet("{id}")]
        public IActionResult GetByld(int id)
        {
            // Cria um objeto funcionarioBuscado que irá receber o funcionario buscado no banco de dados
            EstudioDomain estudioBuscado = _estudioRepository.BuscarPorId(id);

            // Verifica se nenhum funcionario foi encontrado
            if (estudioBuscado == null)
            {
                // Caso nao seja encontrado retorna 404- not found
                return NotFound("Nenhum estudio encontrado!");
            }
            // Caso seja encontrado retorna o genero e o status 200 Ok
            return Ok(estudioBuscado);
        }

        [HttpPost]
        public IActionResult Post(EstudioDomain novoEstudio)
        {
            // Faz a chamada para o método .Cadastrar()
            _estudioRepository.Cadastrar(novoEstudio);

            // Retorna um status code 201 - Created

            return StatusCode(201);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // Faz a chamada para o metodo .Deletar()
            _estudioRepository.Deletar(id);

            // Retorna um status code 204 - No Content
            return StatusCode(204);
        }

        /// <summary>
        /// Atualiza um estudio passando o seu id pela url da requisição
        /// </summary>
        /// <param name="id">id do estudio que será atualizado</param>
        /// <param name="estudioAtualizado">objeto estudio atualizado com as novas informaçoes </param>
        /// <returns>status code</returns>
        /// ///  // http://localhost:5000/api/generos/1
        [HttpPut("{id}")]
        public IActionResult PutIdUrl(int id, EstudioDomain estudioAtualizado)
        {
            // Cria o objeto que ira receber o funcionario buscado no banco de dados
            EstudioDomain estudioBuscado = _estudioRepository.BuscarPorId(id);

            // Caso não for encontrado retorna NotFound com uma mensagem personalizada
            // e um bool para apresentar que houve erro
            if (estudioBuscado == null)
            {
                return NotFound
                    (
                    new
                    {
                        mensagem = "Estudio não encontrado!",
                        erro = true
                    }

                   );
            }
            // Tenta atualizar o registro
            try
            {
                // Faz a chamada para o metod .AtualizarIdUrl
                _estudioRepository.AtualizarIdUrl(id, estudioAtualizado);

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
        }
}
