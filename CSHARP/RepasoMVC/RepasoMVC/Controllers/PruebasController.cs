using Newtonsoft.Json;
using RepasoMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RepasoMVC.Controllers
{
    public class PruebasController : Controller
    {
        // GET: Pruebas
        public ActionResult Index()
        {
            ViewBag.Prueba = new Prueba() { Dato1 = "Valor1", Dato2 = 2 };
            return View();
        }

        public string VerDatosEnJson()
        {
            var prueba = new { dato1 = "Valor1", dato2 = 2 };
            return JsonConvert.SerializeObject(prueba);
        }

        public class Prueba
        {
            public string Dato1 { get; set; }
            public int Dato2 { get; set; }
        }
    }
}