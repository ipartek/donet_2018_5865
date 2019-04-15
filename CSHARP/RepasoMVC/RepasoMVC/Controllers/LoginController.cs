using RepasoMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RepasoMVC.Controllers
{
    public class LoginController : Controller
    {
        private RepasoMVCContext ctx = new RepasoMVCContext();
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Index([Bind(Include = "Email,Password")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                Usuario autenticado = (from u in ctx.Usuarios
                                       where u.Email == usuario.Email && u.Password == usuario.Password
                                       select u)
                                      .SingleOrDefault();

                //Usuario autenticado =
                //    ctx.Usuarios
                //        .Where(u => u.Email == usuario.Email && u.Password == usuario.Password)
                //        .SingleOrDefault();
                //if (ctx.Usuarios.Find(usuario.Email) != null)

                if (autenticado != null)
                {
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("", "Email o contraseña incorrectos");
            }
            
            return View(usuario);
        }
    }
}