using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tipos;

namespace AccesoDatos
{
    public class UsuarioEntityDao : IUsuarioDao
    {
        private IpartekDbContext ctx = IpartekDbContext.GetInstance();

        public int Borrar(Usuario usuario)
        {
            return Borrar(usuario.Id);
        }

        public int Borrar(int id)
        {
            ctx.Usuarios.Remove(BuscarPorId(id));

            return 1;
        }

        public Usuario BuscarPorEmail(string email)
        {
            //return (from u in ctx.Usuarios
            //       where u.Email == email
            //       select u).FirstOrDefault();

            return ctx.Usuarios.Where((u) => u.Email == email).FirstOrDefault();
        }

        public Usuario BuscarPorId(int id)
        {
            return ctx.Usuarios.Find(id);
        }

        public List<Usuario> BuscarTodos()
        {
            return ctx.Usuarios.ToList(); 
        }

        public List<Usuario> BuscarTodosConRol()
        {
            return ctx.Usuarios.Include("Rol").ToList();
        }

        public int Insertar(Usuario usuario)
        {
            ctx.Usuarios.Add(usuario);
            ctx.SaveChanges();

            return usuario.Id;
        }

        public int Modificar(Usuario usuario)
        {
            Usuario usuarioConectado = BuscarPorId(usuario.Id);

            ctx.Entry(usuarioConectado).CurrentValues.SetValues(usuario);
            ctx.Entry(usuarioConectado).State = System.Data.Entity.EntityState.Modified;

            ctx.SaveChanges();

            return 1;
        }
    }
}
