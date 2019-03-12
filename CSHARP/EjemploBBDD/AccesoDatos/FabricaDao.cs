using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
