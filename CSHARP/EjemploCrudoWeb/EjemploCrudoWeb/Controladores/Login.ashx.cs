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
            Usuario usuario = new Usuario()
            {
                Email = context.Request["email"],
                Password = context.Request["password"]
            };

            if(usuario.Email == "javierlete@email.net" && usuario.Password == "contra")
            {
                //context.Response.Redirect("/Vistas/Principal.htm");
                context.Response.ContentType = "text/html";
                context.Response.Write(@"
<!DOCTYPE html>
<html>
<head>
    <meta charset = 'utf-8' />
    <title></title>
</head>
<body>
    <h1>" + usuario.Email + @"</h1>
</body>
</html>
");
            }
            else
            {
                context.Response.Redirect("/Vistas/Default.htm");
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