using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UF2215.Models;

namespace UF2215.Controllers
{
    public class CursosController : ApiController
    {
        private UF2215Entities ctx = new UF2215Entities();

        public IQueryable GetCursos()
        {
            return ctx.Cursos.Select(c => new { c.Nombre, c.Identificador, c.NumeroHoras });
        }
    }
}
