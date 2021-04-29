using Microsoft.EntityFrameworkCore;
using senai.hroads.WebApi.Contexts;
using senai.hroads.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.WebApi.Repositories
{
    public class TipoHabilidadeRepository
    {
        HroadsContext cxt = new HroadsContext();
        public void Atualizar(int id, TipoHabilidade tipoHabilidadesAtualizado)
        {
            TipoHabilidade tipoHabilidadesBuscado = cxt.TipoHabilidades.Find(id);

            // Verifica se o nome do estúdio foi informado
            if (tipoHabilidadesAtualizado.Descricao != null)
            {
                // Atribui os novos valores aos campos existentes
                tipoHabilidadesBuscado.Descricao = tipoHabilidadesAtualizado.Descricao;
            }

            // Atualiza o estúdio que foi buscado
            cxt.TipoHabilidades.Update(tipoHabilidadesBuscado);

            // Salva as informações para serem gravadas no banco de dados
            cxt.SaveChanges();
        }

        public TipoHabilidade BuscarPorId(int id)
        {
            return cxt.TipoHabilidades.FirstOrDefault(tp => tp.IdTipoHabilidade == id);
        }

        public void Cadastrar(TipoHabilidade cadastrarTipoHabilidades)
        {
            cxt.TipoHabilidades.Add(cadastrarTipoHabilidades);

            // Salva as informações para serem gravadas no banco de dados
            cxt.SaveChanges();
        }

        public void Deletar(int id)
        {

            TipoHabilidade deletarTipoHabilidades = cxt.TipoHabilidades.Find(id);

            // Remove a classe que foi buscado
            cxt.TipoHabilidades.Remove(deletarTipoHabilidades);

            // Salva as alterações
            cxt.SaveChanges();
        }

        public List<TipoHabilidade> Listar()
        {
            return cxt.TipoHabilidades.ToList();
        }

        public List<TipoHabilidade> ListarHabilidades()
        {
            // Retorna uma lista de estúdios com seus jogos
            return cxt.TipoHabilidades.Include(tp => tp.Habilidades).ToList();
        }
    }
}
