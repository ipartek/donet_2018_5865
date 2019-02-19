using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Tipos;

namespace PresentacionWebSimple
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnAceptar_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario(TxtEmail.Text, TxtPassword.Text);

            Dictionary<string, Usuario> usuarios = (Dictionary<string, Usuario>)Application["usuarios"];

            try
            {
                if (usuarios[usuario.Email].Password == usuario.Password)
                {
                    Session["usuario"] = usuario;

                    Response.Redirect("Principal.aspx");
                    //Server.Transfer("Principal.aspx");
                }
                else
                {
                    throw new Exception("Password incorrecta");
                }
            }
            catch (Exception)
            {
                LblMensaje.Text = "Credenciales incorrectas";
            }

        }
    }
}