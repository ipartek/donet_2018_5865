using System;

namespace Tipos
{
    public abstract class Empleado : IFormateable
    {
        public string Nombre { get; set; }

        public Empleado(string nombre)
        {
            Nombre = nombre;
        }

        public abstract decimal SueldoMensual { get; }

        public virtual string FormatoVertical => string.Format(
            "Nombre: {0}\n", Nombre);

        public override string ToString()
        {
            return "Nombre: " + Nombre;
        }
    }
}
