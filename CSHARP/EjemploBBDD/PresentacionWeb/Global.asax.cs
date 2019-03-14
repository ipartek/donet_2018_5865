using AccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using Tipos;

namespace PresentacionWeb
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Código que se ejecuta al iniciar la aplicación
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            IDao<Usuario> daoUsuarios = FabricaDao.GetDaoUsuario("entity");
            IDao<Rol> daoRoles = FabricaDao.GetDaoRol("entity");

            Rol admin = new Rol(nombre: "ADMIN", descripcion: "Administradores");
            Rol user = new Rol(nombre: "USER", descripcion: "Usuarios");

            Usuario javi = new Usuario("javierlete@email.net", "contra");
            Usuario pepe = new Usuario("pepe@email.net", "yepa");

            javi.Rol = admin;
            pepe.Rol = user;

            daoRoles.Insertar(admin);
            daoRoles.Insertar(user);

            daoUsuarios.Insertar(javi);
            daoUsuarios.Insertar(pepe);
        }
    }
}