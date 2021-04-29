using System;
using System.Collections.Generic;

#nullable disable

namespace senai.hroads.WebApi.Domains
{
    public partial class TipoHabilidade
    {
        public TipoHabilidade()
        {
            Habilidades = new HashSet<Habilidade>();
        }

        public int IdTipoHabilidade { get; set; }
        public string Descricao { get; set; }

        public virtual ICollection<Habilidade> Habilidades { get; set; }
    }
}
