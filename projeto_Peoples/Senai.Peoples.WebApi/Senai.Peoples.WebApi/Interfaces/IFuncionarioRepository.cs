using Senai.Peoples.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Interfaces
{
    interface IFuncionarioRepository
    {
        List<FuncionarioDomain> ListarTodos();

        /// <summary>
        /// Busca um funcionario através do seu id
        /// </summary>
        /// <param name="id">id do funcionario que será buscado</param>
        /// <returns>Um objeto funcionario que foi buscado</returns>
        FuncionarioDomain BuscarPorId(int id);

        /// <summary>
        /// Cadastra um novo funcionario
        /// </summary>
        /// <param name="novoGenero">Objeto novoFuncionario com as informações que serão cadastradas</param>
        void Cadastrar(FuncionarioDomain novoFuncionario);

       
        void AtualizarIdCorpo(FuncionarioDomain funcionario);

        
        void AtualizarIdUrl(int id, FuncionarioDomain genero);

        /// <summary>
        /// Deleta um gênero existente
        /// </summary>
        /// <param name="id">id do gênero que será deletado</param>
        void Deletar(int id);
    }
}

    