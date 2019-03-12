using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tipos;

namespace AccesoDatos
{
    public class RolEntityDao : IDao<Rol>
    {
        private IpartekDbContext ctx = IpartekDbContext.GetInstance();

        public int Borrar(Rol rol)
        {
            return Borrar(rol.Id);
        }

        public int Borrar(int id)
        {
            ctx.Roles.Remove(BuscarPorId(id));

            return 1;
        }

        public Rol BuscarPorId(int id)
        {
            return ctx.Roles.Find(id);
        }

        public List<Rol> BuscarTodos()
        {
            return ctx.Roles.ToList();
        }

        public List<Rol> BuscarTodosConRol()
        {
            throw new NotImplementedException();
        }

        public int Insertar(Rol rol)
        {
            ctx.Roles.Add(rol);
            ctx.SaveChanges();

            return rol.Id;
        }

        public int Modificar(Rol rol)
        {
            Rol rolConectado = BuscarPorId(rol.Id);

            ctx.Entry(rolConectado).CurrentValues.SetValues(rol);
            ctx.Entry(rolConectado).State = System.Data.Entity.EntityState.Modified;

            ctx.SaveChanges();

            return 1;
        }
    }
}
