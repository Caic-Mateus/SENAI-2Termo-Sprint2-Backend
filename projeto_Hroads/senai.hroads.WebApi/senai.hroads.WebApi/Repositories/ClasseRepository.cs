using senai.hroads.WebApi.Contexts;
using senai.hroads.WebApi.Domains;
using senai_hroads_webApi.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace senai_hroads_webApi.Repositories
{
    public class ClasseRepository : IClasseRepository
    {
        /// <summary>
        /// Objeto contexto por onde serão chamados os métodos do EF Core
        /// </summary>
        HroadsContext ctx = new HroadsContext();
        
        
        /// <summary>
        /// Atualiza uma classe existente
        /// </summary>
        /// <param name="id">ID da classe que será atualizada</param>
        /// <param name="classeAtualizada">Objeto classeAtualizada com as novas informações</param>
        public void Atualizar(int id, Classe classeAtualizada)
        {
            // Busca uma classe através do seu id
            Classe classeBuscada = ctx.Classes.Find(id);

            // Verifica se o nome da classe foi informado
            if (classeAtualizada.Nome != null)
            {
                // Atribui os novos valores aos campos existentes
                classeBuscada.Nome = classeAtualizada.Nome;
            }

            // Atualiza a classe que foi buscada
            ctx.Classes.Update(classeBuscada);

            // Salva as informações para serem gravadas no banco de dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Busca uma classe através do seu ID
        /// </summary>
        /// <param name="id">ID da classe que será buscada</param>
        /// <returns>Uma classe buscada</returns>
        public Classe BuscarPorId(int id)
        {
            // Retorna a primeira classe encontrada para o ID informado
            return ctx.Classes.FirstOrDefault(e => e.IdClasse == id);
        }

        /// <summary>
        /// Cadastra uma nova classe
        /// </summary>
        /// <param name="novaClasse">Objeto novaClasse que será cadastrado</param>
        public void Cadastrar(Classe novaClasse)
        {
            // Adiciona este novoEstudio
            ctx.Classes.Add(novaClasse);

            // Salva as informações para serem gravadas no banco de dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Deleta uma classe existente
        /// </summary>
        /// <param name="id">ID da classe que será deletada</param>
        public void Deletar(int id)
        {
            // Busca uma classe através do seu id
            Classe classeBuscada = ctx.Classes.Find(id);

            // Remove a classe que foi buscada
            ctx.Classes.Remove(classeBuscada);

            // Salva as alterações
            ctx.SaveChanges();
        }

        public List<Classe> ListarTodas()
        {
            // Retorna uma lista de classes com seus jogos
            return ctx.Classes.ToList();
        }

        
    }

}
