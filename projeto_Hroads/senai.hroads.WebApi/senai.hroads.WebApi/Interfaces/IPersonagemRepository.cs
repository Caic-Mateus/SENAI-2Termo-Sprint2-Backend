using senai.hroads.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_hroads_webApi.Interfaces
{
    interface IPersonagemRepository
    {
        /// <summary>
        /// Lista todas os Personagens
        /// </summary>
        /// <returns>Retorna uma lista de personagens </returns>
        List<Personagem> ListarTodos();

        /// <summary>
        /// Busca um personagem pelo id
        /// </summary>
        /// <param name="id">Id do personagem buscadao/param>
        /// <returns>Personagem buscado</returns>
        Personagem BuscarPorId(int id);

        /// <summary>
        /// Cadastra um novo personagem
        /// </summary>
        /// <param name="novaHabilidade"> Objeto novoPersonagem que será cadastrada</param>
        void Cadastrar(Personagem novoPersonagem);


        /// <summary>
        /// Atualiza um personagem já existente
        /// </summary>
        /// <param name="id">id do personagem que será atualizado</param>
        /// <param name="habilidadeAtualizada"> objeto personagemAtualizado com as novas informações</param>
        void Atualizar(int id, Personagem personagemAtualizado);

        /// <summary>
        /// Deleta um personagem existente
        /// </summary>
        /// <param name="id">Id do personagem que será deletado</param>
        void Deletar(int id);
    }
}