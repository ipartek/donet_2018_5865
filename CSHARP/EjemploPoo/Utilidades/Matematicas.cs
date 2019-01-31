using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilidades
{
    public static class Matematicas
    {
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
