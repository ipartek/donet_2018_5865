using System;

namespace HolaMundo
{
    class Calculadora
    {
        static void Main()
        {
            string sOp;
            double dOp1, dOp2, res = 0.0;
            char cOp;
            bool errorOperando = false, repetir;
            do
            {
                repetir = false;

                dOp1 = PedirDouble("Operando 1: ");

                Console.Write("Operación: ");
                sOp = Console.ReadLine();

                dOp2 = PedirDouble("Operando 2: ");

                cOp = sOp.Trim()[0];

                switch (cOp)
                {
                    case '+': res = dOp1 + dOp2; break;
                    case '-': res = dOp1 - dOp2; break;
                    case '*': res = dOp1 * dOp2; break;
                    case '/': res = dOp1 / dOp2; break;

                    default:
                        errorOperando = true;
                        break;
                }

                if (errorOperando)
                {
                    Console.WriteLine("Operación no reconocida");
                }
                else
                {
                    Console.WriteLine(res);
                }

                Console.WriteLine("¿Quieres repetir? (s/N)?");

                repetir = Console.ReadLine().ToLower() == "s";
                
            } while (repetir);

    {

            }
        }

        private static double PedirDouble(string mensaje)
        {
            string s;
            double d;
            bool esNumero = true;

            do
            {
                if(!esNumero)
                {
                    Console.WriteLine("Hombre... Mejor un número");
                }

                Console.Write(mensaje);
                s = Console.ReadLine();
                esNumero = double.TryParse(s, out d);
            } while (!esNumero);

            return d;
        }
    }
}
