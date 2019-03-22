using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstFromDB
{
    class Program
    {
        static void Main(string[] args)
        {
            IpartekModel ctx = new IpartekModel();

            Usuario usuario = new Usuario();
            usuario.Rol = new Rol();
            usuario.Rol.Nombre = "PRUEBA5";
            usuario.Rol.Descripcion = "Descripción de prueba5";

            usuario.Email = "yepa5@email.net";
            usuario.Password = "contra";

            ctx.Usuarios.Add(usuario);

            EntradaBlog eb = new EntradaBlog()
            {
                Fecha = DateTime.Now,
                Titulo = "DBFirst5",
                Texto = "Un nuevo día en Entity Framework5",
            };

            usuario.EntradasBlog.Add(eb);

            Console.WriteLine(usuario);

            ctx.SaveChanges();
        }
    }
}
