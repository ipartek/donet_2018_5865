using System;
using System.Collections.Generic;

using static System.Console;

using Tipos;

namespace EjemploUsuario
{
    class Program
    {
        private enum OpcionesMenu
        {
            Listado = 1, Alta = 2, Salir = 10
        }

        private static List<Usuario> usuarios = new List<Usuario>();

        static void Main(string[] args)
        {
            GenerarDatosDePrueba();

            int opcion;

            do
            {
                MostrarMenu();
                opcion = PedirOpcion(); //1, 2, 0);
                ProcesarOpcion(opcion);
            } while (!ElUsuarioQuiereSalir(opcion));

            //Listado();
        }

        private static bool ElUsuarioQuiereSalir(int opcion) => 
            (OpcionesMenu)opcion == OpcionesMenu.Salir;

        private static void ProcesarOpcion(int opcion)
        {
            OpcionesMenu opcionMenu = (OpcionesMenu)opcion;

            switch (opcionMenu)
            {
                case OpcionesMenu.Listado:
                    Listado();
                    break;
                case OpcionesMenu.Alta:
                    Alta();
                    break;
                default:
                    break;
            }
        }

        private static void Alta()
        {
            Usuario usuario = new Usuario();

            PedirCampo("Email: ", s => usuario.Email = s);
            PedirCampo("Password: ", s => usuario.Password = s);

            usuarios.Add(usuario);
        }

        private delegate void DelegadoPedirCampo(string s);

        private static void PedirCampo(string mensaje, DelegadoPedirCampo dpc)
        {
            bool repetir;

            do
            {
                try
                {
                    repetir = false;

                    Write(mensaje);
                    dpc(ReadLine());
                }
                catch(FormatException)
                {
                    WriteLine("El formato introducido no es válido");
                    repetir = true;
                }
                catch(Exception e)
                {
                    WriteLine(e.Message);
                    repetir = true;
                }
            } while (repetir);
        }

        private static int PedirOpcion() //params int[] opciones)
        {
            int opcion;

            do
            {
                opcion = LeerEntero("Elige una opción del menú: ");
            }
            while (!ExisteOpcion(opcion)); //, opciones));

            return opcion;
        }

        private static bool ExisteOpcion(int opcion)//, int[] opciones)
        {
            //bool existe = Array.Exists(opciones, o => o == opcion);

            bool existe = Enum.IsDefined(typeof(OpcionesMenu), opcion);

            if (!existe)
            {
                WriteLine("No existe esa opción");
            }

            return existe;
        }

        private static int LeerEntero(string mensaje)
        {
            int entero;
            string resultado;

            bool correcto = true;

            do
            {
                Write(mensaje);
                resultado = ReadLine();
                correcto = int.TryParse(resultado, out entero);

                if (!correcto)
                {
                    WriteLine("Eso no es un número");
                }
            }
            while (!correcto);

            return entero;
        }

        private static void MostrarMenu()
        {
            foreach (int valor in Enum.GetValues(typeof(OpcionesMenu)))
            {
                WriteLine($"{valor}. {(OpcionesMenu)valor}");
            }
        }

        private static void Listado()
        {
            foreach (Usuario usuario in usuarios)
            {
                WriteLine(usuario);
            }
        }

        private static void GenerarDatosDePrueba()
        {
            for (int i = 1; i <= 5; i++)
                usuarios.Add(new Usuario($"email{i}@b.c", $"password{i}"));
        }
    }
}
