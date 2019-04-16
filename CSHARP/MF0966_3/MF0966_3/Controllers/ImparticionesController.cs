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
    public class ImparticionesController : Controller
    {
        private UF2215Entities db = new UF2215Entities();

        // GET: Imparticiones
        public ActionResult Index()
        {
            var imparticiones = db.Imparticiones.Include(i => i.Alumno).Include(i => i.Curso);
            return View(imparticiones.ToList());
        }

        // GET: Imparticiones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Imparticion imparticion = db.Imparticiones.Find(id);
            if (imparticion == null)
            {
                return HttpNotFound();
            }
            return View(imparticion);
        }

        // GET: Imparticiones/Create
        public ActionResult Create()
        {
            ViewBag.IdAlumno = new SelectList(db.Alumnos, "Id", "Nombre");
            ViewBag.IdCurso = new SelectList(db.Cursos, "Id", "Nombre");
            return View();
        }

        // POST: Imparticiones/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IdCurso,IdAlumno,FechaMatriculacion")] Imparticion imparticion)
        {
            if (ModelState.IsValid)
            {
                db.Imparticiones.Add(imparticion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdAlumno = new SelectList(db.Alumnos, "Id", "Nombre", imparticion.IdAlumno);
            ViewBag.IdCurso = new SelectList(db.Cursos, "Id", "Nombre", imparticion.IdCurso);
            return View(imparticion);
        }

        // GET: Imparticiones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Imparticion imparticion = db.Imparticiones.Find(id);
            if (imparticion == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdAlumno = new SelectList(db.Alumnos, "Id", "Nombre", imparticion.IdAlumno);
            ViewBag.IdCurso = new SelectList(db.Cursos, "Id", "Nombre", imparticion.IdCurso);
            return View(imparticion);
        }

        // POST: Imparticiones/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IdCurso,IdAlumno,FechaMatriculacion")] Imparticion imparticion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(imparticion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdAlumno = new SelectList(db.Alumnos, "Id", "Nombre", imparticion.IdAlumno);
            ViewBag.IdCurso = new SelectList(db.Cursos, "Id", "Nombre", imparticion.IdCurso);
            return View(imparticion);
        }

        // GET: Imparticiones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Imparticion imparticion = db.Imparticiones.Find(id);
            if (imparticion == null)
            {
                return HttpNotFound();
            }
            return View(imparticion);
        }

        // POST: Imparticiones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Imparticion imparticion = db.Imparticiones.Find(id);
            db.Imparticiones.Remove(imparticion);
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
