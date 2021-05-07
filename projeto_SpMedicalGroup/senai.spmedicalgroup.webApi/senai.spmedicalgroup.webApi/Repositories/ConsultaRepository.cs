using Microsoft.EntityFrameworkCore;
using senai.spmedicalgroup.webApi.Contexts;
using senai.spmedicalgroup.webApi.Domains;
using senai.spmedicalgroup.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.spmedicalgroup.webApi.Repositories
{
   
        public class ConsultaRepository : IConsultaRepository
        {
            SpMedicalContext ctx = new SpMedicalContext();

            public void Atualizar(int id, Consultum consultaAtualizada)
            {
                throw new NotImplementedException();
            }

            public Consultum BuscarPorId(int id)
            {
                throw new NotImplementedException();
            }

            public void Cadastrar(Consultum novaConsulta)
            {
                ctx.Consulta.Add(novaConsulta);


                ctx.SaveChanges();

            }

            public void Deletar(int id)
            {
                throw new NotImplementedException();
            }

            public List<Consultum> ListarMinhas(int id)
            {
            return ctx.Consulta
                .Include(p => p.IdMedicoNavigation )
                .Include(p => p.IdMedicoNavigation.IdEspecialidadeNavigation)
                .Include(p => p.IdMedicoNavigation.IdClinicaNavigation)
                .Where( p => p.IdPaciente == id)
                .ToList();
            }

        public void StatusConsulta(int id, string status)
        {
            throw new NotImplementedException();
        }
    }
    }
