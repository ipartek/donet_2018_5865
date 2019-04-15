using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RepasoMVC.Models;

namespace RepasoMVC.Controllers
{
    [RoutePrefix("Usuarios")]
    public class UsuariosController : Controller
    {
        private RepasoMVCContext db = new RepasoMVCContext();

        // GET: Usuarios
        public ActionResult Index()
        {
            if (ObtenerRol() != "USER" && ObtenerRol() != "ADMIN")
            {
                return RedirectToAction("Index", "Login");
            }

            var usuarios = db.Usuarios.Include(u => u.Rol);
            return View(usuarios.ToList());
        }

        // GET: Usuarios/Details/5
        public ActionResult Details(int? id)
        {
            if (ObtenerRol() != "USER" && ObtenerRol() != "ADMIN")
            {
                return RedirectToAction("Index", "Login");
            }

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuarios.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // GET: Usuarios/Create
        public ActionResult Create()
        {
            if (ObtenerRol() != "ADMIN")
            {
                return RedirectToAction("Index", "Login");
            }

            ViewBag.RolId = new SelectList(db.Roles, "Id", "Codigo");
            return View();
        }

        // POST: Usuarios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Email,Password,RolId")] Usuario usuario)
        {
            if (ObtenerRol() != "ADMIN")
            {
                return RedirectToAction("Index", "Login");
            }

            if (ModelState.IsValid)
            {
                db.Usuarios.Add(usuario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RolId = new SelectList(db.Roles, "Id", "Codigo", usuario.RolId);
            return View(usuario);
        }

        // GET: Usuarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (ObtenerRol() != "ADMIN")
            {
                return RedirectToAction("Index", "Login");
            }

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuarios.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            ViewBag.RolId = new SelectList(db.Roles, "Id", "Codigo", usuario.RolId);
            return View(usuario);
        }

        // POST: Usuarios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Email,Password,RolId")] Usuario usuario)
        {
            if (ObtenerRol() != "ADMIN")
            {
                return RedirectToAction("Index", "Login");
            }

            if (ModelState.IsValid)
            {
                db.Entry(usuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RolId = new SelectList(db.Roles, "Id", "Codigo", usuario.RolId);
            return View(usuario);
        }

        // GET: Usuarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (ObtenerRol() != "ADMIN")
            {
                return RedirectToAction("Index", "Login");
            }

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuarios.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (ObtenerRol() != "ADMIN")
            {
                return RedirectToAction("Index", "Login");
            }

            Usuario usuario = db.Usuarios.Find(id);
            db.Usuarios.Remove(usuario);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public string ObtenerRol()
        {
            Usuario usuario = (Usuario)Session["usuario"]; //Session["usuario"] as Usuario;

            if (usuario == null)
            {
                return null;
            }

            return usuario.Rol.Codigo;
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
