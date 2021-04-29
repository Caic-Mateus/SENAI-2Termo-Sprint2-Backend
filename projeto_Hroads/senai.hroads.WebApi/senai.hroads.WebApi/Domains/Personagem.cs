using System;
using System.Collections.Generic;

#nullable disable

namespace senai.hroads.WebApi.Domains
{
    public partial class Personagem
    {
        public int IdPersonagem { get; set; }
        public int? IdClasse { get; set; }
        public string Nome { get; set; }
        public int MaxVida { get; set; }
        public int MaxMana { get; set; }
        public DateTime DataAtt { get; set; }
        public DateTime DataCriacao { get; set; }

        public virtual Classe IdClasseNavigation { get; set; }
    }
}
