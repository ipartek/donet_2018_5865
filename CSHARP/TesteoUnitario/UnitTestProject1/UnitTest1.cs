using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TesteoUnitario;

namespace UnitTestProject1
{
    [TestClass]
    public class AlumnoTest
    {
        [TestMethod]
        public void ComprobarNombreCompleto()
        {
            Alumno a = new Alumno();

            a.Nombre = "Javier";
            a.Apellidos = "Lete";

            Assert.AreEqual("Javier Lete", a.NombreCompleto);
        }

        [TestMethod]
        public void ComprobarValoresPorDefecto()
        {
            Alumno a = new Alumno();

            Assert.IsInstanceOfType(a.NombreCompleto, typeof(string));

            Assert.AreEqual("DESCONOCIDO", a.Nombre);
        }
    }
}
