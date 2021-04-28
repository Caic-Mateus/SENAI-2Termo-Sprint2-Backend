using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.WebApi.Domains
{
    public class UsuarioDomain
    {
        public int idUsuario { get; set; }
        
        [Required(ErrorMessage = "Informe seu e-mail")]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }

        [Required(ErrorMessage = "Informe seu e-mail")]
        public string senha { get; set; }

        public int idTipoUsuario { get; set; }

        public TipoUsuarioDomain tipoUsuario { get; set; }


    }
}
