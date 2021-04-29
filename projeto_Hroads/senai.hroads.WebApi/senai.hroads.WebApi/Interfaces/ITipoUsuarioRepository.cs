using senai.hroads.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.WebApi.Interfaces
{
    interface ITipoUsuarioRepository
    {
        List<TipoUsuario> Listar();

        TipoUsuario BuscarPorId(int id);


        void Cadastrar(TipoUsuario cadastrarTipoUsario);


        void Atualizar(int id, TipoUsuario tipoAtualizado);


        void Deletar(int id);
    }
}
