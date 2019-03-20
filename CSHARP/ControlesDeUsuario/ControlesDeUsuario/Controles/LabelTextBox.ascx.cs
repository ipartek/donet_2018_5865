using System;

namespace ControlesDeUsuario
{
    public partial class LabelTextBox : System.Web.UI.UserControl
    {
        public string LabelTexto
        {
            get
            {
                return Lbl.Text;
            }

            set
            {
                Lbl.Text = value;
            }
        }

        public string Text
        {
            get { return Txt.Text; }
            set { Txt.Text = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}