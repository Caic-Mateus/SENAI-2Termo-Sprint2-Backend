using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Domains
{
    /// <summary>
    /// Classe responsavel a entidade Funcionarios
    /// </summary>
    public class FuncionarioDomain
    {
       public int idFuncionario{get; set;}
        public string nome { get; set; }
        public string sobrenome { get; set; }
    }
}
