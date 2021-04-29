using Microsoft.EntityFrameworkCore;
using senai.hroads.WebApi.Contexts;
using senai.hroads.WebApi.Domains;
using senai.hroads.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.WebApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {

        /// <summary>
        /// Objeto contexto por onde serão chamados os métodos do EF Core
        /// </summary>
        HroadsContext ctx = new HroadsContext();

        public void Atualizar(int id, Usuario usuarioAtualizado)
        {
            Usuario usuarioBuscado = ctx.Usuarios.Find(id);


            if (usuarioAtualizado.Email != null)
            {

                usuarioBuscado.Email = usuarioAtualizado.Email;
            }


            ctx.Usuarios.Update(usuarioBuscado);


            ctx.SaveChanges();
        }

        public Usuario Logar(string email, string senha)
        {
            Usuario login = ctx.Usuarios.Include(h => h.TipoUsuario).FirstOrDefault(e => e.Email == email && e.Senha== senha);

            return login;
        }

        public Usuario BuscarPorId(int id)
        {
            return ctx.Usuarios.Include(h => h.TipoUsuario).FirstOrDefault(e => e.IdUsuario == id);
        }

        public void Cadastrar(Usuario cadastrarUsario)
        {
            ctx.Usuarios.Add(cadastrarUsario);


            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Usuario usuarioBuscado = ctx.Usuarios.Find(id);


            ctx.Usuarios.Remove(usuarioBuscado);


            ctx.SaveChanges();
        }

        public List<Usuario> Listar()
        {
            return ctx.Usuarios.Include(p => p.TipoUsuario).ToList();
        }
    }
}
