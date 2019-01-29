using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjemploPoo
{
    class Program
    {
        private struct Estructura
        {
            public int dato;
        }

        private class Clase
        {
            public int dato;
        }

        static void Main()
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
