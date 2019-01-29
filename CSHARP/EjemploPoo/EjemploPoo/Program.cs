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

        static void Main(string[] args)
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
