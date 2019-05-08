using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteoUnitario
{
    public class Alumno
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = "DESCONOCIDO";
        public string Apellidos { get; set; }

        public string NombreCompleto
        {
            get
            {
                return Nombre + " " +  Apellidos;
            }
        }
    }
}
