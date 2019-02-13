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

        static Usuarios()
        {
            usuarios.Add(new Usuario("pepe@email.net", "contrapepe"));
            usuarios.Add(new Usuario("javierlete@email.net", "contra"));
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GvUsuarios.DataSource = usuarios;
                GvUsuarios.DataBind();
            }
        }

        protected void BtnAceptar_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                usuarios.Add(new Usuario(TxtEmail.Text, TxtPassword.Text));
                GvUsuarios.DataSource = usuarios;
                GvUsuarios.DataBind();

                Dni dni = new Dni(TxtDni.Text);
            }
        }

        protected void ValidadorDni_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = Dni.EsValido(args.Value);
        }

        protected void Editar(object sender, GridViewEditEventArgs e)
        {

        }

        protected void Borrar(object sender, GridViewDeleteEventArgs e)
        {

        }
    }
}