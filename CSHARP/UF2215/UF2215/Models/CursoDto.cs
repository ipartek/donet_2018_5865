using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UF2215.Models
{
    public class CursoDto
    {
        public string Nombre { get; set; }
        public string Identificador { get; set; }
        public int NumeroHoras { get; set; }
    }

    public class CursoProfesorDto: CursoDto
    {
        public ProfesorDto Profesor { get; set; }
    }

    public class CursoProfesorAlumnosDto : CursoProfesorDto
    {
        public ICollection<AlumnoDto> Alumnos { get; set; }
    }
}