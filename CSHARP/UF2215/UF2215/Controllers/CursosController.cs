using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UF2215.Models;

namespace UF2215.Controllers
{
    [RoutePrefix("api/cursos")]
    public class CursosController : ApiController
    {
        private UF2215Entities ctx = new UF2215Entities();

        [Route("")]
        public IQueryable GetCursos()
        {
            return ctx.Cursos.Select(c => new { c.Nombre, c.Identificador, c.NumeroHoras });
        }

        [Route("profesores")]
        public IQueryable GetCursosYProfesores()
        {
            return ctx.Cursos.Select(c => 
                new
                {
                    c.Nombre,
                    c.Identificador,
                    c.NumeroHoras,
                    Profesor = new { c.Profesor.Nombre, c.Profesor.Apellidos }
                });
        }

        [Route("profesores/alumnos")]
        public IQueryable GetCursosYProfesoresYAlumnos()
        {
            return ctx.Cursos.Select(c =>
                new
                {
                    c.Nombre,
                    c.Identificador,
                    c.NumeroHoras,
                    Profesor = new { c.Profesor.Nombre, c.Profesor.Apellidos },
                    Alumnos = ctx.Imparticiones.Where(i => i.IdCurso == c.Id)
                        .Select(i => new { i.Alumno.Nombre, i.Alumno.Apellidos })
                });
        }
    }
}
