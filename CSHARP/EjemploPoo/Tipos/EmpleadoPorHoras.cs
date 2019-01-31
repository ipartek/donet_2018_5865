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

        public override string ToString()
        {
            return String.Format("{0}, SueldoPorHora: {1:c}, NumeroDeHoras: {2}", 
                base.ToString(), SueldoPorHora, NumeroDeHoras);
        }
    }
}
