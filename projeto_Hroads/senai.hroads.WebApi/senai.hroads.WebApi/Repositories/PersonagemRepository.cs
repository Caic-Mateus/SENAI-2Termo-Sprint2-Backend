using Microsoft.EntityFrameworkCore;
using senai.hroads.WebApi.Contexts;
using senai.hroads.WebApi.Domains;
using senai_hroads_webApi.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace senai_hroads_webApi.Repositories
{
    public class PersonagemRepository : IPersonagemRepository
    {

        /// <summary>
        /// Objeto contexto por onde serão chamados os métodos do EF Core
        /// </summary>
        HroadsContext ctx = new HroadsContext();

        public void Atualizar(int id, Personagem personagemAtualizado)
        {
           
            Personagem personagemBuscado = ctx.Personagems.Find(id);

            
            if (personagemAtualizado.Nome != null)
            {
           
                personagemBuscado.Nome = personagemAtualizado.Nome;
            }

            
            ctx.Personagems.Update(personagemBuscado);

            
            ctx.SaveChanges();
        }

        public Personagem BuscarPorId(int id)
        {
           
            return ctx.Personagems.Include(h => h.IdClasseNavigation).FirstOrDefault(e => e.IdPersonagem == id);
        }

        public void Cadastrar(Personagem novoPersonagem)
        {
            
            ctx.Personagems.Add(novoPersonagem);

            
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Personagem personagemBuscado = ctx.Personagems.Find(id);

            
            ctx.Personagems.Remove(personagemBuscado);

           
            ctx.SaveChanges();
        }

        public List<Personagem> ListarTodos()
        {
            // Retorna uma lista de personagens
            return ctx.Personagems.Include(p => p.IdClasseNavigation).ToList();
        }
    }
}
