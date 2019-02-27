using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;

using Tipos;

namespace AccesoDatos
{
    public class UsuarioSqlDao : IUsuarioDao
    {
        private string cadenaConexion;

        public UsuarioSqlDao(string cadenaConexion)
        {
            this.cadenaConexion = cadenaConexion;
        }

        public int Borrar(Usuario tipo)
        {
            throw new NotImplementedException();
        }

        public int Borrar(int id)
        {
            throw new NotImplementedException();
        }

        public Usuario BuscarPorEmail(string email)
        {
            throw new NotImplementedException();
        }

        public Usuario BuscarPorId(int id)
        {
            Usuario usuario = null;

            try
            {
                using (DbConnection conexion = new SqlConnection(cadenaConexion))
                {
                    conexion.Open();

                    DbCommand comando = conexion.CreateCommand();
                    comando.CommandText = "SELECT Id, Email, Password FROM usuarios WHERE Id = @id";

                    DbParameter parId = comando.CreateParameter();
                    parId.DbType = System.Data.DbType.Int32;
                    parId.ParameterName = "@id";
                    parId.Value = id;

                    comando.Parameters.Add(parId);

                    using (DbDataReader dr = comando.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            usuario = new Usuario(dr.GetInt32(0), dr.GetString(1), dr.GetString(2));
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw new AccesoDatosException(e.Message, e);
            }

            return usuario;
        }

        public List<Usuario> BuscarTodos()
        {
            throw new NotImplementedException();
        }

        public int Insertar(Usuario tipo)
        {
            throw new NotImplementedException();
        }

        public int Modificar(Usuario tipo)
        {
            throw new NotImplementedException();
        }
    }
}
