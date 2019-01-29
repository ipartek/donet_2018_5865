using System;
using System.Collections.Generic;
//using con = System.Console;

namespace HolaMundo
{
    /// <summary>
    /// Clase de ejemplo de C#
    /// </summary>
    public class Pepito
    {
        /// <summary>
        /// Método de entrada de la aplicación
        /// </summary>
        /// <param name="args">Argumentos de entrada</param>
        public static void Main(string[] args)
        {
            Console.Write("Dime tu nombre: ");
            string nombre = Console.ReadLine();
            //con.WriteLine("Hola {0}", nombre);
            Console.WriteLine("Hola {0}", nombre);

            //TIPOS VALOR
            //son structs 0 a 2^tamañoenbits 
            //(-2^(tamañoenbits-1)) a (2^(tamañoenbits-1))-1

            //ENTEROS
            //byte=System.Byte (8) sbyte=System.SByte
            //short=System.Int16 (16) ushort=System.UInt16
            //int=System.Int32 (32) uint=System.UInt32
            //long=System.Int64 (64) ulong=System.UInt64

            Console.WriteLine(long.MaxValue);
            Console.WriteLine(byte.MaxValue);

            //checked
            //{
                byte b = 255;
                Console.WriteLine(++b);
            //}

            //COMA FLOTANTE
            //float=System.Single (32), double=System.Double (64)

            //(Para dinero)
            //decimal=System.Decimal (128)

            //UN caracter
            //char (16) System.Char

            char c = 'a';
            int cod = c;

            Console.WriteLine("{0} = {1}", c, cod);

            //Booleano: true, false
            //bool (16) System.Boolean

            //System.DateTime
            DateTime hoy = DateTime.Now;
            DateTime fecha = new DateTime(2019, 1, 28);

            Console.WriteLine(fecha.AddDays(5.5));

            Console.WriteLine(hoy);
            Console.WriteLine(fecha);

            //TIPOS REFERENCIA
            //string = System.String

            string texto = "Esto es una prueba\nA ver qué tal se ve esta cita: \"Mola mogollón\"";
            string path = @"C:\nuevos\trabajos";

            string nombre1 = "Javier";
            string nombre2 = "Javier";

            Console.WriteLine(texto);
            Console.WriteLine(path);

            Console.WriteLine(nombre1 == nombre2);

            //ARRAYS/MATRICES/ARREGLOS

            int[] arr = new int[2];
            int[] arr2 = arr;

            arr[0] = 5;
            arr[1] = 6;
            //arr[2] = 7;
            //arr[1] = "lakjsdlkfj";

            string[] textos = { "Uno", "Dos", "Tres" };

            Console.WriteLine(textos[0]);
            Console.WriteLine(textos.Length);

            //char[][] tablero = new char[8][];
            //tablero[0] = new char[8];
            //tablero[1] = new char[12];

            char[,] tablero = new char[8, 8];
            tablero[0, 0] = 'T';
            tablero[0, 1] = 'C';
            //...
            tablero[1, 0] = 'P';

            //tablero[5, 20] = 'Y';
            //...

            Console.WriteLine(tablero[0, 1]);

            //COLECCIONES
            List<int> lista = new List<int>();

            lista.Add(5);
            lista.Add(6);
            lista.Add(7);

            Console.WriteLine(lista.Capacity);
            Console.WriteLine(lista.Count);
            Console.WriteLine(lista.IndexOf(7));

            Dictionary<string, int> dic = new Dictionary<string, int>();

            dic.Add("uno", 1);
            dic.Add("dos", 2);

            dic["tres"] = 3;
            dic["dos"] = 22;

            Console.WriteLine(dic["tres"]);
            Console.WriteLine(dic["dos"]);
            Console.WriteLine(dic.Count);

            Dictionary<object, object> dicGen = new Dictionary<object, object>();

            dicGen[5] = "cinco";
            dicGen["cinco"] = 5;

            //SENTENCIAS DE CONTROL

            int x = 8;

            if(x==7)
            {
                Console.WriteLine("Vale 7");
            }

            switch (x)
            {
                case 5:
                    Console.WriteLine("Vale 5");
                    break;
                case 6:
                case 7:
                    Console.WriteLine("Vale 6 o 7");
                    break;

                case 8:
                    Console.WriteLine("Vale 8");
                    goto case 9;

                case 9:
                    Console.WriteLine("Vale 8 o 9");
                    break;
                default:
                    Console.WriteLine("Ningún valor de los anteriores");
                    break;
            }

            for (int n = 1; n <= 10; n++)
            {
                Console.WriteLine("Repetición: {0}", n);
            }

            foreach (string t in textos)
            {
                Console.WriteLine(t);
            }

            foreach (int elemento in lista)
            {
                Console.WriteLine(elemento);
            }

            foreach (char casilla in tablero)
            {
                Console.WriteLine(casilla);
            }

            for(int fila = 0; fila < tablero.GetUpperBound(0); fila++)
            {
                for (int col = 0; col < tablero.GetUpperBound(1); col++)
                {
                    if(tablero[fila, col] == '\0')
                    {
                        tablero[fila, col] = '_';
                    }
                    Console.Write(tablero[fila, col]);
                }

                Console.WriteLine();
            }

            //NULLABLES

            int? i = null;

            if(i == null)
            {
                Console.WriteLine("Vale nulo");
            }

            i = 3;
            
            Console.WriteLine(i);

            Nullable<int> nullable = null;

            if(!nullable.HasValue)
            {
                Console.WriteLine("No tiene valor");
            }

            nullable = 3;

            Console.WriteLine(nullable.Value);
        }

        //Comentario de línea

        /*
         * Comentario
         * multilínea
         */
    }
}
