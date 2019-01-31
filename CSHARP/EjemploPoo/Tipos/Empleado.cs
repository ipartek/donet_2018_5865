using System;

namespace Tipos
{
    public abstract class Empleado
    {
        public string Nombre { get; set; }

        public Empleado(string nombre)
        {
            Nombre = nombre;
        }

        public abstract decimal SueldoMensual { get; }

        public override string ToString()
        {
            return "Nombre: " + Nombre;
        }
    }
}
