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
        private const string OPCION_EDITAR = "editar";
        private const string OPCION_ELIMINAR = "eliminar";
        private static Dictionary<long, Usuario> usuarios = new Dictionary<long, Usuario>();
        
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

        protected void ValidadorDni_ServerValidate(object source, ServerValidateEventArgs args)
        {
            //args.IsValid = Dni.EsValido(args.Value);
            try
            {
                new Dni(args.Value);
                args.IsValid = true;
            }
            catch (Exception e)
            {
                ValidadorDni.ErrorMessage = e.Message;
                args.IsValid = false;
            }
        }

        protected void ProcesarOpcionRejilla(object sender, CommandEventArgs e)
        {
            ResetearFormulario();

            string opcion = e.CommandName;
            string sId = (string)e.CommandArgument;
            long id;

            if (opcion != null)
            {
                BtnAceptar.CommandName = opcion;
            }

            if (!string.IsNullOrEmpty(sId))
            {
                id = long.Parse(sId);
                BtnAceptar.CommandArgument = sId;
            }
            else
            {
                id = -1;
            }

            switch (opcion)
            {
                case OPCION_EDITAR:
                    Usuario usuario = usuarios[id];

                    TxtId.Text = id.ToString();
                    TxtEmail.Text = usuario.Email;
                    TxtPassword.Text = usuario.Password;

                    break;
                case OPCION_ELIMINAR:
                    TxtId.ReadOnly = true;
                    TxtEmail.ReadOnly = true;
                    TxtPassword.ReadOnly = true;
                    RfvPassword.Enabled = false;

                    goto case OPCION_EDITAR;
                case null:
                    break;
                default:
                    throw new NotImplementedException("No existe esa opción");
            }
        }

        private void ResetearFormulario()
        {
            TxtId.ReadOnly = TxtEmail.ReadOnly = TxtPassword.ReadOnly = false;
            RfvPassword.Enabled = true;
            
            TxtId.Text = TxtEmail.Text = TxtPassword.Text = "";
            TxtDni.Text = "12345678Z";
        }

        protected void BtnAceptar_Command(object sender, CommandEventArgs e)
        {
            Trace.Warn("USUARIOS", "DENTRO DE BOTON ACEPTAR");
            string opcion = e.CommandName;

            if (IsValid)
            {
                long id = long.Parse(TxtId.Text);
                Usuario usuario = new Usuario(id, TxtEmail.Text, TxtPassword.Text);

                switch (opcion)
                {
                    case OPCION_EDITAR:
                        usuarios[long.Parse(TxtId.Text)] = usuario;
                        break;

                    case OPCION_ELIMINAR:
                        usuarios.Remove(id);
                        break;

                    default:
                        usuarios.Add(id, usuario);
                        break;

                }
                
                EnlazarDatos();

                Dni dni = new Dni(TxtDni.Text);

                ResetearFormulario();

                BtnAceptar.CommandName = "";
                BtnAceptar.CommandArgument = "";
            }
        }

        protected void ValidadorEmail_ServerValidate(object source, ServerValidateEventArgs args)
        {
            Trace.Warn("USUARIOS", "DENTRO DE SERVER VALIDATE DE EMAIL");

            try
            {
                new Usuario().Email = args.Value;
                args.IsValid = true;
            } catch(Exception e)
            {
                ValidadorEmail.ErrorMessage = e.Message;
                args.IsValid = false;
            }
        }
    }
}