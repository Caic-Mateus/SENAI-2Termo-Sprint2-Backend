using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.WebApi.Domains
{
    public class JogoDomain
    {
        public int idJogo { get; set; }


        [Required(ErrorMessage = "O nome do Jogo é obrigatório!")]
        public string nomeJogo { get; set; }

        [Required(ErrorMessage = "A descrição do jogo é obrigatória!")]
        public string descricao { get; set; }

        [Required(ErrorMessage = "A data de lançamento do jogo é obrigatória!")]
        [DataType(DataType.Date)]
        public DateTime dataLancamento { get; set; }

        [Required(ErrorMessage = "O valor do Jogo é obrigatório!")]
        public double valor { get; set; }

        [Required(ErrorMessage = "O id do Estudio é obrigatório!")]
        public int idEstudio { get; set; }
        public EstudioDomain estudio { get; set; }
    }
}
