using System.Linq;
using System.Web.Http;
using UF2215.Models;

namespace UF2215.Controllers
{
    /// <summary>
    /// API para recibir información de cursos, alumnos y profesores
    /// </summary>
    [RoutePrefix("api/cursos")]
    public class CursosController : ApiController
    {
        private UF2215Entities ctx = new UF2215Entities();

        /// <summary>
        /// Obtiene el nombre, identificador y número de horas de los cursos
        /// </summary>
        /// <returns></returns>
        [Route("")]
        public IQueryable<CursoDto> GetCursos()
        {
            //return ctx.Cursos.Select(c => new { c.Nombre, c.Identificador, c.NumeroHoras });
            return ctx.Cursos.Select(c => new CursoDto()
            {
                Nombre = c.Nombre,
                Identificador = c.Identificador,
                NumeroHoras = c.NumeroHoras
            });
        }

        /// <summary>
        /// Devuelve los cursos y sus profesores asociados
        /// </summary>
        /// <returns></returns>
        [Route("profesores")]
        public IQueryable<CursoProfesorDto> GetCursosYProfesores()
        {
            return ctx.Cursos.Select(c =>
                new CursoProfesorDto()
                {
                    Nombre = c.Nombre,
                    Identificador = c.Identificador,
                    NumeroHoras = c.NumeroHoras,
                    Profesor = new ProfesorDto() {
                        Nombre = c.Profesor.Nombre,
                        Apellidos = c.Profesor.Apellidos
                    }
                });

            //return ctx.Cursos.Select(c =>
            //    new
            //    {
            //        c.Nombre,
            //        c.Identificador,
            //        c.NumeroHoras,
            //        Profesor = new { c.Profesor.Nombre, c.Profesor.Apellidos }
            //    });
        }

        /// <summary>
        /// Devuelve los cursos, con sus profesores asociados y sus alumnos
        /// </summary>
        /// <returns></returns>
        [Route("profesores/alumnos")]
        public IQueryable<CursoProfesorAlumnosDto> GetCursosYProfesoresYAlumnos()
        {
            return ctx.Cursos.Select(c =>
                new CursoProfesorAlumnosDto()
                {
                    Nombre = c.Nombre,
                    Identificador = c.Identificador,
                    NumeroHoras = c.NumeroHoras,
                    Profesor = new ProfesorDto() {
                        Nombre = c.Profesor.Nombre,
                        Apellidos = c.Profesor.Apellidos
                    },
                    Alumnos = ctx.Imparticiones.Where(i => i.IdCurso == c.Id)
                                .Select(i => new AlumnoDto() {
                                    Nombre = i.Alumno.Nombre,
                                    Apellidos = i.Alumno.Apellidos })
                                .ToList()
                });

            //return ctx.Cursos.Select(c =>
            //    new
            //    {
            //        c.Nombre,
            //        c.Identificador,
            //        c.NumeroHoras,
            //        Profesor = new { c.Profesor.Nombre, c.Profesor.Apellidos },
            //        Alumnos = ctx.Imparticiones.Where(i => i.IdCurso == c.Id)
            //            .Select(i => new { i.Alumno.Nombre, i.Alumno.Apellidos })
            //    });
        }
    }
}
