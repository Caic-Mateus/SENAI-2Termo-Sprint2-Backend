using senai.hroads.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.WebApi.Interfaces
{
    interface IUsuarioRepository
    {
        List<Usuario> Listar();

        Usuario BuscarPorId(int id);


        void Cadastrar(Usuario cadastrarUsario);


        void Atualizar(int id, Usuario usuarioAtualizado);

        Usuario Logar(string email, string senha);

        void Deletar(int id);
    }
}
