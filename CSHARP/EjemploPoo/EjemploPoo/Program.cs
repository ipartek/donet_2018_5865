using System;
using System.Collections.Generic;
using System.Text;
using Tipos;
using Utilidades;

using static System.Console;
using static System.Math;

//csc /r:Tipos.dll Program.cs /out:EjemploPoo.exe

//Program.Main()

namespace EjemploPoo
{
    class Program
    {
        static void Main()
        {
            Grupo<EmpleadoIndefinido> empleados = new Grupo<EmpleadoIndefinido>("Indefinidos");

            empleados.Add(new EmpleadoIndefinido("Javier", 20000m, 14));

            EmpleadoIndefinido ei = empleados.Find(e => e.NumeroDePagas == 14);

            Console.WriteLine(ei);
        }

        static void MainUsingStatic()
        {
            Console.WriteLine(Math.Sin(3));
            WriteLine(Sin(3));
        }

        static void MainDictionary()
        {
            Dictionary<string, int> dic = new Dictionary<string, int>
            {
                ["uno"] = 1,
                ["dos"] = 2
            };

            Console.WriteLine(dic["uno"]);

            foreach (KeyValuePair<string, int> par in dic)
            {
                Console.WriteLine($"{par.Key} = {par.Value}");
            }

            foreach(string clave in dic.Keys)
            {
                Console.WriteLine(clave);
            }

            foreach (int valor in dic.Values)
            {
                Console.WriteLine(valor);
            }

            Usuario u1 = new Usuario();
            Usuario u2 = new Usuario("javierlete@email.net", "mi contra");

            Dictionary<string, Usuario> usuarios = new Dictionary<string, Usuario>()
            {
                [u1.Email] = u1,
                [u2.Email] = u2
            };

            Console.WriteLine(usuarios["javierlete@email.net"]);
        }

        static void MainStringBuilder()
        {
            string logTxapu = "";
            StringBuilder log = new StringBuilder();

            logTxapu += "Principio\n";
            log.AppendLine("Principio");

            for (int i = 1; i <= 10; i++)
            {
                logTxapu += "Repetición: " + i + "\n";
                //logTxapu = new StringBuilder(logTxapu).Append("Repetición: ").Append(i.ToString()).Append("\n").ToString();
                log.Append("Repeticion: ").AppendLine(i.ToString());
            }

            logTxapu += "Fin\n";
            log.AppendLine("Fin");

            string logString = log.ToString();

            Console.WriteLine(logTxapu);
            Console.WriteLine(logString);
        }

        static void MainGenericos()
        {
            Grupo<Usuario> g = new Grupo<Usuario>("Pruebas");

            g.Add(new Usuario("a@b", "a"));
            g.Add(new Usuario("b@c", "b"));

            Usuario usuario = g.Find(u => u.Email == "b@c");

            Console.WriteLine(usuario);

            g.Componentes[1].Email = "YEPAAAAAAAA";

            Console.WriteLine(g[0].Email);

            Predicate<Usuario> busqueda = u => u.Email == "a@b";

            Usuario usuarioBuscado = g[busqueda];

            if (usuarioBuscado != null)
            {
                Console.WriteLine("El password es {0}", usuarioBuscado.Password);
                g[busqueda] = new Usuario("a@b", "NUEVA PASSWORD");
                Console.WriteLine(usuarioBuscado);
            }
            else
            {
                Console.WriteLine("No se ha encontrado el email a@b");
            }

            foreach (Usuario u in g.Componentes)
            {
                Console.WriteLine(u);
            }

            g.Remove(new Usuario("b@c", "b"));

            Console.WriteLine(
                g.Find(u => u.Email == "b@c") == null ? "No encontrado" : "Encontrado");

            Console.WriteLine(usuario == new Usuario("b@c", "b"));
        }

        private delegate double Calcular(double d1, double d2);

        private static double Sumar(double d1, double d2) => d1 + d2;

        private static double Restar(double d1, double d2) => d1 - d2;

        static void MainDelegados()
        {
            Calcular calcular;

            calcular = Sumar;

            Console.WriteLine(calcular(1, 2));

            calcular = Restar;

            Console.WriteLine(calcular(1, 2));

            calcular = (d1, d2) => d1 * d2;

            Console.WriteLine(calcular(1, 2));

            List<int> lista = new List<int> { 1, 3, 4, 6 };

            Console.WriteLine(lista.Find(BuscarPar));

            Console.WriteLine(lista.Find(i => i % 2 == 0));
        }

        public static bool BuscarPar(int i)
        {
            return i % 2 == 0;
        }

        static void MainExcepciones()
        {
            int a = 5, b = 1, res;

            Console.WriteLine("Vamos a dividir {0}/{1}", a, b);

            try
            {
                res = a / b;
                Console.WriteLine("El resultado es {0}", res);

                int i = int.MaxValue - 1;

                checked
                {
                    i++;
                }

                string s = null;
                //Console.WriteLine(s.ToUpper());

                new Dni("1234567");
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Ha habido un error en la división");
            }
            catch (OverflowException oe)
            {
                Console.WriteLine(oe.Message);
                throw new Exception("Error de rebose de variable", oe);
            }
            catch(TiposException te)
            {
                Console.WriteLine(te.Message);
            }
            finally
            {
                Console.WriteLine("Me ejecuto por c*j*nes");
            }

            /*
            catch(Exception e)
            {
                Console.WriteLine(e.GetType());
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
                Console.WriteLine(e.Source);

                return;
            }
            */

            Console.WriteLine("Fin del programa");
        }

        static void MainInterfaces()
        {
            //Para permitir que la consola visualice el caracter del €
            Console.OutputEncoding = Encoding.Default;

            List<IFormateable> formateables = new List<IFormateable>
            {
                new EmpleadoIndefinido("Javier", 50000.0M, 14),
                new EmpleadoPorHoras("Pringao", 10.0M, 300),
                new Usuario(),
                new UsuarioExtendido()
            };

            foreach (IFormateable formateable in formateables)
            {
                Console.WriteLine(formateable.FormatoVertical);
            }

        }

        static void MainClasesAbstractas()
        {
            Console.OutputEncoding = Encoding.Default;

            List<Empleado> empleados = new List<Empleado>
            {
                new EmpleadoIndefinido("Javier", 50000.0M, 14),
                new EmpleadoIndefinido("Pepe", 10000.0M, 12),
                new EmpleadoPorHoras("Pringao", 10.0M, 300)
            };

            foreach (Empleado empleado in empleados)
            {
                Console.WriteLine(empleado);
                //Console.WriteLine("{0:c}", empleado.SueldoMensual);
                Console.WriteLine("{0:0.00} €", empleado.SueldoMensual);
            }
        }

        private static void IntercambiarValores(ref int x, ref int y)
        {
            int z = x;

            Console.WriteLine("x = {0}, y = {1}", x, y);

            x = y;
            y = z;

            Console.WriteLine("x = {0}, y = {1}", x, y);
        }

        static void MainParametros()
        {
            int a = 5, b = 3;

            Console.WriteLine("a = {0}, b = {1}", a, b);

            IntercambiarValores(ref a, ref b);

            Console.WriteLine("a = {0}, b = {1}", a, b);

            double res1, res2;

            Matematicas.EcuacionCuadratica(4.0, -2.0, -90.0, out res1, out res2);

            Console.WriteLine("{0},{1}", res1, res2);
        }

        static void MainRecursividad()
        {
            Console.WriteLine(Matematicas.Factorial(5));
        }

        static void MainClasesAnonimas()
        {
            var punto = new { Nombre = "Bilbao", X = (byte)5, Y = (short)10 };

            Console.WriteLine(punto.Nombre.Length);

            //punto = new Dni("12345678Z");

            var dni = new Dni("12345678Z");
        }

        static void MainObject()
        {
            Dni dni = new Dni("12345678Z");

            Console.WriteLine(dni.Numero);
            Console.WriteLine(dni.Letra);

            Console.WriteLine(dni.ToString());

            Dni dni2 = dni;

            Console.WriteLine("El DNI ES: " + dni);
            Console.WriteLine(dni.GetHashCode());
            Console.WriteLine(new Dni("12345678Z").GetHashCode());
            Console.WriteLine(dni2.GetHashCode());

            dni.Numero = 87654321;

            Console.WriteLine(dni);
            Console.WriteLine(dni.GetHashCode());

            Console.WriteLine(new Dni("12345678Z") == new Dni("12345678Z"));
            Console.WriteLine(new Dni("12345678Z").Equals(new Dni("12345678Z")));
            Console.WriteLine(new Dni("12345678Z") != new Dni("12345678Z"));

            UsuarioExtendido ue = new UsuarioExtendido();

            Usuario u = ue;

            Console.WriteLine(u.GetTexto());

            UsuarioExtendido ue2 = u as UsuarioExtendido;

            Console.WriteLine(ue2.GetTexto());

            Console.WriteLine(new Usuario().GetTexto());

            Usuario usuario = new UsuarioExtendido();
        }

        static void MainUsuarioExtendido()
        {
            UsuarioExtendido ue = new UsuarioExtendido
            {
                Email = "email",
                Password = "password",
                Nombre = "nombre"
            };

            UsuarioExtendido ue2 = new UsuarioExtendido("asdf", "asdfasdf", "asdfasdf");

            Console.WriteLine(ue.GetTexto());
            Console.WriteLine(ue2.GetTexto());

            Usuario u = ue;

            //Console.WriteLine(u.Nombre);

            if (u is UsuarioExtendido)
            {
                UsuarioExtendido ue3 = (UsuarioExtendido)u; //Lanza InvalidCastException si no cuadran los tipos

                Console.WriteLine(ue3.Nombre);
            }

            UsuarioExtendido ue4 = u as UsuarioExtendido; //Devuelve null si no cuadran los tipos

            UsuarioExtendido ue5 = (UsuarioExtendido)new Usuario();
        }

        /*
        static void MainGrupo()
        {
            Grupo g = new Grupo("Pruebas");

            g.Add(new Usuario("a@b", "a"));
            g.Add(new Usuario("b@c", "b"));

            Usuario usuario = g.FindByEmail("b@c");

            Console.WriteLine(usuario.GetTexto());

            g.Usuarios[1].Email = "YEPAAAAAAAA";

            Console.WriteLine(g[0].Email);

            if (g["a@b"] != null)
            {
                Console.WriteLine("El password es {0}", g["a@b"].Password);
                g["a@b"] = new Usuario("a@b", "NUEVA PASSWORD");
                Console.WriteLine(g["a@b"].GetTexto());
            }
            else
            {
                Console.WriteLine("No se ha encontrado el email a@b");
            }

            foreach (Usuario u in g.Usuarios)
            {
                Console.WriteLine(u.GetTexto());
            }

            g.Remove(new Usuario("b@c", "b"));

            Console.WriteLine(
                g.FindByEmail("b@c") == null ? "No encontrado" : "Encontrado");

            Console.WriteLine(usuario == new Usuario("b@c", "b"));
        }
        */
        static void MainDni()
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

            Usuario u = new Usuario
            {
                Email = "asdf@asdf",
                Password = "aslñdifohlkdhfas",
                Dni = new Dni("12345678A")
            };
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
