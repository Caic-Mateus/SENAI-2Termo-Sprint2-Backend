using senai.inlock.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.WebApi.Interfaces
{
    interface ITipoUsuarioRepository
    {

        List<TipoUsuarioDomain> Listar();

        TipoUsuarioDomain BuscarPorId(int id);
    }
}
