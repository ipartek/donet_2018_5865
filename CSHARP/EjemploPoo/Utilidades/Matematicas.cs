using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilidades
{
    public static class Matematicas
    {
        public static void EcuacionCuadratica(double a, double b, double c, out double x1, out double x2)
        {
            //Console.WriteLine("{0}, {1}", x1, x2);

            double raiz = Math.Sqrt((b * b) - (4 * a * c));

            x1 = (-b + raiz) / (2 * a);
            x2 = (-b - raiz) / (2 * a);
        }

        //Recursividad
        public static decimal Factorial(decimal numero)
        {
            // 5! = 5 * 4 * 3 * 2 * 1

            // 5! = 5 * 4!
            // 4! = 4 * 3!
            //...
            if (numero == 1) return 1;
            return numero * Factorial(numero - 1);
        }
    }
}
