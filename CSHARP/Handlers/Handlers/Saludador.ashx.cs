using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Handlers
{
    public class Saludador : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string nombre = context.Request["nombre"];
            
            context.Response.ContentType = "text/plain";
            context.Response.Write("Hola " + nombre);
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