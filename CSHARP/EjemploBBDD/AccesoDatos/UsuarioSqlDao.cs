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
            Usuario usuario = null;

            try
            {
                using (DbConnection conexion = new SqlConnection(cadenaConexion))
                {
                    conexion.Open();

                    DbCommand comando = conexion.CreateCommand();
                    comando.CommandText = "SELECT Id, Email, Password FROM usuarios WHERE Email = @email";

                    DbParameter parEmail = comando.CreateParameter();
                    parEmail.DbType = System.Data.DbType.String;
                    parEmail.ParameterName = "@email";
                    parEmail.Value = email;

                    comando.Parameters.Add(parEmail);

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
            List<Usuario> usuarios = new List<Usuario>();

            try
            {
                using (DbConnection conexion = new SqlConnection(cadenaConexion))
                {
                    conexion.Open();

                    DbCommand comando = conexion.CreateCommand();
                    comando.CommandText = "SELECT Id, Email, Password FROM usuarios";

                    using (DbDataReader dr = comando.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            usuarios.Add(new Usuario(dr.GetInt32(0), dr.GetString(1), dr.GetString(2)));
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw new AccesoDatosException(e.Message, e);
            }

            return usuarios;
        }

        public int Insertar(Usuario usuario)
        {
            try
            {
                using (DbConnection conexion = new SqlConnection(cadenaConexion))
                {
                    conexion.Open();

                    DbCommand comando = conexion.CreateCommand();
                    comando.CommandText = "INSERT INTO usuarios (Email, Password) VALUES (@email, @password); SELECT CAST(SCOPE_IDENTITY() AS int);";

                    DbParameter parEmail = comando.CreateParameter();
                    parEmail.DbType = System.Data.DbType.String;
                    parEmail.ParameterName = "@email";
                    parEmail.Value = usuario.Email;

                    comando.Parameters.Add(parEmail);

                    DbParameter parPassword = comando.CreateParameter();
                    parPassword.DbType = System.Data.DbType.String;
                    parPassword.ParameterName = "@password";
                    parPassword.Value = usuario.Password;

                    comando.Parameters.Add(parPassword);

                    int idGenerado = (int)comando.ExecuteScalar();

                    //if(filasModificadas != 1)
                    //{
                    //    throw new AccesoDatosException("Se han modificado más de una fila");
                    //}

                    return idGenerado;
                }
            }
            catch (Exception e)
            {
                throw new AccesoDatosException(e.Message, e);
            }
        }

        public int Modificar(Usuario tipo)
        {
            throw new NotImplementedException();
        }
    }
}
