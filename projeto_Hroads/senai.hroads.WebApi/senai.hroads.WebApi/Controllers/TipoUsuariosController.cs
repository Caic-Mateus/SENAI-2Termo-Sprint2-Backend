using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.hroads.WebApi.Domains;
using senai.hroads.WebApi.Interfaces;
using senai.hroads.WebApi.Repositories;
using senai_hroads_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class TipoUsuariosController : ControllerBase
    {
        private ITipoUsuarioRepository _tipousuarioRepository { get; set; }

        /// <summary>
        /// Instancia o objeto _habilidadeRepository para que haja a referência aos métodos do repositório
        /// </summary>
        public TipoUsuariosController()
        {
            _tipousuarioRepository = new TipoUsuarioRepository();
        }


        [HttpGet]
        public IActionResult Get()
        {

            return Ok(_tipousuarioRepository.Listar());
        }

        [HttpPost]
        public IActionResult Post(TipoUsuario novoTipo)
        {

            _tipousuarioRepository.Cadastrar(novoTipo);


            return StatusCode(201);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // Faz a chamada para o método
            _tipousuarioRepository.Deletar(id);

            // Retorna um status code
            return StatusCode(204);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, TipoUsuario tipoAtualizado)
        {
            // Faz a chamada para o método
            _tipousuarioRepository.Atualizar(id, tipoAtualizado);

            // Retorna um status code
            return StatusCode(204);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            // Retorna a resposta da requisição fazendo a chamada o método
            return Ok(_tipousuarioRepository.BuscarPorId(id));
        }
    }
}
