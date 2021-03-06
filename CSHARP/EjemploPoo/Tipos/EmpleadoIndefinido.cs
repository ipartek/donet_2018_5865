﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tipos
{
    public class EmpleadoIndefinido : Empleado
    {
        public decimal SueldoAnual { get; set; }
        public int NumeroDePagas { get; set; }

        public EmpleadoIndefinido(string nombre, decimal sueldoAnual, int numeroDePagas) : base(nombre)
        {
            SueldoAnual = sueldoAnual;
            NumeroDePagas = numeroDePagas;
        }

        public override decimal SueldoMensual => SueldoAnual / NumeroDePagas;

        public override string ToString()
        {
            return string.Format("{0}, SueldoAnual: {1:c}, NumeroDePagas: {2}", 
                base.ToString(), SueldoAnual, NumeroDePagas);
        }

        public override string FormatoVertical => string.Format(
            "{0}\nSueldoAnual: {1:c}\nNumeroDePagas: {2}\n",
                base.ToString(), SueldoAnual, NumeroDePagas);
    }
}
