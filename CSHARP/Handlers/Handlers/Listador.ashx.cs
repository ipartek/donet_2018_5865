using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Newtonsoft.Json;

namespace Handlers
{
    public class Listador : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json";

            Dictionary<int, string> dic = new Dictionary<int, string>();

            dic.Add(1, "Uno");
            dic.Add(2, "Dos");
            dic.Add(3, "Tres");

            string texto = JsonConvert.SerializeObject(dic);

            context.Response.Write(texto);
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