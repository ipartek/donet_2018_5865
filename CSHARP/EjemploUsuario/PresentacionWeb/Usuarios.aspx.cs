using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tipos;

namespace PresentacionWebSimple
{
    public partial class Usuarios : System.Web.UI.Page
    {
        private static Dictionary<long, Usuario> usuarios = new Dictionary<long, Usuario>();

        private string opcion;

        static Usuarios()
        {
            usuarios.Add(1L, new Usuario(1L, "pepe@email.net", "contrapepe"));
            usuarios.Add(2L, new Usuario(2L, "javierlete@email.net", "contra"));
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                EnlazarDatos();
            }

            string opcion = Request["opcion"];
            string sId = Request["id"];

            switch (opcion)
            {
                case "editar":
                    long id = long.Parse(sId);
                    Usuario usuario = usuarios[id];

                    TxtId.Text = sId;
                    TxtEmail.Text = usuario.Email;
                    TxtPassword.Text = usuario.Password;

                    this.opcion = opcion;

                    break;
                case "eliminar":
                    TxtId.ReadOnly = true;
                    TxtEmail.Enabled = false;
                    TxtPassword.Enabled = false;

                    goto case "editar";
                case null:
                    break;
                default:
                    throw new NotImplementedException("No existe esa opción");
            }
        }

        private void EnlazarDatos()
        {
            GvUsuarios.DataSource = usuarios.Values;
            GvUsuarios.DataBind();

            GvUsuarios.HeaderRow.TableSection = TableRowSection.TableHeader;

            RUsuarios.DataSource = usuarios.Values;
            RUsuarios.DataBind();

            //DataBind();
        }

        protected void BtnAceptar_Click(object sender, EventArgs e)
        {
            Debug.WriteLine(opcion, "USUARIOS");

            if (IsValid)
            {
                long id = long.Parse(TxtId.Text);
                usuarios.Add(id, new Usuario(id, TxtEmail.Text, TxtPassword.Text));

                EnlazarDatos();

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