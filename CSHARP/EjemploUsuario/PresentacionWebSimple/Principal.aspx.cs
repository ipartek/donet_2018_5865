using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Tipos;

namespace PresentacionWebSimple
{
    public partial class Principal : System.Web.UI.Page
    {
        private Usuario usuario;

        protected void Page_Load(object sender, EventArgs e)
        {
            usuario = (Usuario)Session["usuario"];
            LblUsuario.Text = usuario.Email;

            LblChat.Text = ((StringBuilder)Application["chat"]).ToString();
        }

        protected void BtnDesconectar_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("Login.aspx");
        }

        protected void BtnChat_Click(object sender, EventArgs e)
        {
            StringBuilder chat = (StringBuilder)Application["chat"];

            chat.Append(usuario.Email).Append(": ").Append(TxtChat.Text).Append("<br />");

            LblChat.Text = ((StringBuilder)Application["chat"]).ToString();
        }
    }
}