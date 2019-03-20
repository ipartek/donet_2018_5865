using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ControlesDeUsuario
{
    public partial class Formulario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BtnBoton.OnPulsado += BtnBoton_OnPulsado;
            BtnBoton.OnPulsado += BtnBoton_OnPulsado1;
        }

        private void BtnBoton_OnPulsado1(object sender, EventArgs e)
        {
            BtnTest.Text = "Cambiado";
        }

        private void BtnBoton_OnPulsado(object sender, EventArgs e)
        {
            LblMensaje.Text = ltbNombre.Text + ", " + ltbDireccion.Text;
        }

        protected void BtnTest_Click(object sender, EventArgs e)
        {
            LblMensaje.Text = ltbNombre.Text + ", " + ltbDireccion.Text;
        }

    }
}