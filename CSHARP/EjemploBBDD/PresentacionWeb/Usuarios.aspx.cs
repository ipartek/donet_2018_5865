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
        private const string cadenaConexion = @"Data Source=.\SQLEXPRESS;Initial Catalog=ipartek;Integrated Security=True";
        private IDao<Usuario> usuariosDao = new UsuarioSqlDao(cadenaConexion);
        
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{
                RefrescarEnlazados();
            //}
        }

        private void RefrescarEnlazados()
        {
            GvUsuarios.DataSource = usuariosDao.BuscarTodos();
            GvUsuarios.DataBind();

            //DataBind();

            //RUsuarios.DataSource = usuariosDao.BuscarTodos();
            //RUsuarios.DataBind();
        }

        protected void BtnAceptar_Click(object sender, EventArgs e)
        {
            usuariosDao.Insertar(new Usuario(TxtEmail.Text, TxtPassword.Text));

            RefrescarEnlazados();
        }

        protected void RefrescarGvCompleto(object sender, ObjectDataSourceStatusEventArgs e)
        {
            GvCompleto.DataBind();
        }
    }
}