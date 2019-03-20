using System;

namespace ControlesDeUsuario.Controles
{
    public partial class Boton : System.Web.UI.UserControl
    {
        public event EventHandler OnPulsado;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Btn_Click(object sender, EventArgs e)
        {
            OnPulsado(sender, e);
        }
    }
}