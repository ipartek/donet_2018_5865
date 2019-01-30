using System;

//Al hacer el using se activan los métodos de extensión de ese espacio de nombres
using Utilidades;

namespace Tipos
{
    public class Dni
    {
        private int numero;

        private const string LETRAS = "TRWAGMYFPDXBNJZSQVHLCKE";

        public Dni(string dni)
        {
            if (!EsValido(dni))
            {
                throw new Exception("El DNI no es válido");
            }

            numero = int.Parse(ExtraerNumero(dni));
        }

        public int Numero
        {
            get { return numero; }
        }

        public char Letra
        {
            get { return CalcularLetra(Numero); }
        }

        public static bool EsValido(string dni)
        {
            string sNumero = ExtraerNumero(dni);

            char letra = dni[8];

            sNumero = sNumero.Replace('X', '0').Replace('Y', '1').Replace('Z', '2');

            return letra == CalcularLetra(int.Parse(sNumero));
        }

        private static string ExtraerNumero(string dni)
        {
            //Usando método de extensión
            return dni.CutRight(1); //dni.Substring(0, dni.Length - 1);
        }

        private static char CalcularLetra(int numero)
        {
            return LETRAS[numero % 23];
        }
    }
}
