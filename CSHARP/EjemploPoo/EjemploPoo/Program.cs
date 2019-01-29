using System;

//csc /r:Tipos.dll Program.cs /out:EjemploPoo.exe

namespace EjemploPoo
{
    class Program
    {
        static void Main()
        {
            Tipos.Usuario usuario;

            usuario = new Tipos.Usuario();

            Console.WriteLine(usuario);
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
