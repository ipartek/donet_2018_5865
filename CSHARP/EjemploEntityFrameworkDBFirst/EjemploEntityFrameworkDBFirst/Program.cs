using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjemploEntityFrameworkDBFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            IpartekEntitiesContext ctx = new IpartekEntitiesContext();

            Usuario usuario = new Usuario();
            usuario.Rol = new Rol();
            usuario.Rol.Nombre = "PRUEBA2";
            usuario.Rol.Descripcion = "Descripción de prueba2";

            usuario.Email = "yepa3@email.net";
            usuario.Password = "contra";

            ctx.Usuarios.Add(usuario);

            EntradaBlog eb = new EntradaBlog()
            {
                Fecha = DateTime.Now,
                Titulo = "DBFirst22",
                Texto = "Un nuevo día en Entity Framework2",
            };

            usuario.EntradasBlog.Add(eb);

            Console.WriteLine(usuario);

            //ctx.SaveChanges();
        }
    }
}
