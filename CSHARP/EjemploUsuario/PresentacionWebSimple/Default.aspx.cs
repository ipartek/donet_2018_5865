using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PresentacionWebSimple
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void IAceptar_Click(object sender, EventArgs e)
        {
            SSaludo.InnerText = "Hola " + INombre.Value;
        }

        protected void BtnAceptar_Click(object sender, EventArgs e)
        {
            LblSaludo.Text = "Hola " + TxtNombre.Text;
        }

        protected void CalFechaNacimiento_SelectionChanged(object sender, EventArgs e)
        {
            LblCalendario.Text = CalFechaNacimiento.SelectedDate.ToString();
        }
    }
}