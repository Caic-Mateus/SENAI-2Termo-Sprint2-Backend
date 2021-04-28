using senai.inlock.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.WebApi.Interfaces
{
    interface IEstudioRepository
    {
        List<EstudioDomain> ListarEstudios();

        EstudioDomain BuscarPorId(int id);

        void Cadastrar(EstudioDomain novoEstudio);

        void Deletar(int id);

       
        void AtualizarIdUrl(int id, EstudioDomain estudio);




    }
}
