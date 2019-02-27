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

        public long Borrar(Usuario tipo)
        {
            throw new NotImplementedException();
        }

        public long Borrar(long id)
        {
            throw new NotImplementedException();
        }

        public Usuario BuscarPorEmail(string email)
        {
            throw new NotImplementedException();
        }

        public Usuario BuscarPorId(long id)
        {
            using (DbConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();

                DbCommand comando = conexion.CreateCommand();
                comando.CommandText = "SELECT Id, Email, Password FROM usuarios WHERE Id = @id";

                DbParameter parId = comando.CreateParameter();
                parId.DbType = System.Data.DbType.Int64;
                parId.ParameterName = "@id";
                parId.Value = id;

                comando.Parameters.Add(parId);

                DbDataReader dr = comando.ExecuteReader();

                Usuario usuario = null;

                if (dr.Read())
                {
                    usuario = new Usuario(dr.GetInt32(0), dr.GetString(1), dr.GetString(2));
                }

                return usuario;
            }
        }

        public List<Usuario> BuscarTodos()
        {
            throw new NotImplementedException();
        }

        public long Insertar(Usuario tipo)
        {
            throw new NotImplementedException();
        }

        public long Modificar(Usuario tipo)
        {
            throw new NotImplementedException();
        }
    }
}
