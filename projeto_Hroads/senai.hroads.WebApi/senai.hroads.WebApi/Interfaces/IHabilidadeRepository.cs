using senai.hroads.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_hroads_webApi.Interfaces
{
    interface IHabilidadeRepository
    {
        /// <summary>
        /// Lista todas as Habilidades
        /// </summary>
        /// <returns>Retorna uma lista de habilidades </returns>
        List<Habilidade> ListarTodas();

        /// <summary>
        /// Busca uma habilidade pelo id
        /// </summary>
        /// <param name="id">Id da habilidade buscada</param>
        /// <returns>Habilidade buscada</returns>
        Habilidade BuscarPorId(int id);

        /// <summary>
        /// Cadastra uma nova habilidade
        /// </summary>
        /// <param name="novaHabilidade"> Objeto novaHabilidade que será cadastrada</param>
        void Cadastrar(Habilidade novaHabilidade);


        /// <summary>
        /// Atualiza uma habilidade já existente
        /// </summary>
        /// <param name="id">id da habilidade que será atualizada</param>
        /// <param name="habilidadeAtualizada"> objeto habilidadeAtualizada com as novas informações</param>
        void Atualizar(int id, Habilidade habilidadeAtualizada);

        /// <summary>
        /// Deleta uma habilidade existente
        /// </summary>
        /// <param name="id">Id da habilidade que será deletada</param>
        void Deletar(int id);
    }
}
