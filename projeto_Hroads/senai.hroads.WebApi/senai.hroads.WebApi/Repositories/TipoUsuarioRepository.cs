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
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        HroadsContext ctx = new HroadsContext();
        public void Atualizar(int id, TipoUsuario tipoAtualizado)
        {
            TipoUsuario tipoBuscado = ctx.TipoUsuarios.Find(id);


            if (tipoAtualizado.Permissao != null)
            {

                tipoBuscado.Permissao = tipoAtualizado.Permissao;
            }


            ctx.TipoUsuarios.Update(tipoBuscado);


            ctx.SaveChanges();
        }

        public TipoUsuario BuscarPorId(int id)
        {
            return ctx.TipoUsuarios.FirstOrDefault(e => e.IdTipoUsuario == id);
        }

        public void Cadastrar(TipoUsuario cadastrarTipoUsario)
        {
            ctx.TipoUsuarios.Add(cadastrarTipoUsario);


            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            TipoUsuario tipoBuscado = ctx.TipoUsuarios.Find(id);


            ctx.TipoUsuarios.Remove(tipoBuscado);


            ctx.SaveChanges();
        }

        public List<TipoUsuario> Listar()
        {
            return ctx.TipoUsuarios.ToList();
        }
    }
}
