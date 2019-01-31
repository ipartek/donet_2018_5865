using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tipos
{
    public class EmpleadoPorHoras : Empleado
    {
        public EmpleadoPorHoras(string Nombre, decimal sueldoPorHora, int numeroDeHoras): base(Nombre)
        {
            SueldoPorHora = sueldoPorHora;
            NumeroDeHoras = numeroDeHoras;
        }

        public decimal SueldoPorHora { get; set; }
        public int NumeroDeHoras { get; set; }

        public override decimal SueldoMensual => SueldoPorHora * NumeroDeHoras;

        /*
        public override decimal SueldoMensual
        {
            get { return SueldoPorHora * NumeroDeHoras; }
        }
        */

        public override string ToString() => 
            string.Format("{0}, SueldoPorHora: {1:c}, NumeroDeHoras: {2}", 
                base.ToString(), SueldoPorHora, NumeroDeHoras);

        public override string FormatoVertical => string.Format(
            "{0}\nSueldoPorHora: {1:c}\nNumeroDeHoras: {2}\n", 
            base.FormatoVertical, SueldoPorHora, NumeroDeHoras);
    }
}
