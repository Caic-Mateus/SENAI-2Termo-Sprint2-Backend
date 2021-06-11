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
            return ctx.Consulta.FirstOrDefault(x => x.IdConsulta == id);
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
                case "1":
                    consultabuscada.IdSituacao = 1;
                    break;
                case "2":
                    consultabuscada.IdSituacao = 2;
                    break;

                case "3":
                    consultabuscada.IdSituacao = 3;
                    break;
                default:
                    consultabuscada.IdSituacao = consultabuscada.IdSituacao;
                    break;
            }
            ctx.    Consulta.Update(consultabuscada);
            ctx.SaveChanges();
        }

        // Método para inserir ou editar uma descrição nas consultas
        public void InserirDescricao (int id, Consultum descricao, int idUsuario )
        {
            Consultum consultaBuscada = ctx.Consulta.FirstOrDefault(x => x.IdConsulta == id);

            Medico medicoBuscado = ctx.Medicos.FirstOrDefault(x => x.IdUsuario == idUsuario);

            if (descricao.Descricao != null && consultaBuscada.IdMedico == medicoBuscado.IdMedico)
            {
                consultaBuscada.Descricao = descricao.Descricao;
            }

            ctx.Consulta.Update(consultaBuscada);

            ctx.SaveChanges();
        }
    }
    }
