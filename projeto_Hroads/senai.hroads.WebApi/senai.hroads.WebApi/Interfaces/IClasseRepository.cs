using senai.hroads.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_hroads_webApi.Interfaces
{
    /// <summary>
    /// Interface responsável pelo ClasseRepository
    /// </summary>
    interface IClasseRepository
    {
        /// <summary>
        /// Lista todas as Classes
        /// </summary>
        /// <returns>Retorna uma lista de classes </returns>
        List<Classe> ListarTodas();

        /// <summary>
        /// Busca uma classe pelo id
        /// </summary>
        /// <param name="id">Id da classe buscada</param>
        /// <returns>Classe buscada</returns>
        Classe BuscarPorId(int id);

        /// <summary>
        /// Cadastra uma nova classe
        /// </summary>
        /// <param name="novaClase"> Objeto novaClasse que será cadastrada</param>
        void Cadastrar(Classe novaClase);


        /// <summary>
        /// Atualiza uma classe já existente
        /// </summary>
        /// <param name="id">id da classe que será atualizada</param>
        /// <param name="classeAtualizada"> objeto classeAtualizada com as novas informações</param>
        void Atualizar(int id, Classe classeAtualizada);

        /// <summary>
        /// Deleta uma classe existente
        /// </summary>
        /// <param name="id">Id da classe que será deletada</param>
        void Deletar(int id);



    }
}
