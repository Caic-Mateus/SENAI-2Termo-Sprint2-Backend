using senai.spmedicalgroup.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.spmedicalgroup.webApi.Interfaces
{
    interface IConsultaRepository
    {
        /// <summary>
        /// Agenda uma nova consulta
        /// </summary>
        /// <param name="novaConsulta">objeto com os dados da nova consulta</param>
        void Cadastrar(Consultum novaConsulta);

        /// <summary>
        /// Lista as consultas do paciente logado
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        List<Consultum> ListarMinhas(int id);

        Consultum BuscarPorId(int id);

        void StatusConsulta(int id, string status);
      

        void Atualizar(int id, Consultum consultaAtualizada);

        void Deletar(int id);

    }
}
