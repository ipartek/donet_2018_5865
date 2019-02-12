using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tipos;

namespace PresentacionWebSimple
{
    public partial class Usuarios : System.Web.UI.Page
    {
        private static List<Usuario> usuarios = new List<Usuario>();

        protected void Page_Load(object sender, EventArgs e)
        {
            usuarios.Add(new Usuario("pepe@email.net", "contrapepe"));
            usuarios.Add(new Usuario("javierlete@email.net", "contra"));

            GvUsuarios.DataSource = usuarios;
            GvUsuarios.DataBind();
        }
    }
}