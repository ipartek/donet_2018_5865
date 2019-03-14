using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tipos;

namespace AccesoDatos
{
    public class FabricaDao
    {
        public static IUsuarioDao GetDaoUsuario(string tipoDao) {
            switch (tipoDao)
            {
                case "entity": return new UsuarioEntityDao();
                case "sqlserver": return new UsuarioSqlDao();
            }

            throw new AccesoDatosException("No existe el tipo DAO " + tipoDao);
        }

        public static IDao<Rol> GetDaoRol(string tipoDao)
        {
            switch (tipoDao)
            {
                case "entity": return new RolEntityDao();
                case "sqlserver": return new RolSqlDao();
            }

            throw new AccesoDatosException("No existe el tipo DAO " + tipoDao);
        }
    }
}
