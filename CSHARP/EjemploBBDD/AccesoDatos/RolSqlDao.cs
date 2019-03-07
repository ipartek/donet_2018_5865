using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tipos;

namespace AccesoDatos
{
    public class RolSqlDao : IDao<Rol>
    {
        private const string CADENA_CONEXION_POR_DEFECTO = @"Data Source=.\SQLEXPRESS;Initial Catalog=ipartek;Integrated Security=True";

        #region CRUD
        public int Borrar(Rol tipo)
        {
            throw new NotImplementedException();
        }

        public int Borrar(int id)
        {
            throw new NotImplementedException();
        }

        public Rol BuscarPorId(int id)
        {
            return ConsultaDeUnaFila("SELECT Id, Rol, Descripcion FROM Roles WHERE Id=@id", new Rol(id));
        }

        public List<Rol> BuscarTodos()
        {
            return ConsultaDeDatosMultiples("SELECT Id, Rol, Descripcion FROM Roles");
        }

        public int Insertar(Rol tipo)
        {
            throw new NotImplementedException();
        }

        public int Modificar(Rol tipo)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Métodos privados

        private List<Rol> ConsultaDeDatosMultiples(string sql, Rol rol = null)
        {
            List<Rol> roles = new List<Rol>();

            try
            {
                using (DbConnection conexion = new SqlConnection(CADENA_CONEXION_POR_DEFECTO))
                {
                    conexion.Open();

                    DbCommand comando = conexion.CreateCommand();
                    comando.CommandText = sql;

                    if (rol != null)
                    {
                        DbParameter parId = comando.CreateParameter();
                        parId.DbType = System.Data.DbType.Int32;
                        parId.ParameterName = "@id";
                        parId.Value = rol.Id;

                        comando.Parameters.Add(parId);

                        if (rol.Nombre != null)
                        {
                            DbParameter parNombre = comando.CreateParameter();
                            parNombre.DbType = System.Data.DbType.String;
                            parNombre.ParameterName = "@nombre";
                            parNombre.Value = rol.Nombre;

                            comando.Parameters.Add(parNombre);
                        }

                        if (rol.Descripcion != null)
                        {
                            DbParameter parDescripcion = comando.CreateParameter();
                            parDescripcion.DbType = System.Data.DbType.String;
                            parDescripcion.ParameterName = "@descripcion";
                            parDescripcion.Value = rol.Descripcion;

                            comando.Parameters.Add(parDescripcion);
                        }
                    }

                    using (DbDataReader dr = comando.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            roles.Add(new Rol(dr.GetInt32(0), dr.GetString(1), dr.GetString(2)));
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw new AccesoDatosException(e.Message, e);
            }

            return roles;
        }

        private Rol ConsultaDeUnaFila(string sql, Rol rol = null)
        {
            List<Rol> roles = ConsultaDeDatosMultiples(sql, rol);

            switch (roles.Count)
            {
                case 1:
                    return roles[0];
                case 0:
                    return null;
                default:
                    throw new AccesoDatosException("Se ha recibido más de un resultado en una consulta de un resultado");
            }
        }

        #endregion
    }
}
