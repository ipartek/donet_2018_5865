using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilidades
{
    public static class Extensiones
    {
        //Método de extensión CutRight para string
        public static string CutRight(this string s, int cuantosCaracteresAQuitar)
        {
            return s.Substring(0, s.Length - cuantosCaracteresAQuitar);
        }
    }
}
