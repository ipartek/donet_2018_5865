using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MF0966_3.Models;

namespace MF0966_3.Controllers
{
    public class CursosController : Controller
    {
        private UF2215Entities db = new UF2215Entities();

        // GET: Cursos
        public ActionResult Index()
        {
            var cursos = db.Cursos.Include(c => c.Cliente).Include(c => c.Profesor);
            return View(cursos.ToList());
        }

        // GET: Cursos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Curso curso = db.Cursos.Find(id);
            if (curso == null)
            {
                return HttpNotFound();
            }
            return View(curso);
        }

        // GET: Cursos/Create
        public ActionResult Create()
        {
            ViewBag.IdCliente = new SelectList(db.Clientes, "Id", "Nombre");
            ViewBag.IdProfesor = new SelectList(db.Profesores, "Id", "NumeroSeguridadSocial");
            return View();
        }

        // POST: Cursos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IdProfesor,IdCliente,Nombre,Identificador,FechaInicio,FechaFin,NumeroHoras,Temario,Activo,Precio")] Curso curso)
        {
            if (ModelState.IsValid)
            {
                db.Cursos.Add(curso);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdCliente = new SelectList(db.Clientes, "Id", "Nombre", curso.IdCliente);
            ViewBag.IdProfesor = new SelectList(db.Profesores, "Id", "NumeroSeguridadSocial", curso.IdProfesor);
            return View(curso);
        }

        // GET: Cursos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Curso curso = db.Cursos.Find(id);
            if (curso == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCliente = new SelectList(db.Clientes, "Id", "Nombre", curso.IdCliente);
            ViewBag.IdProfesor = new SelectList(db.Profesores, "Id", "NumeroSeguridadSocial", curso.IdProfesor);
            return View(curso);
        }

        // POST: Cursos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IdProfesor,IdCliente,Nombre,Identificador,FechaInicio,FechaFin,NumeroHoras,Temario,Activo,Precio")] Curso curso)
        {
            if (ModelState.IsValid)
            {
                db.Entry(curso).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdCliente = new SelectList(db.Clientes, "Id", "Nombre", curso.IdCliente);
            ViewBag.IdProfesor = new SelectList(db.Profesores, "Id", "NumeroSeguridadSocial", curso.IdProfesor);
            return View(curso);
        }

        // GET: Cursos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Curso curso = db.Cursos.Find(id);
            if (curso == null)
            {
                return HttpNotFound();
            }
            return View(curso);
        }

        // POST: Cursos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Curso curso = db.Cursos.Find(id);
            db.Cursos.Remove(curso);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
