using senai.inlock.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.WebApi.Interfaces
{
    interface IJogoRepository
    {
        List<JogoDomain> ListarJogos();

        JogoDomain BuscarPorId(int id);

        void Cadastrar(JogoDomain novoJogo);

        void Deletar(int id);


        void AtualizarIdUrl(int id, JogoDomain jogo);
    }
}
