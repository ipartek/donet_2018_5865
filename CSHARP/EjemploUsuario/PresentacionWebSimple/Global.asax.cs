using System;
using System.Collections.Generic;
using System.Text;
using Tipos;

namespace PresentacionWebSimple
{
    public class Global : System.Web.HttpApplication
    {
        // Método que se ejecuta sólo cuando se arranca la aplicación
        protected void Application_Start(object sender, EventArgs e)
        {
            Dictionary<string, Usuario> usuarios = new Dictionary<string, Usuario>();

            usuarios.Add("javierlete@email.net", new Usuario("javierlete@email.net", "contra"));
            usuarios.Add("pepe@email.net", new Usuario("pepe@email.net", "yepa"));

            Application["usuarios"] = usuarios;

            Application["chat"] = new StringBuilder("Bienvenido a este chat<br />");
        }

        //Cuando un navegador inicia comunicaciones con nosotros
        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}