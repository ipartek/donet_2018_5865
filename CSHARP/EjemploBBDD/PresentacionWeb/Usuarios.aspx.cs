using AccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tipos;

namespace PresentacionWeb
{
    public partial class Usuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string cadenaConexion = @"Data Source=DESKTOP-9GKENR5\SQLEXPRESS;Initial Catalog=ipartek;Integrated Security=True";
            IDao<Usuario> usuariosDao = new UsuarioSqlDao(cadenaConexion);

            if (!IsPostBack)
            {
                GvUsuarios.DataSource = usuariosDao.BuscarTodos();
                GvUsuarios.DataBind();
            }
        }
    }
}