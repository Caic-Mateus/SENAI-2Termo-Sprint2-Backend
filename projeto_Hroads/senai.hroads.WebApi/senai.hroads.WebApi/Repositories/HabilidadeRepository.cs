using Microsoft.EntityFrameworkCore;
using senai.hroads.WebApi.Contexts;
using senai.hroads.WebApi.Domains;
using senai_hroads_webApi.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace senai_hroads_webApi.Repositories
{
    public class HabilidadeRepository : IHabilidadeRepository
    {
        /// <summary>
        /// Objeto contexto por onde serão chamados os métodos do EF Core
        /// </summary>
        HroadsContext ctx = new HroadsContext();


        /// <summary>
        /// Atualiza uma habilidade existente
        /// </summary>
        /// <param name="id">ID da habilidade que será atualizada</param>
        /// <param name="classeAtualizada">Objeto habilidadeAtualizada com as novas informações</param>
        public void Atualizar(int id, Habilidade habilidadeAtualizada)
        {
            // Busca uma habilidade através do seu id
            Habilidade habilidadeBuscada = ctx.Habilidades.Find(id);

            // Verifica se o nome da habilidade foi informado
            if (habilidadeAtualizada.Nome != null)
            {
                // Atribui os novos valores aos campos existentes
                habilidadeBuscada.Nome = habilidadeAtualizada.Nome;
            }

            // Atualiza a habilidade que foi buscada
            ctx.Habilidades.Update(habilidadeBuscada);

            // Salva as informações para serem gravadas no banco de dados
            ctx.SaveChanges();
        }


        /// <summary>
        /// Busca uma habilidade através do seu ID
        /// </summary>
        /// <param name="id">ID da habilidade que será buscada</param>
        /// <returns>Uma habilidade buscada</returns>
        public Habilidade BuscarPorId(int id)
        {
            // Retorna a primeira habilidade encontrada para o ID informado
            return ctx.Habilidades.Include(h => h.IdTipoHabilidadeNavigation).FirstOrDefault(e => e.IdHabilidade == id);
        }

        /// <summary>
        /// Cadastra uma nova habilidade
        /// </summary>
        /// <param name="novaHabilidade">Objeto novaHabilidade que será cadastrado</param>
        public void Cadastrar(Habilidade novaHabilidade)
        {
            // Adiciona este novaHabilidade
            ctx.Habilidades.Add(novaHabilidade);

            // Salva as informações para serem gravadas no banco de dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Deleta uma habilidade existente
        /// </summary>
        /// <param name="id">ID da habilidade que será deletada</param>
        public void Deletar(int id)
        {
            // Busca uma habilidade através do seu id
            Habilidade habilidadeBuscada = ctx.Habilidades.Find(id);

            // Remove a habilidade que foi buscada
            ctx.Habilidades.Remove(habilidadeBuscada);

            // Salva as alterações
            ctx.SaveChanges();
        }

        public List<Habilidade> ListarTodas()
        {
            // Retorna uma lista de habilidades
            return ctx.Habilidades.Include(h=>h.IdTipoHabilidadeNavigation).ToList();
        }
    }
}
