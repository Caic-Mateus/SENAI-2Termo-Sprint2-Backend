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
            // Outra forma, caso os dados da inscrição (novaa consulta) sejam enviados pelo usuario
            // independente do status que o usuario tente cadastrar ao se inscrever
            // por padrão, a situação será sempre "Não confirmada"
            //novaConsulta.IdSituacaoNavigation.Situacao1 = "Não confirmada";
            
            // adiciona uma nova presença
            ctx.Consulta.Add(novaConsulta);

            // Salva as informações no banco de dados
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
            Consultum consultabuscada = ctx.Consulta
                .Include(c => c.IdPacienteNavigation)
                .Include(c => c.IdMedicoNavigation)
                .FirstOrDefault(c => c.IdConsulta == id);

            switch (status)
            {
                case "0":
                    consultabuscada.IdSituacaoNavigation.Situacao1 = "Cancelada";
                    break;
                case "1":
                    consultabuscada.IdSituacaoNavigation.Situacao1 = "Confirmada";
                    break;

                case "2":
                    consultabuscada.IdSituacaoNavigation.Situacao1 = "Agendada";
                    break;
                default:
                    consultabuscada.IdSituacaoNavigation.Situacao1 = consultabuscada.IdSituacaoNavigation.Situacao1;
                    break;
            }
            ctx.    Consulta.Update(consultabuscada);
            ctx.SaveChanges();
        }
    }
    }
