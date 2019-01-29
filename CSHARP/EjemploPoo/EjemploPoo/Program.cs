using System;
using Tipos;

//csc /r:Tipos.dll Program.cs /out:EjemploPoo.exe

namespace EjemploPoo
{
    class Program
    {
        static void Main()
        {
            Dni dni = new Dni("12345678Z");

            Console.WriteLine(dni.Numero);
            Console.WriteLine(dni.Letra);

            if (Dni.EsValido("12345678A"))
            {
                dni = new Dni("12345678A");
            }
            else
            {
                Console.WriteLine("Es incorrecto");
            }
        }
        static void MainUsuario()
        {
            Usuario.PasswordPorDefecto = "PASSWORD POR DEFECTO";

            Usuario usuario;

            usuario = new Usuario(password: "lakjdfl", email: "laskfal");

            usuario.SetEmail("javierlete@email.net");

            Console.WriteLine(usuario.GetEmail());

            usuario.Email = "yepa";

            Console.WriteLine(usuario.Email);

            usuario.Password = "alsdkjfalsdk";

            Console.WriteLine(usuario.Password);

            //contador.SetValor(contador.GetValor()+1);
            //contador.Valor++;

            Usuario u2 = new Usuario();

            Usuario u = new Usuario
            {
                Email = "email",
                Password = "pass"
            };

            Console.WriteLine(u.Email);
            Console.WriteLine(u.Password);

            u = new Usuario("laksdjfl", "lkajsdlk");

            Console.WriteLine(u.GetTexto("compacto"));
            Console.WriteLine(u.GetTexto(Usuario.Formatos.Bonito));

            Console.WriteLine(usuario < u);
            //Console.WriteLine(usuario.Email.CompareTo(u) < 0);
            //Console.WriteLine(usuario.menorQue(u));

            Console.WriteLine(Usuario.PasswordPorDefecto);
        }

        private struct Estructura
        {
            public int dato;
        }

        private class Clase
        {
            public int dato;
        }

        static void MainClase()
        {
            Clase clase, clase2;

            clase = new Clase();

            clase.dato = 1;

            Console.WriteLine(clase.dato);

            clase2 = clase;

            clase.dato = 7;

            Console.WriteLine(clase.dato);
            Console.WriteLine(clase2.dato);
        }

        static void MainEstructura(string[] args)
        {
            Estructura estructura, estructura2;

            estructura.dato = 1;

            Console.WriteLine(estructura.dato);

            estructura2 = estructura;

            estructura.dato = 7;

            Console.WriteLine(estructura.dato);
            Console.WriteLine(estructura2.dato);

        }
    }
}
