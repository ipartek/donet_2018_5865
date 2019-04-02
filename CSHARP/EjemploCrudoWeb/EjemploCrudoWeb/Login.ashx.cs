using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EjemploCrudoWeb
{
    /// <summary>
    /// Descripción breve de Login
    /// </summary>
    public class Login : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "texto/html";

            Usuario usuario = new Usuario()
            {
                Email = context.Request["email"],
                Password = context.Request["password"]
            };

            if(usuario.Email == "javierlete@email.net" && usuario.Password == "contra")
            {
                context.Response.Redirect("Principal.htm");
            }
            else
            {
                context.Response.Redirect("Default.htm");
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}