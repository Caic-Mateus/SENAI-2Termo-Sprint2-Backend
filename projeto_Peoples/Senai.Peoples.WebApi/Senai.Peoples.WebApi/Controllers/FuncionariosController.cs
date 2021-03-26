using Microsoft.AspNetCore.Mvc;
using Senai.Peoples.WebApi.Domains;
using Senai.Peoples.WebApi.Interfaces;
using Senai.Peoples.WebApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Controllers
{
    // Define que o tipo de resposta da API será no formato json
    [Produces("application/json")]

    // Define que a rota de uma requisição será no formato dominio/api/nomeController
    // ex: http://localhost:5000/api/generos
    [Route("api/[controller]")]

    // Define que é um controlador de API
    [ApiController]

    public class FuncionariosController : ControllerBase
    {
        /// <summary>
        /// Objeto _funcionarioRepository que irá receber todos os métodos definidos na interface 
        /// </summary>
        private IFuncionarioRepository _funcionarioRepository { get; set; }

        /// <summary>
        /// Instancia o objeto _funcionarioRepository para que haja a referência aos métodos no repositório
        /// </summary>

        public FuncionariosController()
        {
            _funcionarioRepository = new FuncionarioRepository();
        }
        /// <summary>
        /// Lista todos os gêneros
        /// </summary>
        /// <returns>Uma lista de gêneros e um status code</returns>
        /// http://localhost:5000/api/generos
        [HttpGet]
        public IActionResult Get()
        {
            // Cria uma lista nomeada listaFuncionarios para receber os dados
            List<FuncionarioDomain> listaFuncionarios = _funcionarioRepository.ListarTodos();

            // Retorna o status code 200 (Ok) com a lista de gêneros no formato JSON
            return Ok(listaFuncionarios);
        }

        /// <summary>
        /// Busca um funcionario atraves do id
        /// </summary>
        /// <param name="id">id do genero que sera buscado</param>
        /// <returns>Um funcionario buscado ou NotFound caso não seja encontrado</returns>
        [HttpGet("{id}")]
        public IActionResult GetByld(int id)
        {
            // Cria um objeto funcionarioBuscado que irá receber o funcionario buscado no banco de dados
            FuncionarioDomain funcionarioBuscado = _funcionarioRepository.BuscarPorId(id);

            // Verifica se nenhum funcionario foi encontrado
            if (funcionarioBuscado == null)
            {
                // Caso nao seja encontrado retorna 404- not found
                return NotFound("Nenhum funcionario encontrado!");
            }
            // Caso seja encontrado retorna o genero e o status 200 Ok
            return Ok(funcionarioBuscado);
        }
        /// <summary>
        /// Cadastra um novo funcionario
        /// </summary>
        /// <returns>Um status code 201 - Created </returns>
        [HttpPost]
        public IActionResult Post(FuncionarioDomain novoFuncionario)
        {
            // Faz a chamada para o método .Cadastrar()
            _funcionarioRepository.Cadastrar(novoFuncionario);

            // Retorna um status code 201 - Created

            return StatusCode(201);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // Faz a chamada para o metodo .Deletar()
            _funcionarioRepository.Deletar(id);

            // Retorna um status code 204 - No Content
            return StatusCode(204);
        }
        /// <summary>
        /// Atualiza um funcionario passando o seu id pela url da requisição
        /// </summary>
        /// <param name="id">id do funcionario que será atualizado</param>
        /// <param name="funcionarioAtualizado">objeto funcionario atualizado com as novas informaçoes </param>
        /// <returns>status code</returns>
        /// ///  // http://localhost:5000/api/generos/1
        [HttpPut("{id}")]
        public IActionResult PutIdUrl(int id, FuncionarioDomain funcionarioAtualizado)
        {
            // Cria o objeto que ira receber o funcionario buscado no banco de dados
            FuncionarioDomain funcionarioBuscado = _funcionarioRepository.BuscarPorId(id);

            // Caso não for encontrado retorna NotFound com uma mensagem personalizada
            // e um bool para apresentar que houve erro
            if (funcionarioBuscado == null)
            {
                return NotFound
                    (
                    new
                    {
                        mensagem = "Funcionario não encontrado!",
                        erro = true
                    }

                   );
            }
            // Tenta atualizar o registro
            try
            {
                // Faz a chamada para o metod .AtualizarIdUrl
                _funcionarioRepository.AtualizarIdUrl(id, funcionarioAtualizado);

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
