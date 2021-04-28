using senai.inlock.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.WebApi.Interfaces
{
    interface IUsuarioRepository
    {
        List<UsuarioDomain> Listar();

        UsuarioDomain BuscarPorId(int id);

        void Atualizar(int id, UsuarioDomain usuarioAtualizado);

        void Cadastrar(UsuarioDomain novoUsuario);

        void Deletar(int id);

        UsuarioDomain BuscarEmailSenha(string email, string senha);

    }
    
}
